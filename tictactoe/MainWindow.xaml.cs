using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char[,] ticgb = { { '0', '0', '0' }, { '0', '0', '0' }, { '0', '0', '0' } };
        int player = 0;
        char[] xo = { 'X', 'O' };
        SolidColorBrush[] colour = { new SolidColorBrush(Colors.Blue), new SolidColorBrush(Colors.Red) };
        bool win = false;
        int counter = 0;
        Button[] albutt;
        public MainWindow()
        {
            InitializeComponent();
            albutt = new Button[] { butt1, butt2, butt3, butt4, butt5, butt6, butt7, butt8, butt9 };
        }
        private bool IsWin(int player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    return true;
                }
                else if (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    return true;
                }
            }
            if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0')
            {
                textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                return true;
            }
            else if (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0')
            {
                textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                return true;
            }
            return false;
        } 
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (butt1.Content == "")
            {
                butt1.Content = xo[player];
                ticgb[0, 0] = xo[player];
                butt1.Foreground = colour[player];
                counter++;
                
                if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }
                else if (win == false)
                {
                    if (player == 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 0;
                    }
                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win == true)
                {
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
            }
        }

        private void butt2_Click(object sender, RoutedEventArgs e)
        {
            if (butt2.Content == "")
            {
                butt2.Content = xo[player];
                ticgb[0, 1] = xo[player];
                butt2.Foreground = colour[player];
                counter++;
                for (int i = 0; i < 3; i++)
                {
                    if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                    else if (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                }
                if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }

                else if (win == false)
                {
                    if (player == 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 0;
                    }
                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win == true)
                {
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
            }
        }

        private void butt3_Click(object sender, RoutedEventArgs e)
        {
            if (butt3.Content == "")
            {
                butt3.Content = xo[player];
                ticgb[0, 2] = xo[player];
                butt3.Foreground = colour[player];
                counter++;
                for (int i = 0; i < 3; i++)
                {
                    if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                    else if (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                }
                if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }

                else if (win == false)
                {
                    if (player == 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 0;
                    }
                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win == true)
                {
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
            }
        }
        

        private void butt4_Click(object sender, RoutedEventArgs e)
        {
            if (butt4.Content == "")
            {
                butt4.Content = xo[player];
                ticgb[1, 0] = xo[player];
                butt4.Foreground = colour[player];
                counter++;
                for (int i = 0; i < 3; i++)
                {
                    if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                    else if (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                }
                if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
                else if (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }

                else if (win == false)
                {
                    if (player == 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 0;
                    }
                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win == true)
                {
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
            }
        }

        private void butt5_Click(object sender, RoutedEventArgs e)
        {
            if (butt5.Content == "")
            {
                butt5.Content = xo[player];
                ticgb[1, 1] = xo[player];
                butt5.Foreground = colour[player];
                counter++;
                for (int i = 0; i < 3; i++)
                {
                    if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                    else if (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                }
                if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }

                else if (win == false)
                {
                    if (player == 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 0;
                    }
                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win == true)
                {
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
            }
        }

        private void butt6_Click(object sender, RoutedEventArgs e)
        {
            if (butt6.Content == "")
            {
                butt6.Content = xo[player];
                ticgb[1, 2] = xo[player];
                butt6.Foreground = colour[player];
                counter++;
                for (int i = 0; i < 3; i++)
                {
                    if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                    else if (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                }
                if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }

                else if (win == false)
                {
                    if (player == 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 0;
                    }
                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win == true)
                {
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
            }
        }

        private void butt7_Click(object sender, RoutedEventArgs e)
        {
            if (butt7.Content == "")
            {
                butt7.Content = xo[player];
                ticgb[2, 0] = xo[player];
                butt7.Foreground = colour[player];
                counter++;
                for (int i = 0; i < 3; i++)
                {
                    if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                    else if (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                }
                if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }

                else if (win == false)
                {
                    if (player == 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 0;
                    }
                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win == true)
                {
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
            }
        }

        private void butt8_Click(object sender, RoutedEventArgs e)
        {
            if (butt8.Content == "")
            {
                butt8.Content = xo[player];
                ticgb[2, 1] = xo[player];
                butt8.Foreground = colour[player];
                counter++;
                for (int i = 0; i < 3; i++)
                {
                    if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                    else if (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                }
                if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }

                else if (win == false)
                {
                    if (player == 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 0;
                    }
                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win == true)
                {
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
            }
        }

        private void butt9_Click(object sender, RoutedEventArgs e)
        {
            if (butt9.Content == "")
            {
                butt9.Content = xo[player];
                ticgb[2, 2] = xo[player];
                butt9.Foreground = colour[player];
                counter++;
                for (int i = 0; i < 3; i++)
                {
                    if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                    else if (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                    {
                        textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                        win = true;
                    }
                }
                if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0')
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
                    win = true;
                }
                else if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }

                else if (win == false)
                {
                    if (player == 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 0;
                    }
                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win == true)
                {
                    foreach (Button butt in albutt)
                    {
                        butt.IsEnabled = false;
                    }
                    Play.Visibility = Visibility.Visible;
                }
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button butt in albutt)
            {
                butt.IsEnabled = true;
                butt.Content = "";
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j =0; j < 3; j++)
                {
                    ticgb[i,j] = '0';
                }
            }
            player = 0;
            textdisplay.Text = "Player 1's turn";
            Play.Visibility = Visibility.Collapsed;
            counter = 0;
            win = false;
        }
    }
}
