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
        private int _column = 0; // временная переменная
        private int _row = 4; // временная переменная
        private int _size_temp = Utils._size;
        private int _count = 1; // используется для форматирования текста (номер игровой клетки)
        private bool _reverse = false; // используется для обратной нумерации клеток в колонке, таким образом, игровое поле имеет вид змейки
        
        public Map()
        {
            InitializeComponent();
            
            while(_size_temp != 0)
            {

                if (_column == 5)
                {
                    _column = 0;
                    _row--;
                    _size_temp--;
                    if (_reverse)
                    {
                        _reverse = false;
                    }
                    else
                    {
                        _reverse = true;
                    }
                    AddCage();
                    _column++;
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
                _column++;
                _size_temp--;
            }
        }

        private void AddCage()
        {
            
            if(!_reverse)
            {
                Label label = new Label
                {
                    Content = "Text" + _count
                };
                GridMap.Children.Add(label);
                label.SetValue(Grid.ColumnProperty, _column);
                label.SetValue(Grid.RowProperty, _row);
                Utils._list_cages.Add(_count, new int[] { _column, _row });
                _count++;
            }
            else
            {
                Label label = new Label
                {
                    Content = "Text" + _count
                };
                GridMap.Children.Add(label);
                label.SetValue(Grid.ColumnProperty, (_column - 4) * -1);
                label.SetValue(Grid.RowProperty, _row);
                Utils._list_cages.Add(_count, new int[] { _column, _row });
                _count++;
            }
        }
    }
}
