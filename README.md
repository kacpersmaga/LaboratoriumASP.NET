### Project Description: .NET MVC Contact Management System

This project is a **.NET MVC-based web application** designed to manage contacts efficiently with role-based access control. The application uses **ASP.NET Identity** for authentication and authorization and SQLite as the database to store user and contact data locally.

---

### Features
#### User Roles:
1. **Administrator:**
   - Can log in and access additional features.
   - Add, edit, and delete contacts.
   - Manage organizational details linked to contacts.
2. **User:**
   - Can register, log in, and view contacts but cannot modify or delete them.

#### Functionalities:
- **Authentication & Authorization:** 
  - Role-based access implemented using `Identity`.
  - Predefined admin and user accounts with hashed passwords.
- **CRUD Operations for Contacts:**
  - Add new contacts with details like name, phone number, email, and organization.
  - Edit or delete existing contacts.
  - View detailed information about individual contacts.
- **Organizations Management:**
  - Contacts are linked to organizations.
  - Default organizational information is preloaded into the database.
- **Data Storage:**
  - Data is stored in a **local SQLite database**.

---

### Key Technologies
- **Backend:** ASP.NET MVC Framework
- **Frontend:** Razor Pages, HTML, CSS, Bootstrap (optional for styling)
- **Database:** SQLite
- **Authentication:** ASP.NET Identity
- **Dependency Injection:** Used for `IContactService` to provide flexibility between in-memory and EF-based services.

---

### Prerequisites
1. **Visual Studio** with .NET Core SDK installed.
2. **SQLite** support (built-in with .NET Core).
3. Basic knowledge of .NET Core MVC and EF Core.

---

### Setup Instructions
1. Clone the repository.
2. Build and restore dependencies via Visual Studio.
3. Update the database:
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Access the web app on `http://localhost:5000`.

---

### Preloaded Data
- **Admin Account:**
  - Username: `admin`
  - Email: `adam@wsei.edu.pl`
  - Password: `1234abcd!@#$ABCD`
- **User Account:**
  - Username: `user`
  - Email: `damian@wsei.edu.pl`
  - Password: `abcde1234!@#$ABCD`
- **Organizations:**
  - WSEI, Firma with predefined addresses and NIP/REGON numbers.
- **Sample Contacts:**
  - Adam Kowal and Ewa Kowal linked to respective organizations.

---
