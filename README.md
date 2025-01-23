# Projekt Zaliczeniowy - Movie Management Application

## Table of Contents

1. [Project Overview](#project-overview)
2. [Features](#features)
3. [Technologies Used](#technologies-used)
4. [Setup and Installation](#setup-and-installation)
5. [Usage](#usage)

---

## Project Overview

This project is a **Movie Management Application** built using the Model-View-Controller (MVC) architecture in .NET. The purpose of this project is to implement a system for managing production companies, their movies, and associated keywords. The application includes user authentication.

The entire project is located in the `ProjektZaliczeniowy` folder. Users must navigate to this folder to access the main functionality.

---

## Features

1. **Production Company Management**:
   - View a paginated list of production companies.
   - Display details such as the number of movies produced and total budget.
2. **Movies Management**:
   - View a list of movies for a selected production company.
   - Display details such as title, popularity, revenue, runtime, votes, and associated keywords.
3. **Keyword Management**:
   - Add keywords to a movie.
   - View the list of associated keywords.
   - Only authenticated users can manage keywords.
4. **Authentication**:
   - Cookie-based login system for user authentication.
   - Only logged-in users can add keywords.
5. **Pagination**:
   - Paginated views for production companies.
   - Custom pagination logic implemented using `PagingListAsync`.

---

## Technologies Used

1. **Backend**: ASP.NET Core MVC
2. **Database**: SQLite
3. **Authentication**: Cookie-based login system
4. **Programming Language**: C#

---

## Setup and Installation

### Prerequisites

- .NET SDK (6.0 or later)
- Visual Studio or any C# IDE
- SQLite installed
- Download the `movies.db` database from [this link](https://github.com/bbrumm/databasestar/blob/main/sample_databases/sample_db_movies/sqlite/movies.db) and place it in `c:\data\movies.db` as specified in `appsettings.json`.

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/kacpersmaga/LaboratoriumASP.NET.git
   ```
2. Ensure you are on the `main` branch (the default branch).
3. Open the solution in Visual Studio.
4. Build the solution to restore NuGet packages.
5. Run the project:
   ```bash
   dotnet run
   ```

---

## Usage

1. Navigate to the `Production Companies` section to view all companies.
2. Click on the number of movies for a company to view its movies.
3. Logged-in users can manage keywords for a movie by clicking the **Add Keywords** button.
4. Unauthenticated users cannot manage keywords.

### Credentials

- **Test User**:
  - Username: `test`
  - Password: `password`

---

