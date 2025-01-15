using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace YourNamespace
{
    public partial class AuditLogsPage : Window
    {
        // Sample data for the DataGrid
        private List<AuditLog> AuditLogs;

        public AuditLogsPage()
        {
            InitializeComponent();
            LoadAuditLogs();
        }

        private void LoadAuditLogs()
        {
            // Sample data initialization for an inventory management system
            AuditLogs = new List<AuditLog>
            {
                new AuditLog { UserId = 1, Action = "Added New Item", Timestamp = DateTime.Now.AddHours(-2), AffectedModule = "Inventory" },
                new AuditLog { UserId = 2, Action = "Updated Stock", Timestamp = DateTime.Now.AddHours(-1), AffectedModule = "Warehouse" },
                new AuditLog { UserId = 3, Action = "Deleted Item", Timestamp = DateTime.Now.AddMinutes(-30), AffectedModule = "Inventory" },
                new AuditLog { UserId = 1, Action = "Generated Report", Timestamp = DateTime.Now.AddMinutes(-10), AffectedModule = "Reports" }
            };

            // Bind the DataGrid to the initial data
            AuditLogDataGrid.ItemsSource = AuditLogs;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string filterText = FilterTextBox.Text.ToLower();

            // Filter the data based on the input text
            var filteredLogs = AuditLogs.Where(log => log.Action.ToLower().Contains(filterText)).ToList();

            // Update the DataGrid's ItemsSource
            AuditLogDataGrid.ItemsSource = filteredLogs;

            // Show a message if no results are found
            if (!filteredLogs.Any())
            {
                MessageBox.Show("No matching records found.", "Filter Results", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

    // Define the AuditLog class for sample data
    public class AuditLog
    {
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public string AffectedModule { get; set; }
    }
}
