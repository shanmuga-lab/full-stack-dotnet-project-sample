# full-stack-dotnet-project-sample
Full stack dotnet projects using different patterns like MVC, CQRS etc. are coded in detailed fashion.

## Solution Overview

This solution is a multi-service .NET full-stack application with separate service, repository, model, and web app projects, supporting both .NET 8 and .NET 10 targets.

## Project structure

### Core Online Store Projects (OnlineStoreAdmin folder)
- `OnlineStoreAdmin.sln` — solution file.
- `OnlineStoreAdmin/` — ASP.NET Core Razor Pages web application and startup project (.NET 8).
- `OnlineStoreRepository/` — Entity Framework Core repository project with `BrandRepository` and EF Core packages (.NET 8).
- `OnlineStoreService/` — business service layer (.NET 8).
- `OnlineStoreModel/` — model classes and service contracts (.NET 8).

### Catalog Microservices (Services/Catalog folder)
- `Catalog.API/` — Catalog microservice API (.NET 10).
- `Catalog.Application/` — application layer for catalog service.
- `Catalog.WebAPI/` — web API layer for catalog service.
- `Catalog.Core/` — core domain models for catalog service.
- `Catalog.Infrastructure/` — infrastructure layer for catalog service with data access and external service integrations.

## Key details

### Online Store Admin (OnlineStoreAdmin)
- Target framework: `net8.0`
- Database provider: `Microsoft.EntityFrameworkCore.SqlServer`
- EF Core tools: `Microsoft.EntityFrameworkCore.Tools` v8.0.29
- Architecture: Multi-layered (Presentation, Service, Repository, Model)
- Startup configuration for `BrandRepository` is in `OnlineStoreAdmin/Program.cs`.

### Catalog Services
- Target framework: `net10.0` (Catalog.API)
- Architecture support for application, infrastructure, and core domain layers
- Blob storage integration: `Azure.Storage.Blobs` v12.29.1

## Prerequisites

- .NET SDK 8.0 and .NET 10.0 installed
- SQL Server instance reachable from the machine
- Connection string configured in `OnlineStoreAdmin/appsettings.json`
- (Optional) Azure Storage account for blob storage features in Catalog services

## Running the applications

### Online Store Admin Web App

From the project root:

```bash
cd 'C:\Users\shans\source\repos\shanmuga-lab\full-stack-dotnet-project-sample'
dotnet run --project OnlineStoreAdmin/OnlineStoreAdmin/OnlineStoreAdmin.csproj
```

### Catalog API Service

```bash
dotnet run --project Services/Catalog/Catalog.API/Catalog.API.csproj
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