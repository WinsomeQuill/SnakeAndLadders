using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;


namespace SnakesAndLadders.UI
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();

            if (!File.Exists("Maps.json"))
            {
                MessageBox.Show("Конфиг Maps.json не найден!");
                Close();
                return;
            }

            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            new SelectPlayersCount().Show();
            this.Close();
        }

        private void HowToPlay_Click(object sender, RoutedEventArgs e)
        {
            new HowToPlay().Show();
            this.Close();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
