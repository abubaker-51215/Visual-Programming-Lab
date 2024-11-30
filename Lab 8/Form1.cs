using System;
using System.Configuration; // For accessing connection strings from config file
using System.Data; // For working with DataTables and data-binding
using System.Data.SqlClient; // For SQL Server connections
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        // Constructor for the Form1 class, initializes the form
        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for the Form Load event
        // Called when the form is loaded
        private void Form1_Load(object sender, EventArgs e)
        {
            // Call method to load data from database and display it on the DataGridView
            LoadCustomerData();
        }

        // Event handler for button1 click
        // Collects the data from user input and displays it in a MessageBox
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the customer input values from the form fields
            string name = textBox1.Text;
            string country = comboBox1.SelectedItem?.ToString();
            string gender = radioMale.Checked ? "Male" : "Female"; // Determine gender based on radio button selection
            string maritalStatus = radioButton3.Checked ? "Married" : "Unmarried"; // Determine marital status based on radio button selection
            string hobbies = "";

            // Collect hobbies if the checkboxes are checked
            if (checkBox1.Checked) hobbies += "Reading ";
            if (checkBox3.Checked) hobbies += "Writing";

            // Show the collected information in a MessageBox
            MessageBox.Show($"Name: {name}\nCountry: {country}\nGender: {gender}\nMarital Status: {maritalStatus}\nHobbies: {hobbies}");
        }

        // Event handler for btnAdd click
        // Adds a new customer to the database and reloads the customer data
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get the customer input values from the form fields
            string name = textBox1.Text;
            string country = comboBox1.SelectedItem?.ToString();
            string gender = radioMale.Checked ? "Male" : "Female"; // Determine gender based on radio button selection
            string maritalStatus = radioButton3.Checked ? "Married" : "Unmarried"; // Determine marital status based on radio button selection
            string hobbies = "";

            // Collect hobbies if the checkboxes are checked
            if (checkBox1.Checked) hobbies += "Reading ";
            if (checkBox3.Checked) hobbies += "Writing";

            // Insert the collected data into the database
            InsertDataIntoDatabase(name, country, gender, maritalStatus, hobbies);

            // Reload the customer data after insertion
            LoadCustomerData();
        }

        // Event handler for btnDelete click
        // Deletes a customer from the database based on their name
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            // If no name is entered, show a warning message
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter the name of the customer to delete.");
                return;
            }

            // Confirm the deletion with the user
            DialogResult result = MessageBox.Show($"Are you sure you want to delete customer '{name}'?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Delete the customer from the database
                DeleteDataFromDatabase(name);
                // Reload the customer data after deletion
                LoadCustomerData();
            }
        }

        // Event handler for btnUpdate click
        // Updates an existing customer in the database based on their name
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the customer input values from the form fields
            string name = textBox1.Text;
            string country = comboBox1.SelectedItem?.ToString();
            string gender = radioMale.Checked ? "Male" : "Female"; // Determine gender based on radio button selection
            string maritalStatus = radioButton3.Checked ? "Married" : "Unmarried"; // Determine marital status based on radio button selection
            string hobbies = "";

            // Collect hobbies if the checkboxes are checked
            if (checkBox1.Checked) hobbies += "Reading ";
            if (checkBox3.Checked) hobbies += "Writing";

            // Update the existing customer data in the database
            UpdateDataInDatabase(name, country, gender, maritalStatus, hobbies);

            // Reload the customer data after update
            LoadCustomerData();
        }

        // Method to load customer data from the database and display it in the DataGridView
        private void LoadCustomerData()
        {
            // Get the connection string from the app.config file
            string connectionString = ConfigurationManager.ConnectionStrings["DBConn"].ToString();

            // Create and open a new connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to fetch customer data from the database
                    string query = "SELECT CustomerName, Country, Gender, MaritalStatus, Hobbies FROM CustomerTable";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Create a DataTable to hold the data
                    DataTable customerTable = new DataTable();
                    // Fill the DataTable with data from the database
                    dataAdapter.Fill(customerTable);

                    // Bind the DataTable to the DataGridView
                    dtgCustomer.DataSource = customerTable;
                }
                catch (Exception ex)
                {
                    // Display error message if data loading fails
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        // Method to insert a new customer into the database
        private void InsertDataIntoDatabase(string name, string country, string gender, string maritalStatus, string hobbies)
        {
            // Get the connection string from the app.config file
            string connectionString = ConfigurationManager.ConnectionStrings["DBConn"].ToString();

            // Create and open a new connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to insert a new customer into the database
                    string commandText = "INSERT INTO CustomerTable (CustomerName, Country, Gender, MaritalStatus, Hobbies) " +
                                         "VALUES (@Name, @Country, @Gender, @MaritalStatus, @Hobbies)";

                    // Create a new SqlCommand to execute the insert query
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        // Add parameters to the SQL command to avoid SQL injection
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Country", country);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@MaritalStatus", maritalStatus);
                        command.Parameters.AddWithValue("@Hobbies", hobbies);

                        // Execute the SQL command to insert the data
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Display error message if insertion fails
                    MessageBox.Show("Error inserting data: " + ex.Message);
                }
            }
        }

        // Method to delete a customer from the database based on their name
        private void DeleteDataFromDatabase(string name)
        {
            // Get the connection string from the app.config file
            string connectionString = ConfigurationManager.ConnectionStrings["DBConn"].ToString();

            // Create and open a new connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to delete a customer from the database based on their name
                    string commandText = "DELETE FROM CustomerTable WHERE CustomerName = @Name";

                    // Create a new SqlCommand to execute the delete query
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        // Add parameters to the SQL command to avoid SQL injection
                        command.Parameters.AddWithValue("@Name", name);

                        // Execute the SQL command to delete the customer
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Display error message if deletion fails
                    MessageBox.Show("Error deleting data: " + ex.Message);
                }
            }
        }

        // Method to update an existing customer in the database based on their name
        private void UpdateDataInDatabase(string name, string country, string gender, string maritalStatus, string hobbies)
        {
            // Get the connection string from the app.config file
            string connectionString = ConfigurationManager.ConnectionStrings["DBConn"].ToString();

            // Create and open a new connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to update customer data in the database
                    string commandText = "UPDATE CustomerTable SET Country = @Country, Gender = @Gender, " +
                                         "MaritalStatus = @MaritalStatus, Hobbies = @Hobbies WHERE CustomerName = @Name";

                    // Create a new SqlCommand to execute the update query
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        // Add parameters to the SQL command to avoid SQL injection
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Country", country);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@MaritalStatus", maritalStatus);
                        command.Parameters.AddWithValue("@Hobbies", hobbies);

                        // Execute the SQL command to update the data
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Display error message if update fails
                    MessageBox.Show("Error updating data: " + ex.Message);
                }
            }
        }
    }
}
