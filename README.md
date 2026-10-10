# Online Store Project

This solution is a .NET 8 full-stack application with separate service, repository, model, and web app projects.

## Project structure

- `OnlineStoreAdmin.sln` — solution file.
- `OnlineStoreAdmin/` — ASP.NET Core web application and startup project.
- `OnlineStoreRepository/` — Entity Framework Core repository project with `BrandRepository` and EF Core packages.
- `OnlineStoreService/` — business service layer.
- `OnlineStoreModel/` — model classes and service contracts.

## Key details

- Target framework: `net8.0`
- Database provider: `Microsoft.EntityFrameworkCore.SqlServer`
- EF Core tools: `Microsoft.EntityFrameworkCore.Tools`
- Startup configuration for `BrandRepository` is in `OnlineStoreAdmin/Program.cs`.

## Prerequisites

- .NET SDK 8.0 installed
- SQL Server instance reachable from the machine
- Connection string configured in `OnlineStoreAdmin/appsettings.json`

## Running the web app

From the project root:

```bash
cd '/Users/shanmugavenugopal/Working Repo/DotNetFullStackFolder/online-store-project'
dotnet run --project OnlineStoreAdmin/OnlineStoreAdmin.csproj
```

## EF Core migrations

Use the `--project` and `--startup-project` options so EF Core can find the repository and the startup configuration:

```bash
cd '/Users/shanmugavenugopal/Working Repo/DotNetFullStackFolder/online-store-project'
dotnet ef migrations add brandrepo \
  --project OnlineStoreRepository/OnlineStoreRepository.csproj \
  --startup-project OnlineStoreAdmin/OnlineStoreAdmin.csproj \
  --context BrandRepository
```

```bash
dotnet ef database update typrepo \
  --project OnlineStoreRepository/OnlineStoreRepository.csproj \
  --startup-project OnlineStoreAdmin/OnlineStoreAdmin.csproj \
  --context TypeRepository
```

## Notes

- The web app project is the startup project and owns the connection string.
- The repository project contains the `DbContext` implementation.
- If you need design-time support for EF Core, ensure `BrandRepository` has a constructor accepting `DbContextOptions<BrandRepository>` and is registered in the startup project.

## Pushing repository to Azure repo

```bash
git remote add origin https://shanmuga-lab@dev.azure.com/shanmuga-lab/DOTNET_FULL_STACK_BATCH/_git/DOTNET_FULL_STACK_BATCH
git push -u origin --all
```