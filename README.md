# Blazor Server with Authentication & Database Connections

The purpose of this project is to set a Blazor Server with Single Tenant Authentication.  Also, we will add MSSQL and Mongo Database connections with calls.

# Prerequisites

Install [.NET 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

# Authentication/Authorization

I'm currently using Microsoft Entra ID.

## Identity Setup

- Create new App Registration
- Set Redirect URL to `https://localhost:5001/signin-oidc`
- Enable `Access tokens` & `ID tokens` under Implicit grant & hybrid flows.
- Grant admin consent for Default Directory under API Permissions.
- Copy `Client ID` & `Tenant ID` to appsettings.json
  - Domain is under Entra ID


## Mongo Setup

- Install (or connect to) MongoDB
- Create `BlazorServerWithAuthAndDatabase` database and `Weather` collections
- Insert one or many documents (example below)

```javascript
db.Weather.insertMany([{
    TemperatureC: 32,
    Summary: 'Cold',
    Date: ISODate()
}])
```

## MSSQL Setup
- Install (or connect to) MSSQL
- Create `BlazorServerWithAuthAndDatabase` database and `Users` table
- Insert one or many entries (example below)

```sql
INSERT INTO Users(First, Last, Email)
VALUES('John', 'Stone', 'john@stone.com')
```

# Run

### Open terminal and run the following

Move to directory
```shell
cd BlazorServerWithAuthAndDatabase
```

Build project
```shell
dotnet build
```

Run Project (Windows)
```shell
dotnet run --project .\BlazorServerWithAuthAndDatabase\BlazorServerWithAuthAndDatabase.csproj
```

Run Project (Linux)
```shell
dotnet run --project ./BlazorServerWithAuthAndDatabase/BlazorServerWithAuthAndDatabase.csproj
```

# Contributors

- [admin@werminal.com](admin@werminal.com)

# References

- [Microsoft Identity Web Library Docs](https://learn.microsoft.com/en-us/entra/msal/dotnet/microsoft-identity-web/)