Simple Product API Project
Overview
The Simple Product API project is a .NET Core application developed to provide basic CRUD (Create, Read, Update, Delete) functionality for managing products in an e-commerce application. It utilizes Entity Framework Core for database operations and follows RESTful principles for API design. The project aims to deliver a scalable and maintainable solution for handling product-related operations efficiently.

Features
RESTful API Endpoints: Implements endpoints for retrieving, creating, updating, and deleting products.
Database Integration: Utilizes Entity Framework Core to interact with a Microsoft SQL Server database for storing product data.
Pagination: Supports pagination for fetching large lists of products efficiently.
Error Handling and Validation: Implements proper error handling and validation to ensure data integrity and reliability.
Dependency Injection: Utilizes dependency injection for managing dependencies and promoting code maintainability.
Unit Testing (Optional): Provides unit tests to ensure the correctness and reliability of the API endpoints.
Usage
To use the Simple Product API project:

Clone the repository to your local machine.
Configure the database connection string in the appsettings.json file to point to your SQL Server database.
Build and run the application using Visual Studio or the .NET CLI.
Access the API endpoints using an API client or browser to perform CRUD operations on products.
Technologies Used
.NET 8: Framework for building cross-platform applications.
Entity Framework Core: Object-Relational Mapping (ORM) framework for database interactions.
ASP.NET Core MVC: Framework for building web APIs and web applications.
Microsoft SQL Server: Relational database management system for storing product data.
Project Structure
The project structure follows a modular and organized approach to promote code readability and maintainability. Key components include:

Controllers: Contains API controllers responsible for handling HTTP requests and responses.
Services: Contains business logic and services for performing product-related operations.
Models: Defines data models and request/response models used by the API.
Repositories (Optional): If applicable, contains repositories for data access and interaction with the database.


Thank you for using the Simple Product API project! Happy coding!
