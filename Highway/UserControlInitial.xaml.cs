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
using Highway;
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
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            updateTable.UpDateHighways(new HighwayList());
        }
    }
}
