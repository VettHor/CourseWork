using System.Windows;
using System.Windows.Controls;
using System;

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
            if(MainWindow._highwaysList.WriteToFile())
                MessageBox.Show(
                        "Successfully saved to file",
                        "Output information",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
        }
    }
}
