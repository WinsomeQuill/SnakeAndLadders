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

namespace SnakesAndLadders.SelectionMaps
{
    /// <summary>
    /// Логика взаимодействия для SelectMaps.xaml
    /// </summary>
    public partial class SelectMaps : Window
    {
        public SelectMaps()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            switch (ComboBoxSelectMap.SelectedIndex)
            {
                case 0:
                    Map1.Visibility = Visibility.Visible;
                    Map2.Visibility = Visibility.Collapsed;
                    Map3.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    Map1.Visibility = Visibility.Collapsed;
                    Map2.Visibility = Visibility.Visible;
                    Map3.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    Map1.Visibility = Visibility.Collapsed;
                    Map2.Visibility = Visibility.Collapsed;
                    Map3.Visibility = Visibility.Visible;
                    break;
            }

        }
    }
}
