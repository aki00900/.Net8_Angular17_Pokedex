
```markdown
# Pokédex Web App

This project is a small Pokédex-like single webpage application built with .NET 8 and Angular 17. It includes a database system that stores information about various Pokémon and their attributes. The backend handles the API and data management, while the frontend displays the information in a user-friendly manner.

## Project Structure

- **Backend:** .NET 8 project located in the `MyWebApp` folder.
- **Frontend:** Angular 17 project located in the `Angular17Client` folder.
- **Database:** SQL Server is used for creating tables and storing Pokémon data.

## Features

- Display a list of Pokémon with their details.
- Integration with a database to fetch and display Pokémon information.
- Responsive design to ensure compatibility across different devices.
- Swagger UI to interact with the backend API.

## Getting Started

Follow these steps to run the project locally.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js and npm](https://nodejs.org/) (for Angular)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (optional, if using a local database)

### Backend Setup

1. Clone the repository to your local machine.
2. Open the `.NET` project located in the `MyWebApp` folder using Visual Studio.
3. Build the project to restore dependencies.
4. Run the `MyWebApp` project. This will start the backend server and open the Swagger UI.
   - Swagger URL: `http://localhost:{PORT}/swagger`
   - The Swagger UI displays the available controllers and endpoints for the API.

### Frontend Setup

1. Navigate to the `Angular17Client` folder.
2. Open the folder in Visual Studio Code.
3. In the terminal, navigate to the `src` directory:
   ```bash
   cd Angular17Client/src
   ```
4. Install the necessary npm packages:
   ```bash
   npm install
   ```
5. Run the Angular application:
   ```bash
   ng serve
   ```
6. Open your browser and navigate to the provided localhost URL (typically `http://localhost:4200`).

### Running the Application

To run the complete application, follow these steps:

1. **Backend:**
   - Open the `MyWebApp` folder in Visual Studio.
   - Run the `MyWebApp` project to start the backend server.
   - The backend will start and open the Swagger UI, where you can interact with the API endpoints.

2. **Frontend:**
   - Open the `Angular17Client` folder in Visual Studio Code.
   - Navigate to the `src` directory in the terminal.
   - Run the command `ng serve` to start the Angular frontend.
   - Open your browser and navigate to `http://localhost:4200` to view the functional webpage.

### Database Setup

The database schema includes tables for Pokémon and their attributes such as Type and Region. You can set up the database manually using SQL Server Management Studio (SSMS) or automate it through migrations.

#### Sample SQL Command

Here's a sample SQL command to create the Pokémon table:

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

You can insert data into the table using SQL scripts or directly through the API.

## Troubleshooting

### Common Issues

1. **HTTPS Development Certificate on macOS:**
   If you encounter issues with the HTTPS development certificate on macOS, try the following steps:
   - Manually import the certificate into the keychain.
   - Adjust keychain permissions.
   - Run relevant commands with `sudo`.
   - Reset the keychain if necessary.

2. **SQL Server on Docker:**
   If you're using an M1 Mac and having trouble running SQL Server on Docker, you can start the container with the following command:
   ```bash
   docker run -e "ACCEPT_EULA=1" -e "SA_PASSWORD=MyStrongPass123" -p 1433:1433 -d --name sql_server mcr.microsoft.com/mssql/server
   ```

## Contributing

Feel free to fork the repository and make changes. Pull requests are welcome!
