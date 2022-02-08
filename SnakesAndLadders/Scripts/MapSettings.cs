using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public static class MapSettings
    {
        public static int _size { get; set; }
        public static string _name { get; set; }
        public static JToken _snakes {  get; set; }
        public static JToken _ladders { get; set; }

        public static int[,] _cachemap { get; set; } // хэширование клеток поля, имеет след. представление [index, [column, row]]
                                                                                        // где index - номер клетки, column - номер колонки, row - номер столбца

        public static void cachedmap()
        {
            _cachemap = new int[_size, _size];
        }
    }
}
