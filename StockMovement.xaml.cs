using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    // Renamed the StockMovement class to avoid conflict
    public partial class StockMovementPage : UserControl
    {
        private List<StockMovementPageEntry> stockMovements;

        public StockMovementPage()
        {
            InitializeComponent();
            stockMovements = new List<StockMovementPageEntry>();
            MovementHistoryListView.ItemsSource = stockMovements;
        }

        private void SubmitMovement_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (ProductComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MovementTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a movement type.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than 0.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var product = (ProductComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var movementType = (MovementTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var reason = ReasonTextBox.Text;

            var movement = new StockMovementPageEntry
            {
                Date = DateTime.Now,
                ProductName = product,
                MovementType = movementType,
                Quantity = quantity,
                Reason = reason
            };

            stockMovements.Add(movement);
            MovementHistoryListView.Items.Refresh();

            // Clear form
            ProductComboBox.SelectedIndex = -1;
            MovementTypeComboBox.SelectedIndex = -1;
            QuantityTextBox.Clear();
            ReasonTextBox.Clear();

            MessageBox.Show("Stock movement recorded successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    // Renamed class to avoid conflict
    public class StockMovementPageEntry
    {
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public string MovementType { get; set; }  // Ensure this doesn't conflict with any other class/enum
        public int Quantity { get; set; }
        public string Reason { get; set; }
    }
}
