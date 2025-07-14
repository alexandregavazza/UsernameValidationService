# UsernameValidationService

A .NET 6 microservice that manages **unique usernames** per account using **REST APIs**. It ensures usernames are **valid**, **unique**, and **one-to-one mapped** with account IDs.

---

## Tech Stack

- ASP.NET Core 6 Web API
- Entity Framework Core
- SQLite (for development)
- Swagger (OpenAPI) for API documentation

---

## Features

- Validate if a username meets required format (length, characters)
- Ensure uniqueness across usernames
- One account ID (GUID) maps to one username
- Supports username **update** by resubmitting the same account ID
- REST API with `GET` and `POST` methods
- Data stored locally using SQLite

---

## How to Run

### Prerequisites

- Visual Studio 2022 or later
- .NET 6 SDK
- EF Core tools (installed via NuGet)

### Steps

1. Clone the repository:

```bash
git clone https://github.com/alexandregavazza/UsernameValidationService.git
cd UsernameValidationService
