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

namespace Highway
{
    /// <summary>
    /// Interaction logic for HighwayTable.xaml
    /// </summary>
    public partial class HighwayTable : UserControl
    {
        readonly UpdateTable updateTable;
        public HighwayTable()
        {
            InitializeComponent();
            updateTable = new UpdateTable();
            UpdateTable.HighWaysFill += onTableUpdate;
        }

        private void onTableUpdate(HighwayList list)
        {
            RoadTable.ItemsSource = new List<string>() { "test", "test1" };
        }
    }
}
