using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace InventoryTracking
{
    public partial class PurchaseOrderPage : Page
    {
        public PurchaseOrderPage()
        {
            InitializeComponent();
        }

        // Sample Order class to bind to DataGrid
        public class Order
        {
            public int OrderID { get; set; }
            public string Supplier { get; set; }
            public string Product { get; set; }
            public int Quantity { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }
        }

        // Add Order Button click event
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Sample order data (this would come from user input in a real scenario)
            var newOrder = new Order
            {
                OrderID = 1, // Example order ID
                Supplier = SupplierComboBox.SelectedItem.ToString(), // Example supplier
                Product = ProductTextBox.Text, // Product from TextBox
                Quantity = int.TryParse(QuantityTextBox.Text, out var qty) ? qty : 0, // Quantity from TextBox
                OrderDate = OrderDatePicker.SelectedDate ?? DateTime.Now, // Order date from DatePicker
                Status = "Pending" // Default status
            };

            // Example: Add the new order to a list and set it to the DataGrid
            var orders = new List<Order> { newOrder };
            PurchaseOrderDataGrid.ItemsSource = orders;
        }

        // Mark as Received Button click event
        private void MarkAsReceivedButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for marking the selected order as received
            if (PurchaseOrderDataGrid.SelectedItem is Order selectedOrder)
            {
                selectedOrder.Status = "Received";
                PurchaseOrderDataGrid.Items.Refresh(); // Refresh the DataGrid to reflect changes
            }
        }

        // Delete Selected Order Button click event
        private void DeleteSelectedOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for deleting the selected order
            if (PurchaseOrderDataGrid.SelectedItem is Order selectedOrder)
            {
                // Remove the selected order from the collection
                var orders = (List<Order>)PurchaseOrderDataGrid.ItemsSource;
                orders.Remove(selectedOrder);
                PurchaseOrderDataGrid.Items.Refresh(); // Refresh the DataGrid to reflect changes
            }
        }
    }
}
