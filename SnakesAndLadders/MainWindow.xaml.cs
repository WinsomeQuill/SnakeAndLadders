﻿using System;
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
            new DevWindow().Show();
            Player player = new Player("Test");
            Player player1 = new Player("WinsomeQuill");
            Utils._players.Add(player);
            Utils._players.Add(player1);
            Close();
        }
    }
}
