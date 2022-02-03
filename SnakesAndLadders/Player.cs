using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SnakesAndLadders
{
    public class Player
    {
        public Player(string name)
        {
            this._Name = name;
            this._label = new Label
            {
                Content = $"{this._Name}",
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 10, 0, 10),
                FontSize = 12,
                FontWeight = FontWeights.Bold,
            };
            Utils._map.GridMap.Children.Add(this._label);
            SetPosition(1);
        }

        public string _Name { get; set; }
        public int[] _Position { get; set; } = { 0, 0 };
        public int _Position_Cage { get; set; } = 0;
        private Label _label { get; set; } // метка игрока, пока это просто текст

        public void SetPosition(int dice_number) // Ставит игрока на новую клетку
        {
            this._Position_Cage += dice_number;
            if(this._Position_Cage >= Utils._size)
            {
                this._Position_Cage = Utils._size;
                MessageBox.Show($"{this._Name} is winner!");
                return;
            }

            this._Position = new int[] { Utils._list_cages[_Position_Cage][0], Utils._list_cages[_Position_Cage][1] };
            this._label.SetValue(Grid.ColumnProperty, Utils._list_cages[_Position_Cage][0]);
            this._label.SetValue(Grid.RowProperty, Utils._list_cages[_Position_Cage][1]);
        }
    }
}
