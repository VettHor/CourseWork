using System.Windows;
using System.Windows.Controls;
using Highway.Models;

namespace Highway.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlOpenFilexaml.xaml
    /// </summary>
    public partial class UserControlOpenFile : UserControl
    {
        public UserControlOpenFile()
        {
            InitializeComponent();
        }

        private void OpenRoadsFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow._highwaysList.ReadFile())
                {
                    _updateTable _updateTable = new _updateTable();
                    _updateTable.UpDateHighways(MainWindow._highwaysList);
                    MessageBox.Show(
                        "Successfully read data from file",
                        "Input information",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch(System.FormatException formatException)
            {
                MessageBox.Show(
                    formatException.Message,
                    "Wrong file format",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch(System.IO.IOException ioException)
            {
                MessageBox.Show(
                    ioException.Message,
                    "Wrong file format",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
