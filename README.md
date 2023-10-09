# CRUDAssessment

## Overview

The CRUDAssessment project is a simple ASP.NET Core Web API application that provides CRUD (Create, Read, Update, Delete) operations for managing user data. It is designed to work with a Microsoft SQL Server database to store and retrieve user information. This README provides an overview of the project and instructions on how to set it up and use it.

## Table of Contents

- **Getting Started**
  - *Prerequisites*
  - *Installation*
- **Project Structure**
- **Configuration**
- **API Endpoints**
- **Usage**
- **Contributing**
- **License**

## Getting Started

### Prerequisites

Before you can run the CRUDAssessment project, make sure you have the following prerequisites installed:

- .NET Core SDK (version >= 3.1)
- Microsoft SQL Server

### Installation

1. Clone the repository to your local machine:
git clone https://github.com/TEEWEIPHENG/CRUDAssessment.git

2. Navigate to the project directory:
cd CRUDAssessment

3. Create a SQL Server database for the project.

4. Update the database connection string in the `appsettings.json` file with your database connection details:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=<server>;Database=<database>;User=<user>;Password=<password>"
}
```

5. Build and run the project:
dotnet build
dotnet run

### Project Structure
The project is organized as follows:

- **Controllers/**: Contains the API controllers for user management.
- **Data/**: Includes the data context and database models.
- **Services/**: Contains the service classes responsible for CRUD operations.
- **Models/**: Defines the DTOs (Data Transfer Objects) used for input and output.
- **Program.cs**: Configuration of the ASP.NET Core application.

### Configuration
You can configure the project by modifying the *appsettings.json* file. This file contains settings for the database connection and other application-specific configurations.

### API Endpoints
The CRUDAssessment project provides the following API endpoints for user management:

- '**GET /api/users**': Get a list of all users.
- '**GET /api/users/{id}**': Get a user by ID.
- '**POST /api/users**': Create a new user.
- '**PUT /api/users/{id}**': Update an existing user by ID.
- '**DELETE /api/users/{id}**': Delete a user by ID.
For detailed information on how to use these endpoints, you can refer to the API documentation or explore the Controllers and Models folders in the project.

### Usage
You can use tools like **Postman** or **curl** to interact with the API endpoints and perform CRUD operations on user data. Make sure to follow the API documentation for proper request and response formats.
