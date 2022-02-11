using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SelectPlayersCount.xaml
    /// </summary>
    public partial class SelectPlayersCount : Window
    {
        public SelectPlayersCount()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new Start().Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MapSettings._players_count = ComboBoxPlayersCount.SelectedIndex + 2;
            new SelectMaps().Show();
            this.Close();
        }
    }
}
