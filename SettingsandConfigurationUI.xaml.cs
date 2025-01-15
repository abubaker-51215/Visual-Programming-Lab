using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        // Event handler for editing role permissions
        private void EditRolePermissions_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the selected role from the ComboBox
            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please select a role to configure.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Simulate navigating to a role configuration page or performing related logic
            MessageBox.Show($"Configuring permissions for: {selectedRole}", "Role Configuration", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for saving the reorder threshold
        private void SaveThreshold_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the threshold value from the TextBox
            if (int.TryParse(ReorderThresholdTextBox.Text, out int threshold) && threshold > 0)
            {
                MessageBox.Show($"Reorder threshold of {threshold} has been saved.", "Threshold Saved", MessageBoxButton.OK, MessageBoxImage.Information);

                // Log the configuration change
                ConfigurationLogsTextBox.AppendText($"Reorder threshold updated to: {threshold}\n");
            }
            else
            {
                MessageBox.Show("Please enter a valid positive number for the threshold.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler for configuring system integrations
        private void ConfigureIntegration_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the selected integration type from the ComboBox
            var selectedIntegration = (IntegrationTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(selectedIntegration))
            {
                MessageBox.Show("Please select an integration type to configure.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Simulate configuring the selected integration
            MessageBox.Show($"Configuring: {selectedIntegration}", "Integration Configuration", MessageBoxButton.OK, MessageBoxImage.Information);

            // Log the configuration change
            ConfigurationLogsTextBox.AppendText($"Integration configured: {selectedIntegration}\n");
        }
    }
}
