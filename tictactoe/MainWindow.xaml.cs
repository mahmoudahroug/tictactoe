using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        char[,] ticgb = { { '0', '0', '0' }, 
                          { '0', '0', '0' }, 
                          { '0', '0', '0' } };
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
                if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0'
                    || (ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0'))
                {
                    return true;
                }
            }
            if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0'
                || (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0'))
            {
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
                // map button to array
                ticgb[numButton/3, numButton%3] = xo[player];
                counter++;

                win = IsWinner();
                // if last turn and no win
                if (counter >= 9 && !win)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }
                else if (!win)
                {
                    // switch player
                    player = player == 0 ? 1 : 0;

                    textdisplay.Text = "Player " + (player + 1).ToString() + "'s turn";
                }
                if (win)
                {
                    textdisplay.Text = "Player " + (player + 1).ToString() + " wins";
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
            // get index of button pressed
            int Buttonpressed = ((Button)sender).Name[4] - '0' - 1;
            placeXO(Buttonpressed);
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
            counter = 0;
            win = false;
            Play.Visibility = Visibility.Collapsed;
            textdisplay.Text = "Player 1's turn";
        }
        private void loadBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    albutt[3*i + j].Content = XOBoard.ticgb[i,j];
                }
            }
        }
    }
}
