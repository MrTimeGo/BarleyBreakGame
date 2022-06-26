using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BarleyBreakGameInterface.View
{
    /// <summary>
    /// Interaction logic for PlayerNameDialog.xaml
    /// </summary>
    public partial class PlayerNameDialog : Window
    {
        public string PlayerName { get; set; }

        public PlayerNameDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerNameTextBox.Text))
            {
                MessageBox.Show("Player name shouldn't be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            PlayerName = PlayerNameTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
