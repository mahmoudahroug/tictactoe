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
        SolidColorBrush[] colour = { new SolidColorBrush(Colors.Blue), new SolidColorBrush(Colors.Red) };
        bool win = false;
        Button[] albutt;
        public MainWindow()
        {
            InitializeComponent();
            albutt = new Button[] { butt1, butt2, butt3, butt4, butt5, butt6, butt7, butt8, butt9 };
        }
        private void placeXO(int numButton)
        {
            if (albutt[numButton].Content.ToString() == "")
            {
                // map button to array
                XOBoard.placeXO(numButton/3, numButton%3);
                loadBoard();

                win = XOBoard.IsWinner();
                // if last turn and no win
                if (XOBoard.gameTurn >= 9 && !win)
                {
                    textdisplay.Text = "It's a draw";
                    Play.Visibility = Visibility.Visible;
                }
                else if (!win)
                {
                    textdisplay.Text = "Player " + XOBoard.getPlayer().ToString() + "'s turn";
                }
                if (win)
                {
                    textdisplay.Text = "Player " + XOBoard.getWinner().ToString() + " wins";
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
            XOBoard.resetGame();
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
                    albutt[3*i + j].Content = XOBoard.ticgb[i,j] == '0'? "": XOBoard.ticgb[i,j].ToString();
                    albutt[3 * i + j].Foreground = XOBoard.ticgb[i, j] == 'X'? colour[0] : colour[1];
                }
            }
        }
    }
}
