using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace InventoryApp.Views
{
    public partial class ReorderAlertsPage : UserControl
    {
        // Constructor
        public ReorderAlertsPage()
        {
            InitializeComponent();
            LoadLowStockAlerts();
            LoadReorderSuggestions();
        }

        // Sample data for Low Stock Alerts
        private void LoadLowStockAlerts()
        {
            var lowStockAlerts = new List<LowStockAlert>
            {
                new LowStockAlert
                {
                    ProductName = "Product A",
                    CurrentStock = 5,
                    MinStockLevel = 10,
                    ReorderQuantity = 20,
                    Supplier = "Supplier A",
                    ReorderLink = "https://supplierA.com/reorder"
                },
                new LowStockAlert
                {
                    ProductName = "Product B",
                    CurrentStock = 3,
                    MinStockLevel = 10,
                    ReorderQuantity = 15,
                    Supplier = "Supplier B",
                    ReorderLink = "https://supplierB.com/reorder"
                }
            };

            LowStockListView.ItemsSource = lowStockAlerts;
        }

        // Sample data for Reorder Suggestions
        private void LoadReorderSuggestions()
        {
            var reorderSuggestions = new List<ReorderSuggestion>
            {
                new ReorderSuggestion
                {
                    ProductName = "Product A",
                    SuggestedQuantity = 30,
                    Supplier = "Supplier A",
                    OrderLink = "https://supplierA.com/order"
                },
                new ReorderSuggestion
                {
                    ProductName = "Product B",
                    SuggestedQuantity = 25,
                    Supplier = "Supplier B",
                    OrderLink = "https://supplierB.com/order"
                }
            };

            ReorderSuggestionsListView.ItemsSource = reorderSuggestions;
        }

        // Event handler for the Refresh button
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadLowStockAlerts();  // Reload data for low stock alerts
            LoadReorderSuggestions();  // Reload data for reorder suggestions
        }

        // Event handler for the Reorder button
        private void ReorderButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedLowStockItem = LowStockListView.SelectedItem as LowStockAlert;
            var selectedReorderSuggestion = ReorderSuggestionsListView.SelectedItem as ReorderSuggestion;

            if (selectedLowStockItem != null)
            {
                // Open the reorder link for Low Stock Alerts
                OpenReorderLink(selectedLowStockItem.ReorderLink);
            }
            else if (selectedReorderSuggestion != null)
            {
                // Open the order link for Reorder Suggestions
                OpenReorderLink(selectedReorderSuggestion.OrderLink);
            }
            else
            {
                MessageBox.Show("Please select an item to reorder.", "No item selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Helper method to open a URL in the default web browser
        private void OpenReorderLink(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error opening link: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    // Model for LowStockAlert
    public class LowStockAlert
    {
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
        public int MinStockLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public string Supplier { get; set; }
        public string ReorderLink { get; set; }
    }

    // Model for ReorderSuggestion
    public class ReorderSuggestion
    {
        public string ProductName { get; set; }
        public int SuggestedQuantity { get; set; }
        public string Supplier { get; set; }
        public string OrderLink { get; set; }
    }
}
