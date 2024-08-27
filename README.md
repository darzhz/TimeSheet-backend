![Build Status](https://github.com/darzhz/TimeSheet-backend/actions/workflows/dotnet.yml/badge.svg)

# Timesheet Server Backend

This repository contains the backend implementation for the **Timesheet** application, a .NET-based server for managing employee timesheets. The backend follows the service-repository pattern, ensuring clean separation of concerns and ease of maintainability.For the latest frontend fork and run [Timesheet-Frontend](https://github.com/jismycs15/Timesheet-Frontend)

[![Typing SVG](https://readme-typing-svg.demolab.com?font=Fira+Code&pause=1000&color=00F747&width=435&lines=Sprint+4+Active)](https://git.io/typing-svg)


## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Database Setup](#database-setup)

## Features

- Manage employee timesheets.
- CRUD operations for employees, timesheets, and entries.
- Service-repository pattern for maintainable and testable code.
- PostgreSQL database integration.

## Technologies Used

- **.NET** (ASP.NET Core)
- **Entity Framework Core** - for data access.
- **PostgreSQL** - as the relational database.
- **Service-Repository Pattern** - for a clean and modular codebase.
- ![image](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white) ![image](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white) ![image](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=JSON%20web%20tokens&logoColor=white)

## Installation

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/downloads)

### Clone the Repository

```bash
git clone https://github.com/yourusername/timesheet-backend.git
cd timesheet-backend
```

### Restore Dependencies

```bash
dotnet restore
```

### Database Setup

1. Make sure PostgreSQL is installed and running on your machine.
2. Create a new database:

    ```bash
    createdb timesheetdb
    ```

3. Download the database dump SQL file from the [Releases](https://github.com/darzhz/timesheet-backend/releases) page and import it:

    ```bash
    psql -U yourusername -d timesheetdb -f path/to/dump.sql
    ```

4. Update the connection string in the `appsettings.json` file located in the root of the project:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=timesheetdb;Username=yourusername;Password=yourpassword"
    }
    ```

## Running the Application

### Development Environment

To run the application in a development environment:

```bash
dotnet run
```

The application will start and listen on the default port, usually `https://localhost:5001`.

### Production Environment

To run the application in a production environment:

- Build the project:

    ```bash
    dotnet build --configuration Release
    ```

- Publish the application:

    ```bash
    dotnet publish --configuration Release
    ```

- Run the published output:

    ```bash
    dotnet ./bin/Release/net8.0/publish/Timesheet.dll
    ```
- Create Executable :
   ```bash
    dotnet publish -r win-x64 -p:PublishSingleFile=True --self-contained false --output "C:\build\tm"
  ```

---

Happy coding! If you encounter any issues, feel free to create a [GitHub issue](https://github.com/yourusername/timesheet-backend/issues).
