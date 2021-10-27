using System.Windows;
using System.Windows.Controls;

namespace Highway.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSaveToFile.xaml
    /// </summary>
    public partial class UserControlSaveToFile : UserControl
    {
        public UserControlSaveToFile()
        {
            InitializeComponent();
        }

        private void SaveToFileAllRoads_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow._highwaysList.WriteToFile()) // if saving was approved
                MessageBox.Show(
                        "Successfully saved to file",
                        "Output information",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information); // print message about success
        }
    }
}
