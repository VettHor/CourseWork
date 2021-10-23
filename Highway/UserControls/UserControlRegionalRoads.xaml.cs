using System.Windows;
using System.Windows.Controls;
using Highway.Models;
using System.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;
using System.Collections.Generic;

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
            dataTable.Columns.Add(new DataColumn("Divider", typeof(string)));
            DataRow rows; HighWay highway; int Length;
            HighwayList regionalRoadsList = MainWindow.highwaysList.FindRegionalRoadsMostLanesCrosswalkAvailable();
            Length = regionalRoadsList.GetCurrentLength();
            for (int i = 0; i < Length; ++i)
            {
                rows = dataTable.NewRow();
                highway = regionalRoadsList[i];
                rows[0] = i + 1;
                rows[1] = highway.NameHighway;
                rows[2] = highway.RoadType;
                rows[3] = highway.RoadLength;
                rows[4] = highway.NumberLanes;
                rows[5] = highway.Banquette;
                rows[6] = highway.RoadDivider;
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
