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
        public static Dictionary<int, int[]> _list_cages = new Dictionary<int, int[]> { }; // хэширование клеток поля, имеет след. представление [key: index, value: [column, row]]
                                                                                           // где index - номер клетки, column - номер колонки, row - номер столбца
        public const int _size = 22; // размер игрового поля
    }
}
