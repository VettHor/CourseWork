using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Highway.Models;
using Highway.UserControls;

namespace Highway
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public HighwayList _highwaysList; // to keep all list changes
        const int FROM = 492;
        const int TO = 232;
        public MainWindow()
        {
            InitializeComponent();
            _highwaysList = new HighwayList(); // create list
            nav_pnl.Width = 65;
            DoubleAnimation fade2 = new DoubleAnimation() // animation to move grid of main window
            {
                From = FROM + TO,
                To = FROM + 2 * TO + 3,
                Duration = TimeSpan.FromMilliseconds(0)
            };
            ThicknessAnimation fade = new ThicknessAnimation();
            fade.From = Table.Margin;
            fade.To = new Thickness(Table.Margin.Left, Table.Margin.Top, Table.Margin.Right + TO, Table.Margin.Bottom);
            fade.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            Table.BeginAnimation(Grid.MarginProperty, fade); // begin all animations
            PanelToMove.BeginAnimation(Grid.MarginProperty, fade);
            Table.BeginAnimation(Grid.WidthProperty, fade2);
            PanelToMove.BeginAnimation(Grid.WidthProperty, fade2);
            UpdateTable updateTable = new UpdateTable();
            updateTable.UpDateHighways(MainWindow._highwaysList);
            PanelToMove.Children.Clear();
            PanelToMove.Children.Add(new UserControlOpenFile()); // first panel open
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // close app
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed) // to be able to move form with mouse draging
                DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch(index) // switch between all panels
            {
                case 0:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlOpenFile());
                    break;
                case 1:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlSaveToFile());
                    break;
                case 2:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlSort());
                    break;
                case 3:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlShortestRoad());
                    break;
                case 4:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlGroupedRoad());
                    break;
                case 5:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlLongestRoadBanquette());
                    break;
                case 6:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlRegionalRoads());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, 100 + (70 * index), 0, 0); // move left menu line
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fade1 = new DoubleAnimation() // animation to move grid of main window
            {
                From = FROM + TO,
                To = FROM + 2 * TO + 3,
                Duration = TimeSpan.FromMilliseconds(0)

            };
            ThicknessAnimation fade2 = new ThicknessAnimation();
            fade2.From = Table.Margin;
            fade2.To = new Thickness(Table.Margin.Left, Table.Margin.Top, Table.Margin.Right + TO, Table.Margin.Bottom);
            fade2.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            Table.BeginAnimation(Grid.MarginProperty, fade2); // begin all animations
            PanelToMove.BeginAnimation(Grid.MarginProperty, fade2);
            Table.BeginAnimation(Grid.WidthProperty, fade1);
            PanelToMove.BeginAnimation(Grid.WidthProperty, fade1);
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fade1 = new DoubleAnimation() // animation to move grid of main window
            {
                From = FROM,
                To = FROM + TO + 3,
                Duration = TimeSpan.FromMilliseconds(0)
            };
            ThicknessAnimation fade2 = new ThicknessAnimation();
            fade2.From = Table.Margin;
            fade2.To =  new Thickness(Table.Margin.Left, Table.Margin.Top, 0, Table.Margin.Bottom);
            fade2.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            Table.BeginAnimation(Grid.MarginProperty, fade2); // begin all animations
            PanelToMove.BeginAnimation(Grid.MarginProperty, fade2);
            Table.BeginAnimation(Grid.WidthProperty, fade1);
            PanelToMove.BeginAnimation(Grid.WidthProperty, fade1);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(_highwaysList.GetCurrentLength == 0) // if list is empty
            {
                MessageBox.Show(
                        "The HighwayTable is empty, cannot delete",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error); // print message about it
                return;
            }
            if (MessageBox.Show(
                        String.Format($"Are you sure to delete HighwayTable with {HighWay.CountRoads} roads? You cannot turn it back"),
                        "Delete HighwayTable",
                        MessageBoxButton.YesNoCancel,
                        MessageBoxImage.Question) == MessageBoxResult.Yes) // ask user if he is sure about deleting
            {
                _highwaysList.ClearList(); // clear list
                UpdateTable updateTable = new UpdateTable();
                updateTable.UpDateHighways(MainWindow._highwaysList); // print table
                MessageBox.Show(
                            "Successfully deleted HigwayTable",
                            "Information",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information); // message about success
            }
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                            "The program \"Highways\" is created to:\n" +
                            "   ● Find shortest road with most lines\n" +
                            "   ● Find all grouped roads with separator and more than 2 lines\n" +
                            "   ● Find all road types with biggest length and banquette\n" +
                            "   ● Find all regional roads with most lines and banquette\n" +
                            "Add your first road by right-clicking!\n\n" +
                            "The program \"Highways\" is created by Horbovyi Vitalii",
                            "About \"Highways\" Program",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information); // information about program
        }
    }
}
