using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Highway.Models;
using System.Data;

namespace Highway.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlFindShortestRoad.xaml
    /// </summary>
    public partial class UserControlShortestRoad : UserControl
    {
        public UserControlShortestRoad()
        {
            InitializeComponent();
        }

        private void FindShortestRoadMostLanes_Click(object sender, RoutedEventArgs e)
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
            HighwayList foundHighWays = MainWindow._highwaysList.FindShortestRoadWithMostLanes();
            if (foundHighWays.GetCurrentLength == 0) // if list is empty
            {
                MessageBox.Show(
                    "There is no such roads",
                    "Find information",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information); // print warning and leave function
                return;
            }

            if (foundHighWays.GetCurrentLength != 1) // if more than 1 road
                MessageBox.Show(
                    "There is more than 1 road with same data",
                    "Find information",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information); // print info about different roads

            Grid DynamicGrid = new Grid(); // create grid to push table
            DynamicGrid.Width = double.NaN;
            DynamicGrid.MaxHeight = 450;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.White);

            DataGrid datagrid = new DataGrid();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("№", typeof(int))); // headers
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Length, km", typeof(double)));
            dataTable.Columns.Add(new DataColumn("Lanes", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Banquette", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Separator", typeof(string)));
            DataRow rows;
            int Length = foundHighWays.GetCurrentLength;
            for (int i = 0; i < Length; ++i)
            {
                rows = dataTable.NewRow(); // create new row
                rows[0] = i + 1;
                rows[1] = foundHighWays[i].NameHighway; // push all fiels
                rows[2] = foundHighWays[i].RoadType;
                rows[3] = foundHighWays[i].RoadLength;
                rows[4] = foundHighWays[i].NumberLanes;
                rows[5] = foundHighWays[i].Banquette;
                rows[6] = foundHighWays[i].RoadSeparator;
                dataTable.Rows.Add(rows);
            }

            datagrid.ItemsSource = dataTable.DefaultView;
            datagrid.CanUserAddRows = false; // set properties
            datagrid.CanUserDeleteRows = false;
            datagrid.IsReadOnly = true;
            datagrid.CanUserResizeColumns = false;
            datagrid.CanUserResizeRows = false;
            datagrid.CanUserReorderColumns = false;

            DynamicGrid.Children.Add(datagrid); // set datagrid on dynamic grid

            Window window = new Window
            {
                Title = "Regional Roads",
                Content = DynamicGrid,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Icon = new BitmapImage(new Uri(@"C:\Users\VETAL\Desktop\Course_Work\Highway\Assets\road.png"));
            window.ShowDialog();
        }
    }
}
