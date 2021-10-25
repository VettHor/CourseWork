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
        static public HighwayList _highwaysList; // to keep all changes
        const int FROM = 492;
        const int TO = 232;
        public MainWindow()
        {
            InitializeComponent();
            _highwaysList = new HighwayList();
            nav_pnl.Width = 65;
            DoubleAnimation fade2 = new DoubleAnimation()
            {
                From = FROM + TO,
                To = FROM + 2 * TO + 3,
                Duration = TimeSpan.FromMilliseconds(0)
            };
            ThicknessAnimation fade = new ThicknessAnimation();
            fade.From = Table.Margin;
            fade.To = new Thickness(Table.Margin.Left, Table.Margin.Top, Table.Margin.Right + TO, Table.Margin.Bottom);
            fade.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            Table.BeginAnimation(Grid.MarginProperty, fade);
            PanelToMove.BeginAnimation(Grid.MarginProperty, fade);
            Table.BeginAnimation(Grid.WidthProperty, fade2);
            PanelToMove.BeginAnimation(Grid.WidthProperty, fade2);
            UpdateTable updateTable = new UpdateTable();
            updateTable.UpDateHighways(MainWindow._highwaysList);
            PanelToMove.Children.Clear();
            PanelToMove.Children.Add(new UserControlOpenFile());
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch(index)
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
            GridCursor.Margin = new Thickness(0, 100 + (70 * index), 0, 0);
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fade1 = new DoubleAnimation()
            {
                From = FROM + TO,
                To = FROM + 2 * TO + 3,
                Duration = TimeSpan.FromMilliseconds(0)

            };
            ThicknessAnimation fade2 = new ThicknessAnimation();
            fade2.From = Table.Margin;
            fade2.To = new Thickness(Table.Margin.Left, Table.Margin.Top, Table.Margin.Right + TO, Table.Margin.Bottom);
            fade2.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            Table.BeginAnimation(Grid.MarginProperty, fade2);
            PanelToMove.BeginAnimation(Grid.MarginProperty, fade2);
            Table.BeginAnimation(Grid.WidthProperty, fade1);
            PanelToMove.BeginAnimation(Grid.WidthProperty, fade1);
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fade1 = new DoubleAnimation()
            {
                From = FROM,
                To = FROM + TO + 3,
                Duration = TimeSpan.FromMilliseconds(0)
            };
            ThicknessAnimation fade2 = new ThicknessAnimation();
            fade2.From = Table.Margin;
            fade2.To =  new Thickness(Table.Margin.Left, Table.Margin.Top, 0, Table.Margin.Bottom);
            fade2.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            Table.BeginAnimation(Grid.MarginProperty, fade2);
            PanelToMove.BeginAnimation(Grid.MarginProperty, fade2);
            Table.BeginAnimation(Grid.WidthProperty, fade1);
            PanelToMove.BeginAnimation(Grid.WidthProperty, fade1);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(_highwaysList.GetCurrentLength() == 0)
            {
                MessageBox.Show(
                        "The HighwayTable is empty, cannot delete",
                        "Warning",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show(
                        String.Format($"Are you sure to delete HighwayTable with {HighWay.countRoads} roads? You cannot turn it back"),
                        "Delete HighwayTable",
                        MessageBoxButton.YesNoCancel,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _highwaysList.ClearList();
                UpdateTable updateTable = new UpdateTable();
                updateTable.UpDateHighways(MainWindow._highwaysList);
                MessageBox.Show(
                            "Successfully deleted HigwayTable",
                            "Information",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
            }
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                            "The program \"Highways\" is created to:\n" +
                            "\t● Find shortest road with most lines\n" +
                            "\t● Find all grouped roads with separator and more than 2 lines\n" +
                            "\t● Find all road types with biggest length and banquette\n" +
                            "\t● Find all regional roads with most lines and banquette\n" +
                            "The program \"Highways\" is created by Horbovyi Vitalii",
                            "About \"Highways\" Program",
                            MessageBoxButton.OK,
                            MessageBoxImage.None);
        }
    }
}
