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
using System.Windows.Shapes;

namespace SnakesAndLadders
{
    /// <summary>
    /// Логика взаимодействия для Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public Map()
        {
            InitializeComponent();

            Init();

            for (int i = 0; i < Utils._size; i++)
            {
                for (int j = 0; j < Utils._size; j++)
                {
                    AddCage(i, j);
                }
            }
        }

        private void Init()
        {
            int count = 0;
            for (int i = 0; i < Utils._size; i++)
            {
                GridMap.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                for (int j = 0; j < Utils._size; j++)
                {
                    GridMap.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(this.Width / Utils._size, GridUnitType.Pixel) }); //костыль, но работает :/
                    Utils._cachemap[i, j] = count += 1;
                }
            }
            Format();
        }

        private void Format()
        {
            for (int i = 1; i < Utils._size; i += 2)
            {
                for (int j = 0; j < Utils._size / 2; j++)
                {
                    int tmp = Utils._cachemap[i, j];
                    Utils._cachemap[i, j] = Utils._cachemap[i, Utils._size - j - 1];
                    Utils._cachemap[i, Utils._size - j - 1] = tmp;
                }
            }

            for (int i = 0; i < Utils._size / 2; i += 1)
            {
                for (int j = 0; j < Utils._size; j++)
                {
                    int tmp = Utils._cachemap[i, j];
                    Utils._cachemap[i, j] = Utils._cachemap[Utils._size - i - 1, j];
                    Utils._cachemap[Utils._size - i - 1, j] = tmp;
                }
            }
        }

        private void AddCage(int row, int column)
        {
            Border myBorder1 = new Border();
            myBorder1.Background = Brushes.SkyBlue;
            myBorder1.BorderBrush = Brushes.Black;
            myBorder1.BorderThickness = new Thickness(1);
            Label label = new Label
            {
                Content = $"Text {row}:{column} [{Utils._cachemap[row, column]}]"
            };
            myBorder1.Child = label;
            GridMap.Children.Add(myBorder1);
            myBorder1.SetValue(Grid.ColumnProperty, column);
            myBorder1.SetValue(Grid.RowProperty, row);
        }
    }
}
