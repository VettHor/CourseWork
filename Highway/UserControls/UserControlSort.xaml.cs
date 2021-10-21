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
        UpdateTable updateTable;
        public UserControlSort()
        {
            InitializeComponent();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.highwaysList.Sort();
            updateTable = new UpdateTable();
            updateTable.UpDateHighways(MainWindow.highwaysList);
        }
    }
}
