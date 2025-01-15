using System.Windows;
using InventoryApp.Views;

namespace InventoryApp
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var loginPage = new LoginPage();
            loginPage.ShowDialog(); // Show LoginPage as a modal

            // Only proceed if login is successful
            if (loginPage.LoginSuccessful)
            {
                var dashboardPage = new DashboardPage();
                dashboardPage.Show(); // Directly show DashboardPage after login
            }
            else
            {
                Shutdown(); // Shut down if login failed or cancelled
            }
        }
    }
}
