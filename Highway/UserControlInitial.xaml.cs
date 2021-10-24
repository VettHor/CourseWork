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
            MainWindow._highwaysList.ReadFile();
            updateTable.UpDateHighways(MainWindow._highwaysList);
        }
    }
}
