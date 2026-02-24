# Backend_Exam_Project

Dummy credentials (for testing only):

- Email: `raj@gmail.com`
- Password: `raj@123`

Author: Pirt Kanani
Enrollment no.: 23010101126

Getting started — clone and run a simple EF Core migration

1. Clone the repository:

   ```powershell
   git clone <repository-url>
   cd Backend_Exam_Project
   ```

2. Ensure the connection string in `appsettings.json` is correct for your SQL Server instance (key name: `myConnectionString`).

3. Restore and build:

   ```powershell
   dotnet restore
   dotnet build
   ```

4. Create and apply a migration (CLI):

   ```powershell
   dotnet tool restore
   dotnet ef migrations add InitialMigration --project Backend_Exam_Project --startup-project Backend_Exam_Project
   dotnet ef database update --project Backend_Exam_Project --startup-project Backend_Exam_Project
   ```

   Or from Visual Studio Package Manager Console (set Default project to `Backend_Exam_Project`):

   ```powershell
   Add-Migration InitialMigration
   Update-Database
   ```

Notes:

- If you encounter an error about loading the assembly (AppLocker/WDAC), try unblocking files, running Visual Studio as Administrator, or moving the project to a non-restricted folder.
- If EF tools cannot create the `AppDbContext`, add a design-time factory implementing `IDesignTimeDbContextFactory<AppDbContext>`.
- Use secrets or environment variables to store real JWT keys and database credentials; do not commit secrets to source control.

That's it — these steps create the database schema from the current models and apply the CHECK constraints and defaults configured in the `AppDbContext`.