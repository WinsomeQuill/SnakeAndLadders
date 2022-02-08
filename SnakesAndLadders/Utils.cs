using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SnakesAndLadders
{
    public static class Utils
    {
        public static Map _map { get; set; }
        public static DevWindow _devWindow { get; set; }
        public static List<Player> _players = new List<Player>();
        public const int _size = 6; // размер игрового поля, расчитывается по формуле матрицы N * N
        public static int[,] _cachemap = new int[_size, _size]; // хэширование клеток поля, имеет след. представление [index, [column, row]]
                                                                       // где index - номер клетки, column - номер колонки, row - номер столбца
        private static int _nextPlayer = 0;
        public static int GetCageNumberByGrid(int row, int column)
        {
            return _cachemap[row, column];
        }

        public static int[] GetGridPositionByCageNumber(int number)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if(_cachemap[i, j] == number)
                    {
                        int[] arr = { i, j };
                        return arr;
                    }
                }
            }
            return new int[] {-1, -1};
        }

        public static List<Player> GetPlayersInCage(int number)
        {
            List<Player> players = new List<Player>();
            foreach (Player item in _players)
            {
                if (item._Position_Cage == number)
                {
                    players.Add(item);
                }
            }
            return players;
        }

        public static void AddLog(string message)
        {
            _map.TextBlockLog.Text += message + "\n";
            _devWindow.UpdateScrollViewerDev2();
        }

        public static int Dice()
        {
            Random random = new Random();
            int number_cage = random.Next(1, 7);
            return number_cage;
        }

        public static Player WalkNow()
        {
            if (_nextPlayer > _players.Count - 1)
            {
                _nextPlayer = 0;
            }
            Player player = _players[_nextPlayer];
            _nextPlayer++;
            return player;
        }
    }
}
