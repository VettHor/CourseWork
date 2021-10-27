using System.Windows;
using System.Windows.Controls;
using Highway.Models;
using System.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;

namespace Highway.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlRegionalRoads.xaml
    /// </summary>
    public partial class UserControlRegionalRoads : UserControl
    {
        public UserControlRegionalRoads()
        {
            InitializeComponent();
        }

        private void FindRegionalRoadsMostLanesCrosswalkAvailable_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow._highwaysList.GetCurrentLength == 0) // if list is empty
            {
                MessageBox.Show(
                    "Cannot find roads in HigwayTable, it is empty",
                    "Find information",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning); // print warning and leave function
                return;
            }
            // initialize list to print
            HighwayList regionalRoadsList = MainWindow._highwaysList.FindRegionalRoadsMostLanesCrosswalkAvailable();
            if (regionalRoadsList.GetCurrentLength == 0) // if its length is zero
            {
                MessageBox.Show(
                    "There is no such roads",
                    "Find information",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return; // print information about no having such roads
            }

            Grid DynamicGrid = new Grid(); // grid where datagrid will be set
            DynamicGrid.Width = double.NaN; // arbitrary width
            DynamicGrid.MaxHeight = 450; // max height of grid
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left; // alignment
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.White); // set background color of grid

            DataGrid datagrid = new DataGrid(); // create datagrid
            DataTable dataTable = new DataTable(); // create dataTable to keep info about all roads
            dataTable.Columns.Add(new DataColumn("№", typeof(int))); // create column headers
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Length, km", typeof(double)));
            dataTable.Columns.Add(new DataColumn("Lanes", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Banquette", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Separator", typeof(string)));
            DataRow rows; HighWay highway; int Length;
            
            Length = regionalRoadsList.GetCurrentLength;
            for (int i = 0; i < Length; ++i) // moving through all roads
            {
                rows = dataTable.NewRow(); // create empty row
                highway = regionalRoadsList[i];
                rows[0] = i + 1; // push number of road
                rows[1] = highway.NameHighway; // push road name
                rows[2] = highway.RoadType; // push road type
                rows[3] = highway.RoadLength; // push road length
                rows[4] = highway.NumberLanes; // push number lanes
                rows[5] = highway.Banquette; // push road banquette
                rows[6] = highway.RoadSeparator; // push road separator
                dataTable.Rows.Add(rows); // add current row to the datable
            }
            datagrid.ItemsSource = dataTable.DefaultView; // initialize datagrid with dataTable
            datagrid.CanUserAddRows = false; // properties for table
            datagrid.CanUserDeleteRows = false;
            datagrid.IsReadOnly = true;
            datagrid.CanUserResizeColumns = false;
            datagrid.CanUserResizeRows = false;
            datagrid.CanUserReorderColumns = false;

            DynamicGrid.Children.Add(datagrid); // set on grid datagrid

            Window window = new Window // create window to be printed
            {
                Title = "Regional Roads",
                Content = DynamicGrid,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen; // set location
            window.Icon = new BitmapImage(new Uri(@"C:\Users\VETAL\Desktop\Course_Work\Highway\Assets\road.png")); // image header
            window.ShowDialog(); // print window
        }
    }
}
