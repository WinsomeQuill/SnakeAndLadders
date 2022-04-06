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
            foreach (Player item in Utils._players)
            {
                ComboBoxDev1.Items.Add($"{item._Name}");
            }
            ComboBoxDev1.SelectedIndex = 0;
            UpdateScrollViewerDev2();
        }

        private void ButtonDevDice_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Player player = Utils._players[random.Next(0, Utils._players.Count)];
            int number_cage = random.Next(1, 7);
            player.AddPosition(number_cage);
            UpdateScrollViewerDev2();
            MessageBox.Show($"[{player._Name}] Dice: {number_cage}");
        }

        private void ButtonDev1_Click(object sender, RoutedEventArgs e)
        {
            string name = ComboBoxDev1.Text;
            int cage_number = Convert.ToInt32(TextBoxDev1.Text);
            foreach (Player item in Utils._players)
            {
                if(item._Name == name)
                {
                    item.SetPosition(cage_number);
                    UpdateScrollViewerDev2();
                    return;
                }
            }
        }

        public void UpdateScrollViewerDev2()
        {
            StackPanelDev2.Children.Clear();
            foreach (Player item in Utils._players)
            {
                StackPanelDev2.Children.Add(new TextBlock { Text = $"{item._Name} - Pos: {item._PositionCage} R: {item._Position[0]} C: {item._Position[1]}" });
            }
        }
    }
}
