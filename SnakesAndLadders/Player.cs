using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SnakesAndLadders
{
    public class Player
    {
        public Player(string name, VerticalAlignment vertical, HorizontalAlignment horizantal, string image_path)
        {
            this._Name = name;
            this._VerticalAlignment = vertical;
            this._HorizontalAlignment = horizantal;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri($@"pack://application:,,,/SnakesAndLadders;component/Resources/{image_path}");
            bitmap.EndInit();
            this._image = new Image { Source = bitmap, Width = 75, Height = 75 };
            Utils._map.GridMap.Children.Add(this._image);
        }

        public string _Name { get; set; }
        public int[] _Position { get; set; } = { 0, 0 };
        public int _Position_Cage { get; set; } = 1;
        public VerticalAlignment _VerticalAlignment { get; set; }
        public HorizontalAlignment _HorizontalAlignment { get; set; }
        private Image _image { get; set; }

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
            
            this._image.SetValue(Grid.RowProperty, pos[0]);
            this._image.SetValue(Grid.ColumnProperty, pos[1]);
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
            this._image.SetValue(Grid.RowProperty, row);
            this._image.SetValue(Grid.ColumnProperty, column);
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
            this._image.SetValue(Grid.RowProperty, this._Position[0]);
            this._image.SetValue(Grid.ColumnProperty, this._Position[1]);
        }

        private void AlterFormat(bool enabled)
        {
            List<Player> players = Utils.GetPlayersInCage(this._Position_Cage);
            if (enabled)
            {
                foreach (Player item in players)
                {
                    item._image.VerticalAlignment = item._VerticalAlignment;
                    item._image.HorizontalAlignment = item._HorizontalAlignment;
                }
            }
            else
            {
                foreach (Player item in players)
                {
                    item._image.VerticalAlignment = VerticalAlignment.Center;
                    item._image.HorizontalAlignment = HorizontalAlignment.Center;
                }
            }
        }
    }
}
