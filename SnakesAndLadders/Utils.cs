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
        public static List<Player> _players = new List<Player>();
        public const int _size = 5; // размер игрового поля, расчитывается по формуле матрицы N * N
        public static int[,] _cachemap = new int[_size, _size]; // хэширование клеток поля, имеет след. представление [index, [column, row]]
                                                                       // где index - номер клетки, column - номер колонки, row - номер столбца
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
    }
}
