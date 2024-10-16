# EmployeeManagementApp

## Employee Management System Web API

### Overview

The Employee Management System Web API is a RESTful service built using .NET 8 and Entity Framework Core, with SQL Server as the database. This API allows for the management of employee records and department details, enabling basic CRUD operations such as creating, reading, updating, and deleting employees and departments.

### Features
- Employee Management: Add, edit, view, and delete employee records.
- Department Management: Create and manage departments.
- Entity Relationships: Employees are assigned to departments with a foreign key relationship.
- Repository Pattern: Separation of concerns with repository and interface patterns for better maintainability.
- MSSQL Database Integration: Connected with SQL Server for data persistence.
- RESTful API: Supports standard HTTP methods for CRUD operations.

### Technologies Used
- .NET 8 Web API: For building the RESTful API.
- Entity Framework Core: For database access and management.
- MSSQL (SQL Server): Database system used for data persistence.
- C#: Programming language.
- GitHub Actions: For CI/CD pipeline to automate build and test processes.

### Prerequisites

Before running the application, ensure you have the following installed:

- .NET 8 SDK
- SQL Server
- Git
- A code editor, such as Visual Studio or Visual Studio Code.

### Setup Instructions

1. Clone the repository
First, clone the project to your local machine using the following command:

bash
Copy code
git clone https://github.com/Thilrash/EmployeeManagementApp.git
cd employee-management-api

2. Configure the Database

Make sure SQL Server is running, then update the connection string in the appsettings.json file:

json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EmployeeManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

3. Run Database Migrations

To apply the database migrations and set up the database, run the following commands:

bash
Copy code
dotnet ef migrations add InitialCreate
dotnet ef database update
This will create the required tables for Employee and Department.

4. Build and Run the Application

To build and run the API, use the following command:

bash
Copy code
dotnet run
The API will start on https://localhost:5001 or http://localhost:5000. You can test it using tools like Postman or curl.

### API Endpoints

Here are the available API endpoints for managing employees and departments.

Employees
- GET /api/employees - Get all employees
- GET /api/employees/{id} - Get employee by ID
- POST /api/employees - Create a new employee
- PUT /api/employees/{id} - Update an employee
- DELETE /api/employees/{id} - Delete an employee

Departments
- GET /api/departments - Get all departments
- GET /api/departments/{id} - Get department by ID
- POST /api/departments - Create a new department
- PUT /api/departments/{id} - Update a department
- DELETE /api/departments/{id} - Delete a department

Running Tests
- The application includes unit tests to ensure the functionality of repositories and services. To run the tests, use the following command:

bash
Copy code
dotnet test
Continuous Integration (CI)
This project uses GitHub Actions for CI to ensure code quality and stability. The action is configured to trigger on every merge to the master branch. It runs the following tasks:

Build the project
Restore dependencies
Run tests
You can view the status of the GitHub Actions workflow under the Actions tab in the repository.

Contribution Guidelines
If you'd like to contribute to this project, please follow the steps below:

Fork the repository.
Create a new feature branch.
Commit your changes.
Push the branch to your fork.
Open a pull request.

License
This project is licensed under the MIT License. See the LICENSE file for more details.