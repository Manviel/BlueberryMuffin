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

