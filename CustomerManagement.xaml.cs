using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class CustomerManagementPage : Page
    {
        // ObservableCollection to hold customer and order data
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        public CustomerManagementPage()
        {
            InitializeComponent();

            // Initialize collections
            Customers = new ObservableCollection<Customer>();
            Orders = new ObservableCollection<Order>();

            // Set the DataContext for the ListView (Order History)
            OrderHistoryListView.ItemsSource = Orders;

            // Bind buttons to click event handlers
            AddButton.Click += AddButton_Click;
            RemoveButton.Click += RemoveButton_Click;
            ClearButton.Click += ClearButton_Click;
        }

        // Add Button Click Handler
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string customerName = CustomerNameTextBox.Text;
            string customerAddress = CustomerAddressTextBox.Text;
            string customerPhone = CustomerPhoneNumberTextBox.Text;
            string customerEmail = CustomerEmailTextBox.Text;
            string customerType = (CustomerTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Validation
            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerAddress))
            {
                MessageBox.Show("Please fill in all customer details.");
                return;
            }

            // Create a new customer and add to the collection
            var newCustomer = new Customer
            {
                Name = customerName,
                Address = customerAddress,
                PhoneNumber = customerPhone,
                Email = customerEmail,
                CustomerType = customerType
            };

            Customers.Add(newCustomer);

            // Simulate adding an order for this customer
            var newOrder = new Order
            {
                OrderDate = DateTime.Now,
                OrderID = Guid.NewGuid().ToString(),
                TotalAmount = 100.00,
                OrderStatus = "Pending"
            };

            Orders.Add(newOrder);

            MessageBox.Show($"Customer {customerName} added successfully!");
        }

        // Remove Button Click Handler
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string customerName = CustomerNameTextBox.Text;

            // Find customer by name
            var customerToRemove = Customers.FirstOrDefault(c => c.Name == customerName);

            if (customerToRemove != null)
            {
                Customers.Remove(customerToRemove);

                // Also remove related orders if necessary
                var relatedOrders = Orders.Where(o => o.OrderID == customerToRemove.Name).ToList();
                foreach (var order in relatedOrders)
                {
                    Orders.Remove(order);
                }

                MessageBox.Show($"Customer {customerName} and their orders have been removed.");
            }
            else
            {
                MessageBox.Show($"Customer {customerName} not found.");
            }
        }

        // Clear Button Click Handler
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear all fields
            CustomerNameTextBox.Clear();
            CustomerAddressTextBox.Clear();
            CustomerPhoneNumberTextBox.Clear();
            CustomerEmailTextBox.Clear();
            CustomerTypeComboBox.SelectedIndex = -1;
        }
    }

    // Customer class to hold customer data
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CustomerType { get; set; }
    }

    // Order class to hold order data
    public class Order
    {
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public string OrderStatus { get; set; }
    }
}
