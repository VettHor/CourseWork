using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Highway.Models;

namespace Highway.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlAddRoadToList.xaml
    /// </summary>
    public partial class UserControlAddRoadToList : UserControl // class to add a road to the table
    {
        private Window _window; // to be able to close the current window
        public UserControlAddRoadToList()
        {
            InitializeComponent();
        }
        public UserControlAddRoadToList(Window window) // constructor to initialize the _window field of the current class
        {
            _window = window;
            InitializeComponent();
        }

        private void AddRoadToList_Click(object sender, RoutedEventArgs e) // when clicking on "Add to list" add an element to the table
        {
            try
            {
                if (RoadName.Text == "" || RoadLength.Text == "" || AmountRoadLines.Text == "") // if the filled fields are empty
                {
                    throw new FormatException("Cannot add road, fill all filds"); // then exceptional situation
                }
                if (RoadName.Text.Contains(' ') || RoadLength.Text.Contains(' ') || AmountRoadLines.Text.Contains(' ') || // if the filled fields contain spaces or
                    !(new Regex("^[a-zA-Z-]+$")).IsMatch(RoadName.Text) || !int.TryParse(RoadLength.Text, out int roadLength) || // if the field "Road name" does not contain letters or symbol '-' or
                    !int.TryParse(AmountRoadLines.Text, out int amountRoadLines) || roadLength <= 0 || amountRoadLines <= 0) // if length or amount lines are not numbers or less or equal 0
                {
                    throw new FormatException("Cannot add road, check the input"); // then exceptional situation
                }
                MainWindow._highwaysList.Add(new HighWay(RoadName.Text,
                                                        RoadTypeBox.Text,
                                                        roadLength,
                                                        amountRoadLines,
                                                        BanquetteBox.Text,
                                                        SeparatorBox.Text)); // adding current road to the table
                UpdateTable updateTable = new UpdateTable();
                updateTable.UpDateHighways(MainWindow._highwaysList); // update HighwayTable
                _window.Close(); // close input window
                MessageBox.Show(
                         "Successfully added to HighwayTable",
                         "Information",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information); // successful message
            }
            catch (FormatException formatException)
            {
                MessageBox.Show(
                         formatException.Message,
                         "Warning",
                         MessageBoxButton.OK,
                         MessageBoxImage.Warning); // unsuccessful message if exception occured
            }
        }
    }
}
