using System.Windows;
using System.Windows.Controls;
using Highway.Models;


namespace Highway.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlGroupedSepRoad.xaml
    /// </summary>
    public partial class UserControlGroupedSepRoad : UserControl
    {
        public UserControlGroupedSepRoad()
        {
            InitializeComponent();
        }

        private void FindAllGroupedRoadsWithSeparetorMore2Lanes_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            { 
                Title = "Grouped roads",
                Content = new HighwayTable(),
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
        }
    }
}
