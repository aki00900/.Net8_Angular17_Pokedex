
# Pokédex Web Application

Welcome to the **Pokédex Web Application**, a modern single-page application (SPA) that provides detailed information about various Pokémon. Built using **.NET 8** for the backend and **Angular 17** for the frontend, this application also integrates a SQL Server database to store and manage Pokémon data efficiently.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Backend Setup](#backend-setup)
  - [Frontend Setup](#frontend-setup)
  - [Running the Application](#running-the-application)
- [Database Setup](#database-setup)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)

## Project Overview

This project demonstrates the integration of a robust backend API, developed in .NET 8, with a dynamic and responsive Angular 17 frontend. The backend manages data using SQL Server and exposes endpoints via a Swagger UI, while the frontend consumes these APIs to display Pokémon information in an engaging and interactive format.

## Features

- **Comprehensive Pokémon Data**: Displays detailed information for each Pokémon, including types, regions, and Pokédex numbers.
- **Database Integration**: Seamless interaction with a SQL Server database to retrieve and manage Pokémon data.
- **Responsive Design**: Ensures a consistent experience across various devices.
- **Swagger UI**: Provides an interactive interface to explore and test backend APIs.

## Getting Started

To get started with the project locally, follow these instructions.

### Prerequisites

Ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js and npm](https://nodejs.org/) (for Angular)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (optional, if using a local database)

### Backend Setup

1. **Clone the Repository**  
   Clone this repository to your local machine.

2. **Open in Visual Studio**  
   Navigate to the `MyWebApp` folder and open it in Visual Studio.

3. **Build the Project**  
   Restore dependencies and build the project.

4. **Run the Backend**  
   Start the `MyWebApp` project. This will launch the backend server and open the Swagger UI at:  
   `http://localhost:{PORT}/swagger`  
   Use the Swagger UI to interact with the available API endpoints.

### Frontend Setup

1. **Navigate to Angular Project**  
   Open the `Angular17Client` folder in Visual Studio Code.

2. **Install Dependencies**  
   Open a terminal, navigate to the `src` directory, and run:
   ```bash
   npm install
   ```

3. **Run the Frontend**  
   Start the Angular application by running:
   ```bash
   ng serve
   ```
   Access the application at `http://localhost:4200` in your browser.

### Running the Application

To run the complete application:

1. **Backend**  
   - Open the `MyWebApp` folder in Visual Studio.
   - Start the backend server. Swagger UI will be available for API interaction.

2. **Frontend**  
   - Open the `Angular17Client` folder in Visual Studio Code.
   - Navigate to the `src` directory in the terminal.
   - Run `ng serve` to launch the frontend.
   - Access the live application at `http://localhost:4200`.

## Database Setup

The application uses SQL Server for managing Pokémon data. Below is a sample SQL command to create the Pokémon table:

```sql
CREATE TABLE Pokemon (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    TypeId INT,
    PokedexNumber INT,
    RegionId INT,
    FOREIGN KEY (TypeId) REFERENCES Type(Id),
    FOREIGN KEY (RegionId) REFERENCES Region(Id)
);
```

You can populate the database manually using SQL scripts or interact with it through the API.

## Troubleshooting

### Common Issues

- **HTTPS Development Certificate on macOS**  
  If you encounter issues with the HTTPS development certificate on macOS, consider the following steps:
  - Manually import the certificate into the keychain.
  - Adjust keychain permissions.
  - Execute relevant commands with `sudo`.
  - Reset the keychain if needed.

- **SQL Server on Docker (M1 Mac)**  
  If running SQL Server on Docker on an M1 Mac, use this command to start the container:
  ```bash
  docker run -e "ACCEPT_EULA=1" -e "SA_PASSWORD=MyStrongPass123" -p 1433:1433 -d --name sql_server mcr.microsoft.com/mssql/server
  ```

## Contributing

Contributions are welcome! Feel free to fork this repository, make your changes, and submit a pull request. Please ensure your changes are well-documented and tested.
