using SnakesAndLadders.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SnakesAndLadders
{
    public class Player
    {
        public string _Name { get; set; }
        public int[] _Position { get; set; } = { 0, 0 };
        public int _PositionCage { get; set; } = 0;
        public VerticalAlignment _VerticalAlignment { get; set; }
        public HorizontalAlignment _HorizontalAlignment { get; set; }
        private Image _Image { get; set; }

        public Player(string name, VerticalAlignment vertical, HorizontalAlignment horizantal, string image_path)
        {
            _Name = name;
            _VerticalAlignment = vertical;
            _HorizontalAlignment = horizantal;
            _Image = new Image { Source = new BitmapImage(
                new Uri($@"pack://application:,,,/SnakesAndLadders;component/Resources/PlayersIcon/{image_path}")), 
                Width = 75, Height = 75 };
            Init();
        }

        public void Init()
        {
            Utils._map.GridMap.Children.Add(_Image);
            Color color = Color.FromArgb(1, 64, 64, 64);

            DropShadowEffect shadow = new DropShadowEffect
            {
                Color = color,
                Direction = 180,
                ShadowDepth = 10,
                Opacity = 0.5
            };

            _Image.Effect = shadow;
            _Image.Visibility = Visibility.Hidden;
        }

        public void SetPosition(int cage_number, bool silent = false)
        {
            int[] pos = Utils.GetGridPositionByCageNumber(cage_number);
            _Position = pos;
            _PositionCage = cage_number;

            if (Utils.GetPlayersInCage(_PositionCage).Count >= 2)
            {
                AlterFormat(true);
            }
            else
            {
                AlterFormat(false);
            }

            if (cage_number != 0)
            {
                _Image.SetValue(Grid.RowProperty, pos[0]);
                _Image.SetValue(Grid.ColumnProperty, pos[1]);
            }

            int result = Utils.IsLadder(this);
            if (result != 0)
            {
                Utils.AddLog($"Игрок {_Name} попал на лестницу и перешел на {result}!");
                SetPosition(result);
                return;
            }

            result = Utils.IsSnake(this);
            if (result != 0)
            {
                Utils.AddLog($"Игрок {_Name} попал на змею и перешел на {result}!");
                SetPosition(result);
                return;
            }

            if (!silent) { Utils.AddLog($"Игрок {_Name} перешел на {cage_number}!"); }
        }

        public void AddPosition(int dice_number)
        {
            Task.Factory.StartNew(async () =>
            {
                await Application.Current.Dispatcher.InvokeAsync(async () =>
                {
                    if (_Image.Visibility == Visibility.Hidden) _Image.Visibility = Visibility.Visible;

                    for (int i = 0; i < dice_number; i++)
                    {
                        _PositionCage += 1;
                        _Position = Utils.GetGridPositionByCageNumber(_PositionCage);
                        _Image.SetValue(Grid.RowProperty, _Position[0]);
                        _Image.SetValue(Grid.ColumnProperty, _Position[1]);

                        if (_PositionCage >= MapSettings._size * MapSettings._size)
                        {
                            // Win event
                            SetPosition(MapSettings._size * MapSettings._size, true);
                            MessageBox.Show($"Игрок {_Name} выиграл!", "Конец игры!", MessageBoxButton.OK, MessageBoxImage.Information);
                            new Start().Show();
                            Utils._map.Close();
                            Utils._players.Clear();
                            Utils._currentPlayer = 0;
                            if (Utils._debug)
                            {
                                Utils._devWindow.Close();
                            }
                            return;
                        }

                        if (Utils.GetPlayersInCage(_PositionCage).Count >= 2)
                        {
                            AlterFormat(true);
                        }
                        else
                        {
                            AlterFormat(false);
                        }
                        await Task.Delay(500);
                    }

                    Utils.AddLog($"Игрок {_Name} перешел на {_PositionCage}!");
                    Utils._map.ButtonDiceNext.IsEnabled = true;

                    int result = Utils.IsLadder(this);
                    if (result != 0)
                    {
                        Utils.AddLog($"Игрок {_Name} попал на лестницу и перешел на {result}!");
                        SetPosition(result, true);
                        return;
                    }

                    result = Utils.IsSnake(this);
                    if (result != 0)
                    {
                        Utils.AddLog($"Игрок {_Name} попал на змею и перешел на {result}!");
                        SetPosition(result, true);
                        return;
                    }
                });
            });
        }

        private void AlterFormat(bool enabled)
        {
            List<Player> players = Utils.GetPlayersInCage(_PositionCage);
            if (enabled)
            {
                foreach (Player item in players)
                {
                    item._Image.VerticalAlignment = item._VerticalAlignment;
                    item._Image.HorizontalAlignment = item._HorizontalAlignment;
                }
            }
            else
            {
                foreach (Player item in players)
                {
                    item._Image.VerticalAlignment = VerticalAlignment.Center;
                    item._Image.HorizontalAlignment = HorizontalAlignment.Center;
                }
            }
        }
    }
}
