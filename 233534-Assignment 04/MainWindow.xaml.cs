using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CricketTeamManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Players { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Players = new ObservableCollection<string>();

            // Bind ListBox to ObservableCollection
            PlayersListBox.ItemsSource = Players;
        }
        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            // Get player name from TextBox
            string playerName = PlayerNameTextBox.Text.Trim();

            // Validate if player name is not empty or duplicate
            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Please enter a valid player name.");
                return;
            }

            if (Players.Contains(playerName))
            {
                MessageBox.Show("This player is already in the roster.");
                return;
            }

            // Add player to ObservableCollection
            Players.Add(playerName);

            // Clear TextBox after adding player
            PlayerNameTextBox.Clear();

            // Show success message
            MessageBox.Show("Player added successfully!");
        }
        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected player from ListBox
            string selectedPlayer = PlayersListBox.SelectedItem as string;

            if (selectedPlayer == null)
            {
                MessageBox.Show("Please select a player to remove.");
                return;
            }

            // Remove player from ObservableCollection
            Players.Remove(selectedPlayer);

            // Show success message
            MessageBox.Show("Player removed successfully!");
        }
    }
}
