using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class IntegrationSettingsPage : UserControl
    {
        public IntegrationSettingsPage()
        {
            InitializeComponent();
        }

        // Event handler for the "Save API Key" button click
        private void SaveApiKey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve the API key from the TextBox
                string apiKey = (FindName("ApiKeyTextBox") as TextBox)?.Text;

                if (string.IsNullOrWhiteSpace(apiKey))
                {
                    MessageBox.Show("Please enter a valid API key.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Save the API key (this can be saved in a configuration file or database)
                // For demonstration, we just show a message
                MessageBox.Show("API key saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Optionally, clear the textbox after saving
                (FindName("ApiKeyTextBox") as TextBox)?.Clear();

                // Log the action
                LogAction("API key saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving API key: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for the "Sync Now" button click
        private void SyncNow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Simulate the sync process
                // This is where you can implement the actual sync logic (e.g., API call to sync data)
                DateTime lastSync = DateTime.Now;

                // Update the UI to show the last sync time
                TextBlock lastSyncTextBlock = (FindName("LastSyncTextBlock") as TextBlock);
                if (lastSyncTextBlock != null)
                {
                    lastSyncTextBlock.Text = $"Last Sync: {lastSync.ToString("MM/dd/yyyy, hh:mm tt")}";
                }

                // Log the sync event
                LogAction($"Sync completed at {lastSync.ToString("MM/dd/yyyy, hh:mm tt")}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error syncing: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to log integration actions
        private void LogAction(string logMessage)
        {
            // Create a new ListViewItem for the log message
            ListViewItem logItem = new ListViewItem
            {
                Content = $"{DateTime.Now:MM/dd/yyyy}: {logMessage}"
            };

            // Add the log item to the ListView
            IntegrationLogsListView.Items.Add(logItem);
        }
    }
}
