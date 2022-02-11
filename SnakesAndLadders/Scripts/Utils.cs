using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static bool _debug = false;
        public static List<Player> _players = new List<Player>();
        public static int _currentPlayer = 0;
        public static int GetCageNumberByGrid(int row, int column)
        {
            return MapSettings._cachemap[row, column];
        }

        public static int[] GetGridPositionByCageNumber(int number)
        {
            for (int i = 0; i < MapSettings._size; i++)
            {
                for (int j = 0; j < MapSettings._size; j++)
                {
                    if(MapSettings._cachemap[i, j] == number)
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
            if(_debug)
            {
                _devWindow.UpdateScrollViewerDev2();
            }
        }

        public static int Dice()
        {
            Random random = new Random();
            int number_cage = random.Next(1, 7);
            return number_cage;
        }

        public static int IsLadder(Player player)
        {
            foreach(JToken item in MapSettings._ladders)
            {
                if(Convert.ToInt32(item[0]) == player._Position_Cage)
                {
                    return Convert.ToInt32(item[1]);
                }
            }

            return 0;
        }

        public static int IsSnake(Player player)
        {
            foreach (JToken item in MapSettings._snakes)
            {
                if (Convert.ToInt32(item[0]) == player._Position_Cage)
                {
                    return Convert.ToInt32(item[1]);
                }
            }

            return 0;
        }
    }
}
