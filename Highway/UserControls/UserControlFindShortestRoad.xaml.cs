using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Highway.Models;

namespace Highway.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlFindShortestRoad.xaml
    /// </summary>
    public partial class UserControlFindShortestRoad : UserControl
    {
        public UserControlFindShortestRoad()
        {
            InitializeComponent();
        }

        private void FindShortestRoadMostLanes_Click(object sender, RoutedEventArgs e)
        {
            UpdateTable updateTable = new UpdateTable();
            
            RoadPrint.Text = MainWindow.highwaysList.FindShortestRoadWithMostLanes().ToString();
        }
    }
}
