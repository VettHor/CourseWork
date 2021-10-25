using System.Windows;
using System.Windows.Controls;
using Highway.Models;

namespace Highway.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSort.xaml
    /// </summary>
    public partial class UserControlSort : UserControl
    {
        public UserControlSort()
        {
            InitializeComponent();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow._highwaysList.GetCurrentLength() == 0)
            {
                MessageBox.Show(
                            "Cannot sort empty HigwayTable",
                            "Sort information",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                return;
            }
            MainWindow._highwaysList.Sort();
            UpdateTable UpdateTable = new UpdateTable();
            UpdateTable.UpDateHighways(MainWindow._highwaysList);
        }
    }
}
