using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class SalesOrderManagementPage : Page
    {
        // ObservableCollection to bind SalesOrders ListView in XAML
        public ObservableCollection<SalesOrder> SalesOrders { get; set; }

        public SalesOrderManagementPage()
        {
            InitializeComponent();
            SalesOrders = new ObservableCollection<SalesOrder>();

            // Set the SalesOrders collection as the data source for the ListView
            SalesOrdersListView.ItemsSource = SalesOrders;
        }

        // Event handler to create a new order
        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Sample logic to add a new order
            var newOrder = new SalesOrder
            {
                OrderId = SalesOrders.Count + 1,
                CustomerName = "New Customer",
                OrderDate = DateTime.Now,
                TotalAmount = 100.00m,
                OrderStatus = "Pending"
            };
            SalesOrders.Add(newOrder);
        }

        // Event handler to update the selected order
        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = SalesOrdersListView.SelectedItem as SalesOrder;
            if (selectedOrder != null)
            {
                selectedOrder.OrderStatus = "Updated";
                // Refresh the ListView to reflect changes
                SalesOrdersListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select an order to update.");
            }
        }

        // Event handler to finalize the selected order
        private void FinalizeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = SalesOrdersListView.SelectedItem as SalesOrder;
            if (selectedOrder != null)
            {
                selectedOrder.OrderStatus = "Finalized";
                // Refresh the ListView to reflect changes
                SalesOrdersListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select an order to finalize.");
            }
        }
    }

    // SalesOrder class to define the order structure
    public class SalesOrder
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
    }
}
