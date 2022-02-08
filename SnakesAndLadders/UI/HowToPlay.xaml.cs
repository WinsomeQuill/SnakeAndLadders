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
    /// Логика взаимодействия для HowToPlay.xaml
    /// </summary>
    public partial class HowToPlay : Window
    {
        public HowToPlay()
        {
            InitializeComponent();
        }

        private void Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new Start().Show();
            this.Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
