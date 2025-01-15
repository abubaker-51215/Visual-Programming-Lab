using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class ProductManagementPage : Page
    {
        // Define the Product class
        public class Product
        {
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }
        }

        // ObservableCollection to store products
        public ObservableCollection<Product> Products { get; set; }

        public ProductManagementPage()
        {
            InitializeComponent();

            // Initialize the Products collection
            Products = new ObservableCollection<Product>();
            ProductsDataGrid.ItemsSource = Products; // Bind DataGrid to the collection
        }

        // Event handler for "Add Product" button click
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(ProductCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(CategoryTextBox.Text) ||
                string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(StockQuantityTextBox.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Price must be a positive number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(StockQuantityTextBox.Text, out int stockQuantity) || stockQuantity < 0)
            {
                MessageBox.Show("Stock Quantity must be a non-negative integer.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a new Product
            var newProduct = new Product
            {
                ProductCode = ProductCodeTextBox.Text,
                ProductName = ProductNameTextBox.Text,
                Category = CategoryTextBox.Text,
                Price = price,
                StockQuantity = stockQuantity
            };

            // Add the new product to the collection
            Products.Add(newProduct);

            ClearInputFields();
            MessageBox.Show("Product added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for "Delete Selected Product" button click
        private void DeleteSelectedProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
                MessageBox.Show("Selected product deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler for "Update Product" button click
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product selectedProduct)
            {
                // Update selected product details
                selectedProduct.ProductName = ProductNameTextBox.Text;
                selectedProduct.Category = CategoryTextBox.Text;
                selectedProduct.Price = decimal.Parse(PriceTextBox.Text);
                selectedProduct.StockQuantity = int.Parse(StockQuantityTextBox.Text);

                ProductsDataGrid.Items.Refresh(); // Refresh DataGrid to show changes
                MessageBox.Show("Product updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a product to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler for "Clear Inputs" button click
        private void ClearInputs_Click(object sender, RoutedEventArgs e)
        {
            ClearInputFields();
            MessageBox.Show("Input fields cleared.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Helper method to clear input fields
        private void ClearInputFields()
        {
            ProductNameTextBox.Clear();
            ProductCodeTextBox.Clear();
            CategoryTextBox.Clear();
            PriceTextBox.Clear();
            StockQuantityTextBox.Clear();
        }
    }
}
