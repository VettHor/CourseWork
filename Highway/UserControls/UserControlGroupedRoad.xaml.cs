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
    /// Interaction logic for UserControlGroupedSepRoad.xaml
    /// </summary>
    public partial class UserControlGroupedRoad : UserControl
    {
        public UserControlGroupedRoad()
        {
            InitializeComponent();
        }

        private void FindGroupedSeparatedRoadsMoreTwoLines_Click(object sender, RoutedEventArgs e)
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = double.NaN;
            DynamicGrid.MaxHeight = 450;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.White);

            //state, regional, areal, local
            //DataGrid datagrid = new DataGrid();
            //DataTable dataTable = new DataTable();
            //dataTable.Columns.Add(new DataColumn("№", typeof(int)));
            //dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            //dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            //dataTable.Columns.Add(new DataColumn("Length", typeof(uint)));
            //dataTable.Columns.Add(new DataColumn("Lanes", typeof(uint)));
            //dataTable.Columns.Add(new DataColumn("Banquette", typeof(string)));
            //dataTable.Columns.Add(new DataColumn("Divider", typeof(string)));
            //DataRow rows; HighWay highway; int currLength;
            //List<HighwayList> GroupedHighwayList = new List<HighwayList>();
            //GroupedHighwayList = MainWindow.highwaysList.FindGroupedSeparatedRoadsMoreTwoLines();
            //for (int i = 0; i < GroupedHighwayList.Count; ++i)
            //{
            //    currLength = GroupedHighwayList[i].GetCurrentLength();
            //    for (int j = 0; j < currLength; ++j)
            //    {
            //        rows = dataTable.NewRow();
            //        highway = GroupedHighwayList[i][j];
            //        rows[0] = j + 1;
            //        rows[1] = highway.NameHighway;
            //        rows[2] = highway.RoadType;
            //        rows[3] = highway.RoadLength;
            //        rows[4] = highway.NumberLanes;
            //        rows[5] = highway.Banquette;
            //        rows[6] = highway.RoadDivider;
            //        dataTable.Rows.Add(rows);
            //    }
            //    if (i != GroupedHighwayList.Count - 1 && currLength != 0)
            //    {
            //        rows = dataTable.NewRow();
            //        dataTable.Rows.Add(rows);
            //    }
            //}

            DataGrid datagrid = new DataGrid();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("№", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Length", typeof(uint)));
            dataTable.Columns.Add(new DataColumn("Lanes", typeof(uint)));
            dataTable.Columns.Add(new DataColumn("Banquette", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Divider", typeof(string)));
            DataRow rows; HighWay highway; int currLength;
            Dictionary<RoadType, HighwayList> GroupedHighwayLists = MainWindow.highwaysList.FindGroupedSeparatedRoadsMoreTwoLines();
            for (RoadType i = 0; i <= RoadType.local; ++i)
            {
                currLength = GroupedHighwayLists[i].GetCurrentLength();
                for (int j = 0; j < currLength; ++j)
                {
                    rows = dataTable.NewRow();
                    highway = GroupedHighwayLists[i][j];
                    rows[0] = j + 1;
                    rows[1] = highway.NameHighway;
                    rows[2] = highway.RoadType;
                    rows[3] = highway.RoadLength;
                    rows[4] = highway.NumberLanes;
                    rows[5] = highway.Banquette;
                    rows[6] = highway.RoadDivider;
                    dataTable.Rows.Add(rows);
                }
                if (i != RoadType.local && currLength != 0)
                {
                    rows = dataTable.NewRow();
                    dataTable.Rows.Add(rows);
                }
            }

            //DataGrid datagrid = new DataGrid();
            //DataTable dataTable = new DataTable();
            //dataTable.Columns.Add(new DataColumn("№", typeof(int)));
            //dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            //dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            //dataTable.Columns.Add(new DataColumn("Length", typeof(uint)));
            //dataTable.Columns.Add(new DataColumn("Lanes", typeof(uint)));
            //dataTable.Columns.Add(new DataColumn("Banquette", typeof(string)));
            //dataTable.Columns.Add(new DataColumn("Divider", typeof(string)));
            //DataRow rows; HighWay highway;
            //for (int i = 0; i < MainWindow.highwaysList.GetCurrentLength(); ++i)
            //{
            //    rows = dataTable.NewRow();
            //    highway = MainWindow.highwaysList[i];
            //    rows[0] = i + 1;
            //    rows[1] = highway.NameHighway;
            //    rows[2] = highway.RoadType;
            //    rows[3] = highway.RoadLength;
            //    rows[4] = highway.NumberLanes;
            //    rows[5] = highway.Banquette;
            //    rows[6] = highway.RoadDivider;
            //    dataTable.Rows.Add(rows);
            //}
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
                Title = "Grouped Roads",
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
