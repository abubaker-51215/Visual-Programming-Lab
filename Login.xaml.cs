using System;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using InventoryApp.Helpers;
using InventoryApp.Views;

namespace InventoryApp.Views
{
    public partial class LoginPage : Window
    {
        public bool LoginSuccessful { get; private set; } // Indicate if login is successful

        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = GetPassword();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                txtMessage.Text = "Please enter both username and password.";
                return;
            }

            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();

                // Query to check if the user exists
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";

                // Hash the password
                string hashedPassword = HashPassword(password);

                // Parameters
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@PasswordHash", hashedPassword)
                };

                // Execute the query
                DataTable result = dbHelper.ExecuteQuery(query, parameters);
                int userCount = Convert.ToInt32(result.Rows[0][0]);

                if (userCount > 0)
                {
                    MessageBox.Show("Login successful!", "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoginSuccessful = true;  // Indicate successful login
                    OpenDashboard();         // Open the Dashboard page
                }
                else
                {
                    txtMessage.Text = "Invalid username or password.";
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

        private string GetPassword()
        {
            if (txtPasswordBox.Visibility == Visibility.Visible)
            {
                return txtPasswordBox.Password;
            }
            else
            {
                return txtPasswordTextBox.Text;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Clear();
            txtPasswordBox.Clear();
            txtPasswordTextBox.Clear();
            txtMessage.Text = "";
        }

        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPasswordBox.Visibility = Visibility.Collapsed;
            txtPasswordTextBox.Visibility = Visibility.Visible;
            txtPasswordTextBox.Text = txtPasswordBox.Password;
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPasswordBox.Visibility = Visibility.Visible;
            txtPasswordTextBox.Visibility = Visibility.Collapsed;
            txtPasswordBox.Password = txtPasswordTextBox.Text;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Open the RegistrationPage without closing the LoginPage
            var registrationPage = new RegistrationPage();
            registrationPage.Show();
        }

        private void OpenDashboard()
        {
            // Open the Dashboard window after a successful login
            var dashboardPage = new DashboardPage();
            dashboardPage.Show(); // Show DashboardPage
            this.Close(); // Close the LoginPage window
        }
    }
}
