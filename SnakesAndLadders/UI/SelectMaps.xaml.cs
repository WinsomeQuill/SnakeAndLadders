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
using System.Windows.Shapes;

namespace SnakesAndLadders.UI
{
    /// <summary>
    /// Логика взаимодействия для SelectMaps.xaml
    /// </summary>
    public partial class SelectMaps : Window
    {
        private List<Image> maps = new List<Image>();
        public SelectMaps()
        {
            InitializeComponent();
            string myJsonString = File.ReadAllText("Maps.json");
            JObject myJObject = JObject.Parse(myJsonString);

            foreach (var item in myJObject.SelectToken("Maps"))
            {
                ComboBoxSelectMap.Items.Add(new ComboBoxItem
                {
                    Tag = $"{item.FirstOrDefault().SelectToken("Name")}",
                    Content = $"{item.FirstOrDefault().SelectToken("Name")}",
                });

                maps.Add(new Image
                {
                    Source = new BitmapImage(new Uri($@"{Directory.GetCurrentDirectory()}/maps/{item.FirstOrDefault().SelectToken("Image")}")),
                    Tag = $"{item.FirstOrDefault().SelectToken("Name")}",
                });
            }

            (ComboBoxSelectMap.Items[0] as ComboBoxItem).IsSelected = true;
            ImageMapPreview.Source = maps[0].Source;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(Image item in maps)
            {
                if(item == null)
                {
                    return;
                }
            }

            ImageMapPreview.Source = maps[ComboBoxSelectMap.SelectedIndex].Source;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string myJsonString = File.ReadAllText("Maps.json");
            JObject myJObject = JObject.Parse(myJsonString);

            ComboBoxItem a = ComboBoxSelectMap.SelectedItem as ComboBoxItem;
            string map = a.Tag.ToString();

            MapSettings._name = map;
            MapSettings._size = (int)myJObject.SelectToken("Maps").SelectToken(map).SelectToken("Size");
            MapSettings._snakes = myJObject.SelectToken("Maps").SelectToken(map).SelectToken("Snakes");
            MapSettings._ladders = myJObject.SelectToken("Maps").SelectToken(map).SelectToken("Ladders");
            MapSettings._image = new Image { Source = new BitmapImage(new Uri($@"{Directory.GetCurrentDirectory()}/maps/{myJObject.SelectToken("Maps").SelectToken(map).SelectToken("Image")}")) };
            MapSettings.cachedmap();
            new Authorization().Show();
            this.Close();
        }
    }
}
