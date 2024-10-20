# Web API Development with ASP.NET Core 8

This project was bootstrapped with .NET Core.

## Available Scripts

In the project directory, open it through Visual Studio and go to `Tools / NuGet Package Manager / Console`:

```
Add-Migration Name
```

Creates a migration.

```
Update-Database
```

Performs migration.

## Usage

Open https://localhost:7261/swagger/index.html to view it in the browser.

## Key Terms and Definitions

Task - A task in C# is used to implement Task-based Asynchronous Programming. The Task object is typically executed asynchronously on a thread pool thread rather than synchronously on the main thread of the application.

ActionResult - An action is capable of returning a specific data type. When multiple return types are possible, it's common to return ActionResult, IActionResult or ActionResult<T>, where T represents the data type to be returned.

### Resources

- [JwtRegisteredClaimNames](https://learn.microsoft.com/en-us/dotnet/api/system.identitymodel.tokens.jwt.jwtregisteredclaimnames?view=msal-web-dotnet-latest)

- [TokenValidationParameters](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.tokens.tokenvalidationparameters?view=msal-web-dotnet-latest)

### OData

Helps make query parameters efficient.

- $select = name,codename
- $filter = name eq 'Cuba'
- $orderby = name

### Folders

- Data - for Data Transfer Objects.
- Models - for DataBase models.

## Requirements

> Per 14/10/2024

The respondent can only fill in the survey.

Admin can:
- [ ] Manage managers
- [ ] Assign them (other managers).

Manager
- [ ] Can Not see other survey results.
- [ ] View assigned survey results.
- [ ] Send report via webhook when respondent complete survey.
- [ ] Create constructor for questions (text, multiple / single choices).
- [ ] Validation for questions.
- [ ] Respondent management (email + status (invited, completed, opened, disabled)).
- [ ] Add Respondents via API and CSV import.
- [ ] When you add Respondent they should receive invitation email.

### Roles

First, you register a `User`, and then assign roles (`Administrator` | `Manager`) to them.