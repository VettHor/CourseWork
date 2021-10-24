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
            MainWindow._highwaysList.Sort();
            UpdateTable updateTable = new UpdateTable();
            updateTable.UpDateHighways(MainWindow._highwaysList);
        }
    }
}
