using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakesAndLadders
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if(!File.Exists("Maps.json"))
            {
                MessageBox.Show("Конфиг Maps.json не найден!");
                Close();
                return;
            }

            InitializeComponent();

            string myJsonString = File.ReadAllText("Maps.json");
            JObject myJObject = JObject.Parse(myJsonString);
            string map_json = myJObject.SelectToken("Map").Value<string>();

            MapSettings._name = map_json;
            MapSettings._size = (int)myJObject.SelectToken("Maps").SelectToken(map_json).SelectToken("Size");
            MapSettings._snakes = myJObject.SelectToken("Maps").SelectToken(map_json).SelectToken("Snakes");
            MapSettings._ladders = myJObject.SelectToken("Maps").SelectToken(map_json).SelectToken("Ladders");
            MapSettings.cachedmap();

            Map map = new Map();
            Utils._map = map;
            Utils._players.Add(new Player("Test", VerticalAlignment.Bottom, HorizontalAlignment.Right, $"Players_1.png"));
            Utils._players.Add(new Player("WinsomeQuill", VerticalAlignment.Top, HorizontalAlignment.Right, $"Players_2.png"));
            DevWindow dev = new DevWindow();
            map.Show();
            dev.Show();
            Utils._devWindow = dev;
            foreach (Player item in Utils._players)
            {
                item.SetPosition(1, true);
            }
            Close();
            Utils._map.TextBlockInformer.Text = $"Сейчас ходит игрок \"{Utils.WalkNow()._Name}\"";
        }
    }
}
