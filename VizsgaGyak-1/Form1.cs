using CsvHelper;
using System.Globalization;
using System.IO;
using MySql.Data.MySqlClient;

namespace VizsgaGyak_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Load students from the database and display them in the DataGridView on form load
            LoadStudentsToDataGridView();
        }

        // In-memory list to hold students loaded from CSV
        private List<Student> students = new List<Student>();

        // MySQL connection string (adjust as needed for your environment)
        private string connectionString = "server=localhost;database=school;port=3307;user=root;password=;";

        // Handles CSV file selection and loading
        private void buttonChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    using (var rdr = new StreamReader(filePath))
                    {
                        var header = rdr.ReadLine(); // Skip header row
                        string line = string.Empty;
                        while ((line = rdr.ReadLine()) != null)
                        {
                            var cols = line.Split(',');
                            // Ensure the line has exactly 4 columns
                            if (cols.Length == 4)
                            {
                                // Parse Id and Age, and add to the students list if valid
                                if (int.TryParse(cols[0], out int id) && int.TryParse(cols[3], out int age))
                                {
                                    string name = cols[1];
                                    string email = cols[2];
                                    students.Add(new Student(id, name, email, age));
                                }
                            }
                        }
                    }
                    MessageBox.Show("CSV file loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Handles saving loaded students to the MySQL database
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No students loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Create the students table if it doesn't exist
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS students (
                            Id INT PRIMARY KEY,
                            Name VARCHAR(100),
                            Email VARCHAR(100),
                            Age INT
                        );";
                    using (var cmd = new MySqlCommand(createTableQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Insert or update each student in the database
                    foreach (var student in students)
                    {
                        string insertQuery = @"
                            INSERT INTO students (Id, Name, Email, Age)
                            VALUES (@Id, @Name, @Email, @Age)
                            ON DUPLICATE KEY UPDATE
                                Name = @Name,
                                Email = @Email,
                                Age = @Age;";
                        using (var cmd = new MySqlCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", student.Id);
                            cmd.Parameters.AddWithValue("@Name", student.Name);
                            cmd.Parameters.AddWithValue("@Email", student.Email);
                            cmd.Parameters.AddWithValue("@Age", student.Age);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Students saved to database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh the DataGridView to show the latest data
                LoadStudentsToDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Loads students from the database and displays them in the DataGridView
        private void LoadStudentsToDataGridView()
        {
            var db = new List<Student>();
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Name, Email, Age FROM students;";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            db.Add(new Student(
                                rdr.GetInt32("Id"),
                                rdr.GetString("Name"),
                                rdr.GetString("Email"),
                                rdr.GetInt32("Age")
                            ));
                        }
                    }
                }
                // Bind the list to the DataGridView
                dataGridViewStudents.DataSource = db;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handles registration of a new student from the form fields
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string ageText = textBoxAge.Text.Trim();

            // Validate input fields
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(ageText))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ageText, out int age) || age < 0)
            {
                MessageBox.Show("Please enter a valid age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the next available Id for the new student
                    int newId = 1;
                    string getMaxIdQuery = "SELECT IFNULL(MAX(Id), 0) + 1 FROM students;";
                    using (var cmd = new MySqlCommand(getMaxIdQuery, connection))
                    {
                        newId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Insert the new student into the database
                    string insertQuery = @"
                        INSERT INTO students (Id, Name, Email, Age)
                        VALUES (@Id, @Name, @Email, @Age);";
                    using (var cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", newId);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Student registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear input fields after successful registration
                textBoxName.Clear();
                textBoxEmail.Clear();
                textBoxAge.Clear();

                // Refresh the DataGridView to show the new student
                LoadStudentsToDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
