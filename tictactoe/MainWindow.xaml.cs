﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
        private bool IsWinner()
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
        private void placeXO(int numButton)
        {
            if (albutt[numButton].Content.ToString() == "")
            {
                albutt[numButton].Content = xo[player];
                albutt[numButton].Foreground = colour[player];
                ticgb[0, 0] = xo[player];
                counter++;

                win = IsWinner();
                // if last turn and no win
                if (counter >= 9 && win == false)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }
                else if (win == false)
                {
                    // switch player
                    player = player == 0 ? 1 : 0;

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

        private void XO_Click(object sender, RoutedEventArgs e)
        {
            // gets index of button pressed
            int Buttonpressed = ((Button)sender).Name[Name.Length - 1] - '0' - 1;
            placeXO(Buttonpressed);
        }

        private void butt2_Click(object sender, RoutedEventArgs e)
        {
            placeXO(1);
        }

        private void butt3_Click(object sender, RoutedEventArgs e)
        {
            placeXO(2);
        }
        

        private void butt4_Click(object sender, RoutedEventArgs e)
        {
            placeXO(3);
        }

        private void butt5_Click(object sender, RoutedEventArgs e)
        {
            placeXO(4);
        }

        private void butt6_Click(object sender, RoutedEventArgs e)
        {
            placeXO(5);
        }

        private void butt7_Click(object sender, RoutedEventArgs e)
        {
            placeXO(6);
        }

        private void butt8_Click(object sender, RoutedEventArgs e)
        {
            placeXO(7);
        }

        private void butt9_Click(object sender, RoutedEventArgs e)
        {
            placeXO(8);
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
