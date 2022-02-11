﻿using SnakesAndLadders.UI;
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
            this._image = new Image { Source = new BitmapImage(new Uri($@"pack://application:,,,/SnakesAndLadders;component/Resources/PlayersIcon/{image_path}")), Width = 75, Height = 75 };
            Utils._map.GridMap.Children.Add(this._image);
        }

        public string _Name { get; set; }
        public int[] _Position { get; set; } = { 0, 0 };
        public int _Position_Cage { get; set; } = 1;
        public VerticalAlignment _VerticalAlignment { get; set; }
        public HorizontalAlignment _HorizontalAlignment { get; set; }
        private Image _image { get; set; }

        public void SetPosition(int cage_number, bool silent = false)
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

            int result = Utils.IsLadder(this);
            if (result != 0)
            {
                Utils.AddLog($"Игрок {this._Name} попал на лестницу и перешел на {result}!");
                this.SetPosition(result);
                return;
            }

            result = Utils.IsSnake(this);
            if (result != 0)
            {
                Utils.AddLog($"Игрок {this._Name} попал на змею и перешел на {result}!");
                this.SetPosition(result);
                return;
            }

            if (!silent) { Utils.AddLog($"Игрок {this._Name} перешел на {cage_number}!"); }
        }

        public void AddPosition(int dice_number)
        {
            this._Position_Cage += dice_number;
            if(this._Position_Cage >= MapSettings._size * MapSettings._size)
            {
                // Win event
                this.SetPosition(MapSettings._size * MapSettings._size, true);
                MessageBox.Show($"Игрок {this._Name} выиграл!", "Конец игры!", MessageBoxButton.OK, MessageBoxImage.Information);
                new Start().Show();
                Utils._map.Close();
                Utils._players.Clear();
                Utils._nextPlayer = 0;
                if(Utils._debug)
                {
                    Utils._devWindow.Close();
                }
                return;
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

            Utils.AddLog($"Игрок {this._Name} перешел на {this._Position_Cage}!");

            int result = Utils.IsLadder(this);
            if (result != 0)
            {
                Utils.AddLog($"Игрок {this._Name} попал на лестницу и перешел на {result}!");
                this.SetPosition(result, true);
                return;
            }

            result = Utils.IsSnake(this);
            if (result != 0)
            {
                Utils.AddLog($"Игрок {this._Name} попал на змею и перешел на {result}!");
                this.SetPosition(result, true);
                return;
            }
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
