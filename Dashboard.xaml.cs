using System.Windows;
using System.Windows.Controls;
using InventoryManagementSystem;
using InventoryTracking;

namespace InventoryApp.Views
{
    public partial class DashboardPage : Window
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        // Define navigation methods
        private void NavigateToProducts(object sender, RoutedEventArgs e)
        {
            var productPage = new ProductManagementPage(); // Correct page name
            MyFrame.Navigate(productPage); // Navigate using a Frame control
        }

        private void NavigateToSuppliers(object sender, RoutedEventArgs e)
        {
            var supplierPage = new SupplierManagementPage();
            MyFrame.Navigate(supplierPage); // Navigate using a Frame control
        }

        private void NavigateToSalesOrders(object sender, RoutedEventArgs e)
        {
            var salesOrderPage = new SalesOrderManagementPage();
            MyFrame.Navigate(salesOrderPage); // Navigate using a Frame control
        }

        private void NavigateToPurchaseOrders(object sender, RoutedEventArgs e)
        {
            var purchaseOrderPage = new PurchaseOrderPage(); // Updated class name
            MyFrame.Navigate(purchaseOrderPage); // Navigate using a Frame control
        }

        private void NavigateToReportsAndAnalytics(object sender, RoutedEventArgs e)
        {
            var reportsPage = new ReportsAndAnalytics(); // Updated class name
            MyFrame.Navigate(reportsPage); // Navigate using a Frame control
        }

        private void NavigateToCustomers(object sender, RoutedEventArgs e)
        {
            var customerPage = new CustomerManagementPage();
            MyFrame.Navigate(customerPage); // Navigate using a Frame control
        }

        private void NavigateToInventoryTracking(object sender, RoutedEventArgs e)
        {
            var inventoryTrackingPage = new InventoryTrackingPage();
            MyFrame.Navigate(inventoryTrackingPage); // Navigate using a Frame control
        }

        private void NavigateToSettings(object sender, RoutedEventArgs e)
        {
            var settingsPage = new SettingsPage();
            MyFrame.Navigate(settingsPage); // Navigate using a Frame control
        }

        private void NavigateToGoBack(object sender, RoutedEventArgs e)
        {
            var loginPage = new LoginPage();
            loginPage.ShowDialog(); 

            // Close DashboardPage after logout
            this.Close();
        }
    }
}
