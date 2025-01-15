using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class BarcodeScanningPage : UserControl
    {
        public BarcodeScanningPage()
        {
            InitializeComponent();
        }

        // Event handler for looking up a product by barcode
        private void LookupProduct_Click(object sender, RoutedEventArgs e)
        {
            string barcode = BarcodeTextBox.Text;

            if (string.IsNullOrWhiteSpace(barcode))
            {
                MessageBox.Show("Please enter a valid barcode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Simulate product lookup (replace with actual logic to fetch product details from a database or API)
            var product = MockDatabase.GetProductByBarcode(barcode);

            if (product != null)
            {
                ProductNameTextBlock.Text = product.Name;
                CurrentStockTextBlock.Text = product.Stock.ToString();
            }
            else
            {
                MessageBox.Show("Product not found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                ProductNameTextBlock.Text = "(Product Name will appear here)";
                CurrentStockTextBlock.Text = "(Stock details will appear here)";
            }
        }

        // Event handler for adding stock
        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(UpdateStockTextBox.Text, out int quantity) && quantity > 0)
            {
                string productName = ProductNameTextBlock.Text;
                if (productName == "(Product Name will appear here)")
                {
                    MessageBox.Show("No product selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Simulate adding stock (replace with actual logic)
                bool success = MockDatabase.UpdateStock(productName, quantity);
                if (success)
                {
                    MessageBox.Show($"Successfully added {quantity} units to stock.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Update stock display
                    CurrentStockTextBlock.Text = MockDatabase.GetProductByName(productName)?.Stock.ToString() ?? "0";
                }
                else
                {
                    MessageBox.Show("Failed to add stock.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid positive number for stock quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for removing stock
        private void RemoveStock_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(UpdateStockTextBox.Text, out int quantity) && quantity > 0)
            {
                string productName = ProductNameTextBlock.Text;
                if (productName == "(Product Name will appear here)")
                {
                    MessageBox.Show("No product selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Simulate removing stock (replace with actual logic)
                bool success = MockDatabase.UpdateStock(productName, -quantity);
                if (success)
                {
                    MessageBox.Show($"Successfully removed {quantity} units from stock.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Update stock display
                    CurrentStockTextBlock.Text = MockDatabase.GetProductByName(productName)?.Stock.ToString() ?? "0";
                }
                else
                {
                    MessageBox.Show("Insufficient stock to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid positive number for stock quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    // Mock database for demonstration purposes
    public static class MockDatabase
    {
        private static readonly Dictionary<string, Product> Products = new Dictionary<string, Product>
        {
            { "123456", new Product { Name = "Product A", Stock = 50 } },
            { "789012", new Product { Name = "Product B", Stock = 30 } },
        };

        public static Product GetProductByBarcode(string barcode)
        {
            Products.TryGetValue(barcode, out var product);
            return product;
        }

        public static Product GetProductByName(string name)
        {
            return Products.Values.FirstOrDefault(p => p.Name == name);
        }

        public static bool UpdateStock(string productName, int quantity)
        {
            var product = GetProductByName(productName);
            if (product != null && product.Stock + quantity >= 0)
            {
                product.Stock += quantity;
                return true;
            }

            return false;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }
}
