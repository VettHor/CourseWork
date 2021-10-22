using System.Windows;
using System.Windows.Controls;
using Highway.Models;
using System.Data;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Data;

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
            // Create the Grid
            //Grid DynamicGrid = new Grid();
            //DynamicGrid.Width = 400;
            //DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            //DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            //DynamicGrid.ShowGridLines = true;
            //DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);

            // Create Columns
            //ColumnDefinition gridCol1 = new ColumnDefinition();
            //ColumnDefinition gridCol2 = new ColumnDefinition();
            //ColumnDefinition gridCol3 = new ColumnDefinition();
            //DynamicGrid.ColumnDefinitions.Add(gridCol1);
            //DynamicGrid.ColumnDefinitions.Add(gridCol2);
            //DynamicGrid.ColumnDefinitions.Add(gridCol3);

            //// Create Rows
            //RowDefinition gridRow1 = new RowDefinition();
            //gridRow1.Height = new GridLength(45);
            //RowDefinition gridRow2 = new RowDefinition();
            //gridRow2.Height = new GridLength(45);
            //RowDefinition gridRow3 = new RowDefinition();
            //gridRow3.Height = new GridLength(45);
            //DynamicGrid.RowDefinitions.Add(gridRow1);
            //DynamicGrid.RowDefinitions.Add(gridRow2);
            //DynamicGrid.RowDefinitions.Add(gridRow3);

            //// Add first column header
            //TextBlock txtBlock1 = new TextBlock();
            //txtBlock1.Text = "Author Name";
            //txtBlock1.FontSize = 14;
            //txtBlock1.FontWeight = FontWeights.Bold;
            //txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            //txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            //Grid.SetRow(txtBlock1, 0);
            //Grid.SetColumn(txtBlock1, 0);

            //// Add second column header
            //TextBlock txtBlock2 = new TextBlock();
            //txtBlock2.Text = "Age";
            //txtBlock2.FontSize = 14;
            //txtBlock2.FontWeight = FontWeights.Bold;
            //txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            //txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            //Grid.SetRow(txtBlock2, 0);
            //Grid.SetColumn(txtBlock2, 1);


            //// Add third column header
            //TextBlock txtBlock3 = new TextBlock();
            //txtBlock3.Text = "Book";
            //txtBlock3.FontSize = 14;
            //txtBlock3.FontWeight = FontWeights.Bold;
            //txtBlock3.Foreground = new SolidColorBrush(Colors.Green);
            //txtBlock3.VerticalAlignment = VerticalAlignment.Top;
            //Grid.SetRow(txtBlock3, 0);
            //Grid.SetColumn(txtBlock3, 2);


            ////// Add column headers to the Grid
            //DynamicGrid.Children.Add(txtBlock1);
            //DynamicGrid.Children.Add(txtBlock2);
            //DynamicGrid.Children.Add(txtBlock3);


            //// Create first Row
            //TextBlock authorText = new TextBlock();
            //authorText.Text = "Mahesh Chand";
            //authorText.FontSize = 12;
            //authorText.FontWeight = FontWeights.Bold;
            //Grid.SetRow(authorText, 1);
            //Grid.SetColumn(authorText, 0);
            //TextBlock ageText = new TextBlock();
            //ageText.Text = "33";
            //ageText.FontSize = 12;
            //ageText.FontWeight = FontWeights.Bold;
            //Grid.SetRow(ageText, 1);
            //Grid.SetColumn(ageText, 1);

            //TextBlock bookText = new TextBlock();
            //bookText.Text = "GDI+ Programming";
            //bookText.FontSize = 12;
            //bookText.FontWeight = FontWeights.Bold;
            //Grid.SetRow(bookText, 1);
            //Grid.SetColumn(bookText, 2);

            //// Add first row to Grid
            //DynamicGrid.Children.Add(authorText);
            //DynamicGrid.Children.Add(ageText);
            //DynamicGrid.Children.Add(bookText);


            //// Create second row
            //authorText = new TextBlock();
            //authorText.Text = "Mike Gold";
            //authorText.FontSize = 12;
            //authorText.FontWeight = FontWeights.Bold;
            //Grid.SetRow(authorText, 2);
            //Grid.SetColumn(authorText, 0);
            //ageText = new TextBlock();
            //ageText.Text = "35";
            //ageText.FontSize = 12;
            //ageText.FontWeight = FontWeights.Bold;
            //Grid.SetRow(ageText, 2);
            //Grid.SetColumn(ageText, 1);
            //bookText = new TextBlock();
            //bookText.Text = "Programming C#";
            //bookText.FontSize = 12;
            //bookText.FontWeight = FontWeights.Bold;
            //Grid.SetRow(bookText, 2);
            //Grid.SetColumn(bookText, 2);

            //// Add second row to Grid
            //DynamicGrid.Children.Add(authorText);
            //DynamicGrid.Children.Add(ageText);
            //DynamicGrid.Children.Add(bookText);

            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = double.NaN;
            DynamicGrid.MaxHeight = 450;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);

            DataGrid datagrid = new DataGrid();


            //DataGridTemplateColumn d = new DataGridTemplateColumn();
            //d.CellStyle = Resources["IngredientsCellTemplate"] as Style;
            //DataGridTextColumn da = new DataGridTextColumn();
            //da.CellStyle = Resources["IngredientsCellTemplate"] as Style;
            
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //datagrid.Columns.Add(new DataGridTextColumn()
            //{
            //    Header = "Type",
            //    Width = new DataGridLength(200),
            //    FontSize = 12,
            //    Binding = new Binding("Name")
            //});
            //datagrid.Columns.Add(new DataGridTemplateColumn()
            //{
            //    Header = "Ingredients",
            //    Width = new DataGridLength(1, DataGridLengthUnitType.Star),
            //    CellTemplate = FindResource("IngredientsCellTemplate") as DataTemplate
            //});
            //datagrid.Style = Resources["ReadOnlyGridStyle"] as Style;
            


            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("№", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Length", typeof(uint)));
            dataTable.Columns.Add(new DataColumn("Lanes", typeof(uint)));
            dataTable.Columns.Add(new DataColumn("Banquette", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Divider", typeof(string)));
            DataRow rows; HighWay highway;
            for (int i = 0; i < MainWindow.highwaysList.GetCurrentLength(); ++i)
            {
                rows = dataTable.NewRow();
                highway = MainWindow.highwaysList[i];
                rows[0] = i + 1;
                rows[1] = highway.NameHighway;
                rows[2] = highway.RoadType;
                rows[3] = highway.RoadLength;
                rows[4] = highway.NumberLanes;
                rows[5] = highway.Banquette;
                rows[6] = highway.RoadDivider;
                dataTable.Rows.Add(rows);
            }
            datagrid.ItemsSource = dataTable.DefaultView;
            datagrid.CanUserAddRows = false;
            datagrid.CanUserDeleteRows = false;
            datagrid.IsReadOnly = true;
            datagrid.CanUserResizeColumns = false;
            datagrid.CanUserResizeRows = false;

            DynamicGrid.Children.Add(datagrid);


            Window window = new Window
            {
                Title = "Grouped roads",
                Content = DynamicGrid,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
            //window.Icon = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(@"/Assets/remove-user-icon.png"));
        }
        //private DataGridTemplateColumn CreateTextBoxColumn()
        //{
        //    //create a template column
        //    DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
        //    //set title of column
        //    templateColumn.Header = "TextBoxColumn";
        //    //non editing cell template.. will be used for viweing data
        //    DataTemplate textBlockTemplate = new DataTemplate();
        //    FrameworkElementFactory textBlockElement = new FrameworkElementFactory(typeof(TextBlock));
        //    System.Windows.Data.Binding textBlockBinding = new System.Windows.Data.Binding("TextBoxColumn");
        //    textBlockElement.SetBinding(TextBlock.TextProperty, textBlockBinding);
        //    textBlockTemplate.VisualTree = textBlockElement;
        //    templateColumn.CellTemplate = textBlockTemplate;
        //    //editing cell template ... will be used when user will edit the data
        //    DataTemplate textBoxTemplate = new DataTemplate();
        //    FrameworkElementFactory textboxElement = new FrameworkElementFactory(typeof(TextBox));
        //    System.Windows.Data.Binding textboxBinding = new System.Windows.Data.Binding("TextBoxColumn");
        //    textboxElement.SetBinding(TextBox.TextProperty, textboxBinding);
        //    textBoxTemplate.VisualTree = textboxElement;
        //    templateColumn.CellEditingTemplate = textBoxTemplate;
        //    return templateColumn;
        //}

        //private DataGridTemplateColumn CreateComboBoxColumn()
        //{
        //    //create a template column
        //    DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
        //    //set title of column
        //    templateColumn.Header = "ComboBoxColumn";
        //    //non editing cell template.. will be used for viweing data
        //     DataTemplate textBlockTemplate = new DataTemplate();
        //         FrameworkElementFactory textBlockElement = new FrameworkElementFactory(typeof(TextBlock));
        //    System.Windows.Data.Binding textBlockBinding = new System.Windows.Data.Binding("ComboBoxColumn");
        //       textBlockElement.SetBinding(TextBlock.TextProperty, textBlockBinding);
        //       textBlockTemplate.VisualTree = textBlockElement;
        //        templateColumn.CellTemplate = textBlockTemplate;

        //        //editing cell template ... will be used when user will edit the data
        //        DataTemplate comboboxTemplate = new DataTemplate();
        //        FrameworkElementFactory comboboxElement = new FrameworkElementFactory(typeof(ComboBox));
        //    System.Windows.Data.Binding comboboxBinding = new System.Windows.Data.Binding("ComboBoxColumn");
        //        comboboxElement.SetBinding(ComboBox.TextProperty, comboboxBinding);

        //        //combo box will show these options to select from
        //        comboboxElement.SetValue(ComboBox.ItemsSourceProperty, new List<string> { "Value1", "Value2" ,"Value3", "Value4" });
        //        comboboxTemplate.VisualTree = comboboxElement;
        //        templateColumn.CellEditingTemplate = comboboxTemplate;
        //        return templateColumn;
        //   }
    }
}
