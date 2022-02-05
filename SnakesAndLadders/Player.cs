using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SnakesAndLadders
{
    public class Player
    {
        public Player(string name, VerticalAlignment vertical, HorizontalAlignment horizantal)
        {
            this._Name = name;
            this._label = new Label
            {
                Content = $"{this._Name}",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 10),
                FontSize = 12,
                FontWeight = FontWeights.Bold,
            };
            this._VerticalAlignment = vertical;
            this._HorizontalAlignment = horizantal;
            Utils._map.GridMap.Children.Add(this._label);
        }

        public string _Name { get; set; }
        public int[] _Position { get; set; } = { 0, 0 };
        public int _Position_Cage { get; set; } = 1;
        public VerticalAlignment _VerticalAlignment { get; set; }
        public HorizontalAlignment _HorizontalAlignment { get; set; }
        private Label _label { get; set; } // метка игрока, пока это просто текст

        public void SetPosition(int cage_number)
        {
            int[] pos = Utils.GetGridPositionByCageNumber(cage_number);
            this._Position = pos;
            this._Position_Cage = cage_number;

            if (Utils.GetPlayersInCage(this._Position_Cage).Count >= 2)
            {
                AlterFormat(true);
            }
            else
            {
                AlterFormat(false);
            }
            
            this._label.SetValue(Grid.RowProperty, pos[0]);
            this._label.SetValue(Grid.ColumnProperty, pos[1]);
        }

        public void SetPosition(int row, int column)
        {
            this._Position_Cage = Utils.GetCageNumberByGrid(row, column);
            if (Utils.GetPlayersInCage(this._Position_Cage).Count >= 2)
            {
                AlterFormat(true);
            }
            else
            {
                AlterFormat(false);
            }

            this._Position = new int[] { row, column };
            this._label.SetValue(Grid.RowProperty, row);
            this._label.SetValue(Grid.ColumnProperty, column);
        }

        public void AddPosition(int dice_number)
        {
            this._Position_Cage += dice_number;
            if(this._Position_Cage >= Utils._size * Utils._size)
            {
                // Win event
                this._Position_Cage = Utils._size * Utils._size;
                MessageBox.Show($"{this._Name} is winner!");
            }

            if (Utils.GetPlayersInCage(this._Position_Cage).Count >= 2)
            {
                AlterFormat(true);
            }
            else
            {
                AlterFormat(false);
            }

            this._Position = Utils.GetGridPositionByCageNumber(this._Position_Cage);
            this._label.SetValue(Grid.RowProperty, this._Position[0]);
            this._label.SetValue(Grid.ColumnProperty, this._Position[1]);
        }

        private void AlterFormat(bool enabled)
        {
            List<Player> players = Utils.GetPlayersInCage(this._Position_Cage);
            if (enabled)
            {
                foreach (Player item in players)
                {
                    item._label.VerticalAlignment = item._VerticalAlignment;
                    item._label.HorizontalAlignment = item._HorizontalAlignment;
                }
            }
            else
            {
                foreach (Player item in players)
                {
                    item._label.VerticalAlignment = VerticalAlignment.Center;
                    item._label.HorizontalAlignment = HorizontalAlignment.Center;
                }
            }
        }
    }
}
