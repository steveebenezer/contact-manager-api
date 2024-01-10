using ContactManagerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ContactManagerApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactsController: ControllerBase
  {
    private readonly string _filePath;

    public ContactsController(IWebHostEnvironment environment)
    {
      _filePath = Path.Combine(environment.ContentRootPath, "Data", "contacts.json");
    }


    [HttpGet]
    public IEnumerable<Contact> Get()
    {
      var contactsJson = System.IO.File.ReadAllText(_filePath);

      if (contactsJson == null)
      {
        return Enumerable.Empty<Contact>();
      }

      var contacts = JsonSerializer.Deserialize<IEnumerable<Contact>>(contactsJson);
      return contacts ?? Enumerable.Empty<Contact>();
    }

    [HttpGet("{id}")]
    public ActionResult<Contact> Get(int id)
    {
      var contactsJson = System.IO.File.ReadAllText(_filePath);

      if (contactsJson == null)
      {
        return NotFound();
      }

      var contacts = JsonSerializer.Deserialize<IEnumerable<Contact>>(contactsJson);
      var contact = contacts.FirstOrDefault(c => c.Id == id);

      if (contact == null)
        return NotFound();

      return contact;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Contact newContact)
    {
      var contactsJson = System.IO.File.ReadAllText(_filePath);

      if (contactsJson == null)
      {
        return BadRequest("Unable to read contacts file");
      }

      var contacts = JsonSerializer.Deserialize<List<Contact>>(contactsJson) ?? new List<Contact>();

      int maxId = contacts.Any() ? contacts.Max(c => c.Id) : 0;

      newContact.Id = maxId + 1;
      contacts.Add(newContact);

      var updatedJson = JsonSerializer.Serialize(contacts);
      System.IO.File.WriteAllText(_filePath, updatedJson);

      return Ok(newContact);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Contact updatedContact)
    {
      var contactsJson = System.IO.File.ReadAllText(_filePath);

      if (contactsJson == null)
      {
        return BadRequest("Unable to read contacts file");
      }

      var contacts = JsonSerializer.Deserialize<List<Contact>>(contactsJson) ?? new List<Contact>();

      var existingContact = contacts.FirstOrDefault(c => c.Id == id);

      if (existingContact == null)
        return NotFound();

      existingContact.FirstName = updatedContact.FirstName;

      var updatedJson = JsonSerializer.Serialize(contacts);
      System.IO.File.WriteAllText(_filePath, updatedJson);

      return Ok(existingContact);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var contactsJson = System.IO.File.ReadAllText(_filePath);

      if (contactsJson == null)
      {
        return BadRequest("Unable to read contacts file");
      }

      var contacts = JsonSerializer.Deserialize<List<Contact>>(contactsJson) ?? new List<Contact>();

      var existingContact = contacts.FirstOrDefault(c => c.Id == id);

      if (existingContact == null)
        return NotFound();

      contacts.Remove(existingContact);

      var updatedJson = JsonSerializer.Serialize(contacts);
      System.IO.File.WriteAllText(_filePath, updatedJson);

      return Ok();
    }
  }
}