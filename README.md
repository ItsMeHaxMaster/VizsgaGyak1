# VizsgaGyak-1 - Student Management Windows Forms Application

## Overview

VizsgaGyak-1 is a Windows Forms application written in C# (.NET 9) that allows you to manage student data. The application supports:
- Importing student data from a CSV file
- Storing and updating student records in a MySQL database
- Displaying students in a DataGridView
- Registering new students via a form

## Features

- **CSV Import:** Load students from a CSV file with columns: `Id,Name,Email,Age`.
- **MySQL Integration:** Save and update student records in a MySQL database.
- **DataGridView Display:** View all students in a sortable, filterable grid.
- **Registration Form:** Add new students using a simple form.
- **Error Handling:** User-friendly error messages for invalid input or database issues.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- Visual Studio 2022 or newer
- NuGet packages:
  - `MySql.Data`
  - `CsvHelper`

## Setup

1. **Clone the repository** and open the solution in Visual Studio.
2. **Install NuGet packages** via the NuGet Package Manager:
   - `MySql.Data`
   - `CsvHelper`
3. **Configure the MySQL connection string** in `Form1.cs`:

    ```
    private string connectionString = "server=localhost;database=school;port=3307;user=root;password=;";
    ```

   Adjust `server`, `database`, `port`, `user`, and `password` as needed for your environment.

4. **Ensure the MySQL database exists:**
   - Create a database named `school` (or your chosen name) in your MySQL server.

5. **Build and run the application.**

## Usage

1. **Import Students from CSV:**
   - Click the "Choose" button and select a CSV file with the following format:

    ```
    Id,Name,Email,Age
    1,Alice,alice@example.com,20
    2,Bob,bob@example.com,22
    ```

    - After loading, click "Load" to save the students to the database.

2. **View Students:**
   - All students in the database are displayed in the DataGridView.

3. **Register a New Student:**
   - Enter the student's name, email, and age in the form fields.
   - Click "Register" to add the student to the database and refresh the view.

## Notes

- The application creates the `students` table automatically if it does not exist.
- Duplicate `Id` values in the CSV will update existing records in the database.
- Basic validation is performed for empty fields and age input.

## Troubleshooting

- **Database connection errors:** Check your MySQL server is running and the connection string is correct.
- **CSV import errors:** Ensure your CSV file matches the required format and encoding (UTF-8 recommended).

## License

This project is for educational purposes.
