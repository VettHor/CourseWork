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
        readonly UpdateTable UpdateTable;
        public UserControlInitial()
        {
            InitializeComponent();
            UpdateTable = new UpdateTable();
        }
        public void OnButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow._highwaysList.ReadFile();
            UpdateTable updateTable = new UpdateTable();
            updateTable.UpDateHighways(MainWindow._highwaysList);
        }
    }
}
