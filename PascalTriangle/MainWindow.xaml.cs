using System.Windows;
using System.Windows.Controls;

namespace PascalTriangle
{
    public partial class MainWindow : Window
    {
        int triangleHeight;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearField()
        {
            Grid_Field.Children.Clear();
            Grid_Field.RowDefinitions.Clear();
            Grid_Field.ColumnDefinitions.Clear();
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            Label[][] field = new Label[triangleHeight + 1][];

            ClearField();

            for (int y = 0; y <= triangleHeight; y++)
            {
                Grid_Field.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                field[y] = new Label[y + 1];

                for (int x = 0; x <= y; x++)
                {
                    Label newLabel = new Label();

                    Grid_Field.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                    
                    field[y][x] = newLabel;
                    field[y][0].Content = "1";

                    Grid_Field.Children.Add(newLabel);

                    Grid.SetRow(newLabel, y);
                    Grid.SetColumn(newLabel, x);
                }

                field[y][field[y].Length - 1].Content = "1";
            }

            for (int y = 1; y < field.GetLength(0); y++)
                for (int x = 1; x < field[y].Length - 1; x++)
                {
                    int a = int.Parse(field[y - 1][x - 1].Content.ToString());
                    int b = int.Parse(field[y - 1][x].Content.ToString());

                    field[y][x].Content = a + b;
                }
        }

        private void ComboBox_TriangleHeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)ComboBox_TriangleHeight.SelectedItem;

            triangleHeight = int.Parse(comboBoxItem.Content.ToString());
        }
    }
}
