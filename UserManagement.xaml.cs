using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class UserManagementPage : UserControl
    {
        // Sample data for users
        private List<User> Users = new List<User>();
        private List<ActivityLog> ActivityLogs = new List<ActivityLog>();

        public UserManagementPage()
        {
            InitializeComponent();
            LoadSampleData();
            UpdateUserListView();
            UpdateActivityLogListView();
        }

        private void LoadSampleData()
        {
            Users.Add(new User { UserName = "Admin", Role = "Administrator", Status = "Active" });
            Users.Add(new User { UserName = "JohnDoe", Role = "Editor", Status = "Active" });
            ActivityLogs.Add(new ActivityLog { UserName = "Admin", Activity = "Logged in", Date = DateTime.Now });
        }

        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User { UserName = $"User{Users.Count + 1}", Role = "Viewer", Status = "Active" };
            Users.Add(newUser);
            ActivityLogs.Add(new ActivityLog { UserName = newUser.UserName, Activity = "Added user", Date = DateTime.Now });
            UpdateUserListView();
            UpdateActivityLogListView();
            MessageBox.Show($"New user '{newUser.UserName}' added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var user = button?.DataContext as User;

            if (user != null)
            {
                user.Role = user.Role == "Viewer" ? "Editor" : "Viewer"; // Example edit: Toggle role
                ActivityLogs.Add(new ActivityLog { UserName = user.UserName, Activity = "Edited user", Date = DateTime.Now });
                UpdateUserListView();
                UpdateActivityLogListView();
                MessageBox.Show($"User '{user.UserName}' updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var user = button?.DataContext as User;

            if (user != null)
            {
                Users.Remove(user);
                ActivityLogs.Add(new ActivityLog { UserName = user.UserName, Activity = "Deleted user", Date = DateTime.Now });
                UpdateUserListView();
                UpdateActivityLogListView();
                MessageBox.Show($"User '{user.UserName}' deleted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void UpdateUserListView()
        {
            UserListView.ItemsSource = null;
            UserListView.ItemsSource = Users;
        }

        private void UpdateActivityLogListView()
        {
            ActivityLogListView.ItemsSource = null;
            ActivityLogListView.ItemsSource = ActivityLogs;
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }

    public class ActivityLog
    {
        public string UserName { get; set; }
        public string Activity { get; set; }
        public DateTime Date { get; set; }
    }
}
