using System.Windows.Controls;



namespace InventoryManagementSystem
{
    public partial class ReportsAndAnalytics : Page
    {
        public ReportsAndAnalytics()
        {
            InitializeComponent();
        }

        private void InventoryValuationButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Display the Inventory Valuation Report in the placeholder area
            ReportPlaceholderText.Text = "Displaying Inventory Valuation Report...";
        }

        private void StockMovementReportsButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Display the Stock Movement Report in the placeholder area
            ReportPlaceholderText.Text = "Displaying Stock Movement Reports...";
        }

        private void SalesReportsButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Display the Sales Report in the placeholder area
            ReportPlaceholderText.Text = "Displaying Sales Reports...";
        }
    }
}
