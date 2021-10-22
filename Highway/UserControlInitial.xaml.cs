using System;
using System.Windows;
using System.Windows.Controls;
using Highway.Models;

namespace Highway
{
    /// <summary>
    /// Interaction logic for UserControlInitial.xaml
    /// </summary>
    public partial class UserControlInitial : UserControl
    {
        UpdateTable updateTable;
        public UserControlInitial()
        {
            InitializeComponent();
            updateTable = new UpdateTable();
        }
        public void OnButtonClick(object sender, RoutedEventArgs e)
        {
            //updateTable.UpDateHighways(new HighwayList());
            MainWindow.highwaysList.ReadFile();
            //HighwayTable highwayTable = new HighwayTable(MainWindow.highwaysList);
            updateTable.UpDateHighways(MainWindow.highwaysList);
        }
    }
}
