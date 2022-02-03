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
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameLauncher.Launcher launcher = new GameLauncher.Launcher();
            launcher.Show();
            this.Close();
        }

        private void Login_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox lg = (TextBox)sender;
            lg.Text = string.Empty;
            lg.GotFocus -= Login_GotFocus;
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pt = (PasswordBox)sender;
            pt.Password = string.Empty;
            pt.GotFocus -= Password_GotFocus;
        }
    }
}
