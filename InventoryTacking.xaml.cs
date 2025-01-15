using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    public partial class InventoryTrackingPage : Page
    {
        // Observable collection for Stock Movements
        public ObservableCollection<StockMovement> StockMovements { get; set; }

        public InventoryTrackingPage()
        {
            InitializeComponent();
            StockMovements = new ObservableCollection<StockMovement>();
            StockMovementsDataGrid.ItemsSource = StockMovements;
            AddMovementButton.Click += AddMovementButton_Click;
        }

        // Button Click Event Handler to Add Stock Movement
        private void AddMovementButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check for empty fields
                if (string.IsNullOrWhiteSpace(ProductIDTextBox.Text) ||
                    string.IsNullOrWhiteSpace(QuantityTextBox.Text) ||
                    MovementTypeComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validate if Quantity is a valid integer
                if (!int.TryParse(QuantityTextBox.Text, out int quantity))
                {
                    MessageBox.Show("Please enter a valid numeric value for Quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Get the selected Movement Type from ComboBox
                var movementTypeContent = (MovementTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Parse the MovementType Enum safely
                if (Enum.TryParse<MovementTypeEnum>(movementTypeContent, out var movementType))
                {
                    var newMovement = new StockMovement
                    {
                        MovementID = Guid.NewGuid().ToString(),
                        ProductID = ProductIDTextBox.Text,
                        MovementType = movementType,  // Assign MovementType
                        Quantity = quantity,          // Assign Quantity
                        MovementDate = DateTime.Now,
                        Description = DescriptionTextBox.Text
                    };

                    // Add the new stock movement to the collection
                    StockMovements.Add(newMovement);

                    // Clear input fields after adding the movement
                    ProductIDTextBox.Clear();
                    QuantityTextBox.Clear();
                    DescriptionTextBox.Clear();
                    MovementTypeComboBox.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Invalid movement type selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("An error occurred while processing the data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    // Enum for Movement Types
    public enum MovementTypeEnum
    {
        IN,
        OUT,
        ADJUSTMENT
    }

    // Stock Movement Class
    public class StockMovement
    {
        public string MovementID { get; set; }
        public string ProductID { get; set; }
        public MovementTypeEnum MovementType { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
        public string Description { get; set; }
    }
}
