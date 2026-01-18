Library.Management.System

The Library Management System is a multi-layered C#/.NET application that allows users to register, add,update, browse, view  books and delete books.
It is a very simplified api with professional tourch of development which features user authentication, role-based access (Admin/User) and book management.

Tech Stack		
Layer				Technology
Language			C# (.NET 8 / .NET 9)
Framework			ASP.NET Core Web API
Data Access			Entity Framework Core
Database			SQL Server
Authentication		JWT (JSON Web Token)
Logging				Microsoft.Extensions.Logging
Architecture		Layered (Presentation,Business,Repository)

Setup & Running Instructions

Clone the repository
git clone https://github.com/Akin545/Library-Management-System
cd LibraryManagementSystem

Configure the database
Edit the appsettings.json file in the API project to set your SQL Server connection string:
"ConnectionStrings": {
  "Sql": "Server=localhost;Database=BookDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

After proper settings run the application and the database BookDB is Applied created automatically.

Other options
Use the .NET CLI to create and update the database:
cd Library.Management.System.Repository
Update-Database

A default admin has been seeded to start with the application with books alongside. Check the AppDbcontext for details or the database

If you get a mismatch error, ensure the target project is Library.Management.System.Repository.

Run the API
cd ../Library.Management.System
dotnet run

Design Choices
Layered Architecture
The system is split into:

Presentation Layer (API): Handles HTTP requests and responses.

Business Logic Layer: Implements validation, business rules, and service orchestration.

Repository Layer: Manages database operations via EF Core.
This separation improves testability, maintainability, and scalability.

Dependency Injection
Services and repositories are injected using .NET’s built-in DI container.

The project is broken down into

Book creation and validation

Role-based permission enforcement (Admin/User). Though both authorized users can simply carry out same task for now

Error Handling
Custom exception classes (e.g. BookException, UserException) provide clear error messages.

Logging is centralized using ILogger<T> for consistent error tracking.


JWT Authentication
Secure access control using JSON Web Tokens.

Protects book management endpoints from unauthorized users.

Extensibility
The system was designed for future scalability:

Can integrate with email/SMS notifications.

Can easily support payment gateways.

Can scale to microservices or Azure-based architecture later.

Author
Akinfosile Sola
solaakinfosile@gmail.com
www.linkedin.com/in/akinfosile-sola-352587156
