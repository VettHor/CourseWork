using System.Windows;
using System.Windows.Controls;
using System.Data;
using Highway.Models;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Highway.UserControls;

namespace Highway
{
    /// <summary>
    /// Interaction logic for HighwayTable.xaml
    /// </summary>
    public partial class HighwayTable : UserControl
    { 
        readonly UpdateTable UpdateTable;
        public HighwayTable()
        {
            InitializeComponent();
            UpdateTable = new UpdateTable();
            UpdateTable.HighWaysFill += onTableUpdate;
        }

        private void onTableUpdate(HighwayList list)
        {
            if (list.GetCurrentLength == 0) // if list is empty
            {
                RoadTable.ItemsSource = null; // empty source
                RoadTable.Items.Clear(); // and clear all table
                return;
            }
            DataTable dataTable = new DataTable(); // create datagrid
            dataTable.Columns.Add(new DataColumn("№", typeof(int))); // create dataTable to keep info about all roads
            dataTable.Columns.Add(new DataColumn("Name", typeof(string))); // create column headers
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Length, km", typeof(double)));
            dataTable.Columns.Add(new DataColumn("Lanes", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Banquette", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Separator", typeof(string)));
            DataRow rows; HighWay highway;
            int listLength = list.GetCurrentLength;
            for (int i = 0; i < listLength; ++i)
            {
                rows = dataTable.NewRow(); // create empty row
                highway = list[i];
                rows[0] = i + 1; // push number of road
                rows[1] = highway.NameHighway; // push road name
                rows[2] = highway.RoadType; // push road type
                rows[3] = highway.RoadLength; // push road length
                rows[4] = highway.NumberLanes; // push number lanes
                rows[5] = highway.Banquette; // push road banquette
                rows[6] = highway.RoadSeparator; // push road separator
                dataTable.Rows.Add(rows); // add current row to the datable
            }
            RoadTable.ItemsSource = dataTable.DefaultView;  // initialize RoadTable with dataTable
            foreach (var column in RoadTable.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star); // set length between columns
            }
            RoadTable.Columns[0].Width = new DataGridLength(0.6, DataGridLengthUnitType.Star);
            RoadTable.Columns[1].Width = new DataGridLength(1.5, DataGridLengthUnitType.Star);
            RoadTable.CanUserAddRows = false; // set properties
            RoadTable.CanUserDeleteRows = false;
            RoadTable.IsReadOnly = true;
            RoadTable.CanUserResizeColumns = false;
            RoadTable.CanUserResizeRows = false;
            RoadTable.CanUserReorderColumns = false;
        }

        private void AddRoadToTable_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window // open new window 
            {
                Title = "Add road to the table",
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };

            Grid DynamicGrid = new Grid(); // create dynamic grid
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left; // set alignment
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true; // set properties
            DynamicGrid.Background = new SolidColorBrush(Colors.White); // background color
            DynamicGrid.Children.Add(new UserControlAddRoadToList(window)); // push on it panel to enter data

            window.Content = DynamicGrid; // set content of window
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen; // location
            window.Icon = new BitmapImage(new Uri(@"C:\Users\VETAL\Desktop\Course_Work\Highway\Assets\road.png")); // image header
            window.ShowDialog(); // print window
        }

        private void DeleteRoadTable_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow._highwaysList.GetCurrentLength == 0) // if it is already empty
            {
                MessageBox.Show(
                        "The HighwayTable is empty, cannot delete",
                        "Warning",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning); // print warning message
                return;
            }
            if (MessageBox.Show(
                        String.Format($"Are you sure to delete HighwayTable with {HighWay.CountRoads} roads? You cannot turn it back"),
                        "Delete HighwayTable",
                        MessageBoxButton.YesNoCancel,
                        MessageBoxImage.Question) == MessageBoxResult.Yes) // ask user if he is sure to delete list
            {
                MainWindow._highwaysList.ClearList(); // delete list
                UpdateTable updateTable = new UpdateTable();
                updateTable.UpDateHighways(MainWindow._highwaysList); // update current table
                MessageBox.Show(
                            "Successfully deleted HigwayTable",
                            "Information",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information); // print about success
            }
        }
    }
}
