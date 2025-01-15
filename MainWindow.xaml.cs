using System.Windows;
using InventoryApp.Views;

namespace InventoryApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Navigate to the DashboardPage when the MainWindow is loaded
            MainFrame.NavigationService.Navigate(new DashboardPage());
        }
    }
}
