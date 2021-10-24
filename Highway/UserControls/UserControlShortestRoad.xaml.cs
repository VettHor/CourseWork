using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Highway.Models;
using System.Data;
using System.Collections.Generic;

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
            HighwayList foundHighWays = MainWindow._highwaysList.FindShortestRoadWithMostLanes();
            if (foundHighWays == null)
            {
                MessageBox.Show(
                    "Cannot find road in HigwayTable, it is empty",
                    "Find information",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            //RoadPrint.Text = MainWindow._highwaysList.FindShortestRoadWithMostLanes().NameHighway;
            //RoadPrint.VerticalContentAlignment = VerticalAlignment.Center;
            //RoadPrint.HorizontalContentAlignment = HorizontalAlignment.Center;
            if(foundHighWays.GetCurrentLength() != 1)
                MessageBox.Show(
                    "There is more than 1 road with same data",
                    "Find information",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = double.NaN;
            DynamicGrid.MaxHeight = 450;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.White);

            DataGrid datagrid = new DataGrid();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("№", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Length", typeof(uint)));
            dataTable.Columns.Add(new DataColumn("Lanes", typeof(uint)));
            dataTable.Columns.Add(new DataColumn("Banquette", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Separator", typeof(string)));
            DataRow rows;
            int Length = foundHighWays.GetCurrentLength();
            for (int i = 0; i < Length; ++i)
            {
                rows = dataTable.NewRow();
                rows[0] = i + 1;
                rows[1] = foundHighWays[i].NameHighway;
                rows[2] = foundHighWays[i].RoadType;
                rows[3] = foundHighWays[i].RoadLength;
                rows[4] = foundHighWays[i].NumberLanes;
                rows[5] = foundHighWays[i].Banquette;
                rows[6] = foundHighWays[i].RoadSeparator;
                dataTable.Rows.Add(rows);
            }

            datagrid.ItemsSource = dataTable.DefaultView;
            datagrid.CanUserAddRows = false;
            datagrid.CanUserDeleteRows = false;
            datagrid.IsReadOnly = true;
            datagrid.CanUserResizeColumns = false;
            datagrid.CanUserResizeRows = false;
            datagrid.CanUserReorderColumns = false;

            DynamicGrid.Children.Add(datagrid);

            Window window = new Window
            {
                Title = "Regional Roads",
                Content = DynamicGrid,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Icon = new BitmapImage(new Uri(@"C:\Users\VETAL\Desktop\Course Work\Highway\Highway\Assets\road.png"));
            window.ShowDialog();
        }
    }
}
