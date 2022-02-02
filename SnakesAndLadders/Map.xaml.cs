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
            int count = 1;
            bool reverse = false;
            int size = 24;

            int result = Convert.ToInt32(Math.Round(Convert.ToDouble(size) / 5 - 1));
            // MessageBox.Show($"{result}");
            for (int i = 4; i >= 0; i--)
            {
                if (reverse)
                {
                    for (int j = 4; j >= 0; j--)
                    {
                        Label label = new Label
                        {
                            Content = "Text" + count
                        };
                        GridMap.Children.Add(label);
                        label.SetValue(Grid.RowProperty, i);
                        label.SetValue(Grid.ColumnProperty, j);
                        count++;
                    }
                    reverse = false;
                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Label label = new Label
                        {
                            Content = "Text" + count
                        };
                        GridMap.Children.Add(label);
                        label.SetValue(Grid.RowProperty, i);
                        label.SetValue(Grid.ColumnProperty, j);
                        count++;
                    }
                    reverse = true;
                }
            }
        }
    }
}
