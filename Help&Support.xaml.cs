using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;

namespace InventoryApp.Views
{
    public partial class HelpAndSupportPage : UserControl
    {
        public HelpAndSupportPage()
        {
            InitializeComponent();
        }

        // Event handler for the "Download" button click
        private void DownloadManual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Provide the file path of the user manual (you can customize this)
                string manualFilePath = @"C:\path\to\your\user_manual.pdf"; // Modify this path

                if (File.Exists(manualFilePath))
                {
                    // Open the file using the default PDF viewer
                    Process.Start(new ProcessStartInfo(manualFilePath) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show("User manual not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening the manual: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for the "Submit Request" button click
        private void SubmitSupportRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string issueDescription = (FindName("IssueDescriptionTextBox") as TextBox)?.Text;

                if (string.IsNullOrWhiteSpace(issueDescription))
                {
                    MessageBox.Show("Please describe the issue before submitting.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Logic to submit the request (e.g., save to a database or send an email)
                // For now, we'll just show a confirmation message
                MessageBox.Show("Your support request has been submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Optionally, clear the text box after submitting
                (FindName("IssueDescriptionTextBox") as TextBox)?.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting support request: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
