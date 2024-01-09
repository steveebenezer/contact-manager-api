# ASP.NET Web API with JSON File Backend
A simple CRUD (Create, Read, Update, Delete) functionality using ASP.NET Web API with a JSON file as the backend.

## Overview
This project demonstrates a basic implementation of a RESTful API using ASP.NET Web API, with CRUD operations backed by a JSON file. The application manages a collection of contacts stored in a JSON file (contacts.json), providing endpoints to perform operations like fetching all items, getting a specific item by ID, creating a new item, updating an existing item, and deleting an item.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- A code editor of your choice (e.g., [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/)).

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/steveebenezer/contact-manager-api.git
    ```

2. Navigate to the project directory:

    ```bash
    cd contact-manager-api
    ```

3. Build and run the application:

    ```bash
    dotnet build
    dotnet run
    ```

The API should be running at `http://localhost:5000` (or a different port if specified).

## Usage

### API Endpoints

- **Get All Contacts:**

  ```http
  GET /api/contacts
  ```
- **Get Contact by Id:**

  ```http
  GET /api/contacts/{id}
  ```
- **Create new Contact:**

  ```http
  POST /api/items
  ```
- **Update Contact by Id:**

  ```http
  PUT /api/contacts/{id}
  ```
- **Delete Contact by Id:**

  ```http
  DELETE /api/contacts/{id}
  ```