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

namespace SnakesAndLadders
{
    /// <summary>
    /// Логика взаимодействия для DevWindow.xaml
    /// </summary>
    public partial class DevWindow : Window
    {
        public DevWindow()
        {
            InitializeComponent();
        }

        private void ButtonDevSetCage_Click(object sender, RoutedEventArgs e)
        {
            int number_cage = Convert.ToInt32(TextBoxDevSetCage.Text);
            int[] pos = Utils.GetGridPositionByCageNumber(number_cage);
            MessageBox.Show($"{pos[0]} : {pos[1]}");
        }

        private void ButtonDevDice_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Player player = Utils._players[random.Next(0, 2)];
            int number_cage = random.Next(1, 7);
            player.AddPosition(number_cage);
            MessageBox.Show($"[{player._Name}] Dice: {number_cage}");
        }
    }
}
