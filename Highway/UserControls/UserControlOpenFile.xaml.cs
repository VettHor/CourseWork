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
                if (MainWindow._highwaysList.ReadFile()) // try to read file
                {
                    UpdateTable updateTable = new UpdateTable(); // if true
                    updateTable.UpDateHighways(MainWindow._highwaysList); // update current table and print
                    MessageBox.Show(
                        "Successfully read data from file",
                        "Input information",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information); // successful message
                }
            }
            catch(System.FormatException formatException) // if error occured
            {
                MessageBox.Show(
                    formatException.Message,
                    "Wrong file format",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error); // message about what was wrong
            }
            catch(System.IO.IOException ioException) // if file is empty
            {
                MessageBox.Show(
                    ioException.Message,
                    "Wrong file format",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error); // message about empty list
            }
        }
    }
}
