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
        }

        private void Init()
        {
            int count = 0;
            for (int i = 0; i < MapSettings._size; i++)
            {
                GridMap.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                for (int j = 0; j < MapSettings._size; j++)
                {
                    GridMap.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(800 / MapSettings._size, GridUnitType.Pixel) }); //костыль, но работает :/
                    MapSettings._cachemap[i, j] = count += 1;
                }
            }
            Format();

            ImageMap.Source = MapSettings._image.Source;

            for (int i = 0; i < MapSettings._size; i++)
            {
                for (int j = 0; j < MapSettings._size; j++)
                {
                    AddCage(i, j);
                }
            }
        }

        private void Format()
        {
            for (int i = 1; i < MapSettings._size; i += 2)
            {
                for (int j = 0; j < MapSettings._size / 2; j++)
                {
                    int tmp = MapSettings._cachemap[i, j];
                    MapSettings._cachemap[i, j] = MapSettings._cachemap[i, MapSettings._size - j - 1];
                    MapSettings._cachemap[i, MapSettings._size - j - 1] = tmp;
                }
            }

            for (int i = 0; i < MapSettings._size / 2; i += 1)
            {
                for (int j = 0; j < MapSettings._size; j++)
                {
                    int tmp = MapSettings._cachemap[i, j];
                    MapSettings._cachemap[i, j] = MapSettings._cachemap[MapSettings._size - i - 1, j];
                    MapSettings._cachemap[MapSettings._size - i - 1, j] = tmp;
                }
            }
        }

        private void AddCage(int row, int column)
        {
            if(Utils._debug)
            {
                Border myBorder1 = new Border();
                myBorder1.BorderBrush = Brushes.Red;
                myBorder1.BorderThickness = new Thickness(1);
                Label label = new Label
                {
                    Content = $"Text {row}:{column} [{MapSettings._cachemap[row, column]}]"
                };
                myBorder1.Child = label;
                GridMap.Children.Add(myBorder1);
                myBorder1.SetValue(Grid.ColumnProperty, column);
                myBorder1.SetValue(Grid.RowProperty, row);
            }
        }

        private void ButtonDiceNext_Click(object sender, RoutedEventArgs e)
        {
            int dice = Utils.Dice();
            ImageCubeIcon.Source = new BitmapImage(new Uri($@"pack://application:,,,/SnakesAndLadders;component/Resources/CubesIcon/Cube_{dice}.png"));
            int index = Utils.WalkNow();
            Utils._players[index].AddPosition(dice);
            if(Utils._players.Count != 0)
            {
                TextBlockInformer.Text = $"Сейчас ходит игрок \"{Utils._players[index]._Name}\"";
                Utils._nextPlayer = index + 1;
            }
        }
    }
}
