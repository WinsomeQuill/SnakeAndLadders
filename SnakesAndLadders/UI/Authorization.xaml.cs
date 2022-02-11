using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            int count = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if(MapSettings._players_count <= count)
                    {
                        return;
                    }

                    count++;
                    Label label = new Label
                    {
                        Content = "Игрок " + count,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 16,
                        FontFamily = new FontFamily("Arial"),
                        FontWeight = FontWeights.Bold,
                    };

                    TextBox textBox = new TextBox
                    {
                        Name = "TextBoxPlayer" + count,
                        Margin = new Thickness(5),
                        Height = 35,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                    };

                    GridStackAuth.Children.Add(label);
                    GridStackAuth.Children.Add(textBox);
                    textBox.SetValue(Grid.ColumnProperty, i);
                    textBox.SetValue(Grid.RowProperty, j);
                    label.SetValue(Grid.ColumnProperty, i);
                    label.SetValue(Grid.RowProperty, j);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Map map = new Map();
            Utils._map = map;
            int count = 0;
            for(int i = 0; i < GridStackAuth.Children.Count; i++)
            {
                if (GridStackAuth.Children[i] is TextBox)
                {
                    TextBox item = GridStackAuth.Children[i] as TextBox;

                    if (item.Text.Length == 0)
                    {
                        TextBoxWarning(item);
                        MessageBox.Show("Заполните все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (item.Text.Length < 3)
                    {
                        TextBoxWarning(item);
                        MessageBox.Show("Имя игрока должно состоять минимум из трёх символов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (item.Text.Length > 15)
                    {
                        TextBoxWarning(item);
                        MessageBox.Show($"У \"Игрок {count+1}\" слишком длинное имя!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    switch (count)
                    {
                        case 0:
                            Utils._players.Add(new Player(item.Text, VerticalAlignment.Bottom, HorizontalAlignment.Right, $"Players_1.png"));
                       break;

                        case 1:
                            Utils._players.Add(new Player(item.Text, VerticalAlignment.Top, HorizontalAlignment.Right, $"Players_2.png"));
                            break;

                        case 2:
                            Utils._players.Add(new Player(item.Text, VerticalAlignment.Bottom, HorizontalAlignment.Left, $"Players_3.png"));
                            break;

                        case 3:
                            Utils._players.Add(new Player(item.Text, VerticalAlignment.Top, HorizontalAlignment.Left, $"Players_4.png"));
                            break;
                    }
                    count++;
                }
            }
            
            if(Utils._debug)
            {
                DevWindow dev = new DevWindow();
                dev.Show();
                Utils._devWindow = dev;
            }

            map.Show();
            foreach (Player item in Utils._players)
            {
                item.SetPosition(1, true);
            }
            Utils._map.TextBlockInformer.Text = $"Сейчас ходит игрок \"{Utils._players[0]._Name}\"";
            Close();
        }

        private void TextBoxWarning(TextBox textBox)
        {
            Task.Run(async () =>
            {
                await Dispatcher.InvokeAsync(async () =>
                {
                    textBox.Background = new SolidColorBrush(Colors.IndianRed);
                    await Task.Delay(500);
                    textBox.Background = new SolidColorBrush(Colors.White);
                    await Task.Delay(500);
                    textBox.Background = new SolidColorBrush(Colors.IndianRed);
                    await Task.Delay(500);
                    textBox.Background = new SolidColorBrush(Colors.White);
                });
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
