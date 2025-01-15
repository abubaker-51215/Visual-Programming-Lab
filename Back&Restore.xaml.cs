using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace InventoryApp.Views
{
    public partial class BackupAndRestorePage : UserControl
    {
        private string backupDirectory = "C:\\InventoryBackups"; // Default backup directory

        public BackupAndRestorePage()
        {
            InitializeComponent();
            EnsureBackupDirectoryExists();
        }

        // Ensure the backup directory exists
        private void EnsureBackupDirectoryExists()
        {
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }
        }

        // Event handler for creating a backup
        private void CreateBackup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string backupFile = Path.Combine(backupDirectory, $"InventoryBackup_{DateTime.Now:yyyyMMdd_HHmmss}.bak");

                // Simulate backup creation (replace with actual backup logic)
                File.WriteAllText(backupFile, "Backup data content here...");

                MessageBox.Show($"Backup created successfully at: {backupFile}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create backup. Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for restoring a backup
        private void RestoreBackup_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*",
                InitialDirectory = backupDirectory
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string selectedFile = openFileDialog.FileName;

                    // Simulate restore operation (replace with actual restore logic)
                    string backupContent = File.ReadAllText(selectedFile);

                    MessageBox.Show($"Backup restored successfully from: {selectedFile}\nContent: {backupContent}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to restore backup. Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
