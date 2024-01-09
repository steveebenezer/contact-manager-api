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
    private readonly string _filePath = "contacts.json";

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
  }
}