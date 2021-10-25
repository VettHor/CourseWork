using System.Windows;
using System.Windows.Controls;
using System.Data;
using Highway.Models;
using System.Windows.Input;
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
            if (list.GetCurrentLength() == 0)
            {
                RoadTable.ItemsSource = null;
                RoadTable.Items.Clear();
                return;
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("№", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Length", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Lanes", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Banquette", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Separator", typeof(string)));
            DataRow rows; HighWay highway;
            for (int i = 0; i < list.GetCurrentLength(); ++i)
            {
                rows = dataTable.NewRow();
                highway = list[i];
                rows[0] = i + 1;
                rows[1] = highway.NameHighway;
                rows[2] = highway.RoadType;
                rows[3] = highway.RoadLength;
                rows[4] = highway.NumberLanes;
                rows[5] = highway.Banquette;
                rows[6] = highway.RoadSeparator;
                dataTable.Rows.Add(rows);
            }
            RoadTable.ItemsSource = dataTable.DefaultView;
            foreach (var column in RoadTable.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
            RoadTable.Columns[0].Width = new DataGridLength(0.6, DataGridLengthUnitType.Star);
            RoadTable.Columns[1].Width = new DataGridLength(1.5, DataGridLengthUnitType.Star);
            RoadTable.CanUserAddRows = false;
            RoadTable.CanUserDeleteRows = false;
            RoadTable.IsReadOnly = true;
            RoadTable.CanUserResizeColumns = false;
            RoadTable.CanUserResizeRows = false;
            RoadTable.CanUserReorderColumns = false;
        }

        private void AddRoadToTable_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Add road to the table",
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };

            Grid DynamicGrid = new Grid();
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.White);
            DynamicGrid.Children.Add(new UserControlAddRoadToList(window));

            window.Content = DynamicGrid;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Icon = new BitmapImage(new Uri(@"C:\Users\VETAL\Desktop\Course_Work\Highway\Assets\road.png"));
            window.ShowDialog();
        }
    }
}
