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
        private int column = 0; // временная переменная
        private int row = 4; // временная переменная
        private int size = 22; // размер игрового поля
        private int count = 1; // используется для форматирования текста (номер игровой клетки)
        private bool reverse = false; // используется для обратной нумерации клеток в колонке, таким образом, игровое поле имеет вид змейки
        public Map()
        {
            InitializeComponent();
            
            while(size != 0)
            {

                if (column == 5)
                {
                    column = 0;
                    row--;
                    size--;
                    if (reverse)
                    {
                        reverse = false;
                    }
                    else
                    {
                        reverse = true;
                    }
                    AddCage();
                    column++;
                    continue;
                }

                /*Deprecated
                if (row == 0)
                {
                    row = 5;
                    column++;
                    size--;
                    row--;
                    AddCage();
                    continue;
                }*/

                AddCage();
                column++;
                size--;
            }
        }

        private void AddCage()
        {
            
            if(!reverse)
            {
                Label label = new Label
                {
                    Content = "Text" + count
                };
                GridMap.Children.Add(label);
                label.SetValue(Grid.ColumnProperty, column);
                label.SetValue(Grid.RowProperty, row);
                count++;
            }
            else
            {
                Label label = new Label
                {
                    Content = "Text" + count
                };
                GridMap.Children.Add(label);
                label.SetValue(Grid.ColumnProperty, (column - 4) * -1);
                label.SetValue(Grid.RowProperty, row);
                count++;
            }
        }
    }
}
