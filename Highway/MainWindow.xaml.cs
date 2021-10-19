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
using System.Media;
using System.Windows.Media.Animation;

namespace Highway
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int from = 492;
        const int add = 232;
        public MainWindow()
        {
            InitializeComponent();
            nav_pnl.Width = 65;
            DoubleAnimation fade2 = new DoubleAnimation()
            {
                From = 724,
                To = 956,
                Duration = TimeSpan.FromMilliseconds(0)
            };
            Table.BeginAnimation(Grid.WidthProperty, fade2);
            ThicknessAnimation fade = new ThicknessAnimation();
            fade.From = Table.Margin;
            fade.To = new Thickness(Table.Margin.Left, Table.Margin.Top, Table.Margin.Right + 232, Table.Margin.Bottom);
            fade.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            Table.BeginAnimation(Grid.MarginProperty, fade);
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
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
                    PanelToMove.Children.Add(new UserControlInitial());
                    break;
                case 1:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlInitial());
                    break;
                case 2:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlInitial());
                    break;
                case 3:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlInitial());
                    break;
                case 4:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlInitial());
                    break;
                case 5:
                    PanelToMove.Children.Clear();
                    PanelToMove.Children.Add(new UserControlInitial());
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
                From = from + add,
                To = from + 2 * add,
                Duration = TimeSpan.FromMilliseconds(0)

            };
            Table.BeginAnimation(Grid.WidthProperty, fade1);
            ThicknessAnimation fade2 = new ThicknessAnimation();
            fade2.From = Table.Margin;
            fade2.To = new Thickness(Table.Margin.Left, Table.Margin.Top, Table.Margin.Right + 232, Table.Margin.Bottom);
            fade2.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            Table.BeginAnimation(Grid.MarginProperty, fade2);
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fade1 = new DoubleAnimation()
            {
                From = from,
                To = from + add + 3,
                Duration = TimeSpan.FromMilliseconds(0)
            };
            Table.BeginAnimation(Grid.WidthProperty, fade1);
            ThicknessAnimation fade2 = new ThicknessAnimation();
            fade2.From = Table.Margin;
            fade2.To =  new Thickness(Table.Margin.Left, Table.Margin.Top, 0, Table.Margin.Bottom);
            fade2.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            Table.BeginAnimation(Grid.MarginProperty, fade2);
        }
    }
}
