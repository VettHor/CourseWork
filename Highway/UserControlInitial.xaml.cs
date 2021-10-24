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
        _updateTable _updateTable;
        public UserControlInitial()
        {
            InitializeComponent();
            _updateTable = new _updateTable();
        }
        public void OnButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow._highwaysList.ReadFile();
            _updateTable.UpDateHighways(MainWindow._highwaysList);
        }
    }
}
