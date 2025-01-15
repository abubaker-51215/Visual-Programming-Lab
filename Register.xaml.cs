using InventoryApp.Helpers;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                txtMessage.Text = "Please enter both username and password.";
                return;
            }

            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();

                // Hash the password
                string hashedPassword = HashPassword(password);

                // Query to insert new user
                string query = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash)";

                // Parameters
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@PasswordHash", hashedPassword)
                };

                // Execute the query
                int rowsAffected = dbHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registration successful! Please log in.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();  // Close the Registration page

                    // Open the Login page
                    LoginPage loginPage = new LoginPage();
                    loginPage.Show();  // Show the Login page
                }
                else
                {
                    txtMessage.Text = "Registration failed. Please try again.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Implement the NavigateToLoginPage method
        private void NavigateToLoginPage(object sender, RoutedEventArgs e)
        {
            // Close the Registration page
            this.Close();

            // Navigate to the Login page
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }
    }
}
