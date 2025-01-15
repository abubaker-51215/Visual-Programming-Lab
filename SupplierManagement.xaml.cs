using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class SupplierManagementPage : Page
    {
        // ObservableCollection for binding to ListView
        public ObservableCollection<Supplier> Suppliers { get; set; }

        public SupplierManagementPage()
        {
            InitializeComponent();

            Suppliers = new ObservableCollection<Supplier>(); // Initialize collection
            DataContext = this; // Set DataContext for data binding
        }

        // Event handler for ListView SelectionChanged
        private void OrderHistoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderHistoryListView.SelectedItem is Supplier selectedSupplier)
            {
                MessageBox.Show($"Selected Supplier: {selectedSupplier.Name}");
            }
        }

        // Add Supplier button click event
        private void AddSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            string supplierName = SupplierNameTextBox.Text;
            string supplierContact = SupplierContactTextBox.Text;
            string supplierAddress = SupplierAddressTextBox.Text;
            string supplierEmail = SupplierEmailTextBox.Text;
            string supplierRating = (SupplierRatingComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(supplierName) || string.IsNullOrEmpty(supplierAddress))
            {
                MessageBox.Show("Please fill in all supplier details.");
                return;
            }

            var newSupplier = new Supplier
            {
                Name = supplierName,
                Contact = supplierContact,
                Address = supplierAddress,
                Email = supplierEmail,
                Rating = supplierRating
            };

            Suppliers.Add(newSupplier); // Add supplier to the collection
            MessageBox.Show($"Supplier {supplierName} added successfully!");
        }

        // Update Supplier button click event
        private void UpdateSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            string supplierName = SupplierNameTextBox.Text;
            var supplierToUpdate = Suppliers.FirstOrDefault(s => s.Name.Equals(supplierName, StringComparison.OrdinalIgnoreCase));

            if (supplierToUpdate != null)
            {
                supplierToUpdate.Contact = SupplierContactTextBox.Text;
                supplierToUpdate.Address = SupplierAddressTextBox.Text;
                supplierToUpdate.Email = SupplierEmailTextBox.Text;
                supplierToUpdate.Rating = (SupplierRatingComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                MessageBox.Show($"Supplier {supplierName} updated successfully!");
            }
            else
            {
                MessageBox.Show($"Supplier {supplierName} not found.");
            }
        }

        // Delete Supplier button click event
        private void DeleteSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            string supplierName = SupplierNameTextBox.Text;
            var supplierToRemove = Suppliers.FirstOrDefault(s => s.Name.Equals(supplierName, StringComparison.OrdinalIgnoreCase));

            if (supplierToRemove != null)
            {
                Suppliers.Remove(supplierToRemove);
                MessageBox.Show($"Supplier {supplierName} deleted successfully!");
            }
            else
            {
                MessageBox.Show($"Supplier {supplierName} not found.");
            }
        }

        // Clear Fields button click event
        private void ClearFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            SupplierNameTextBox.Clear();
            SupplierContactTextBox.Clear();
            SupplierAddressTextBox.Clear();
            SupplierEmailTextBox.Clear();
            SupplierRatingComboBox.SelectedIndex = -1;
        }
    }

    // Supplier class
    public class Supplier
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Rating { get; set; }
    }
}
