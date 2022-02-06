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
            InitializeComponent();
            Map map = new Map();
            Utils._map = map;
            map.Show();
            Utils._players.Add(new Player("Test", VerticalAlignment.Bottom, HorizontalAlignment.Right, "test1.png"));
            Utils._players.Add(new Player("WinsomeQuill", VerticalAlignment.Top, HorizontalAlignment.Right, "test1.png"));
            new DevWindow().Show();
            foreach (Player item in Utils._players)
            {
                item.SetPosition(1);
            }
            Close();
        }
    }
}
