using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : Page
    {// player colors
        SolidColorBrush[] colour = { new SolidColorBrush(Colors.Blue), new SolidColorBrush(Colors.Red) };
        bool win;
        Button[] albutt;
        bool[] asserted;
        // play against ai?
        bool computer = true;
        AIbot bot;
        public Board()
        {
            InitializeComponent();

            albutt = new Button[] { butt1, butt2, butt3, butt4, butt5, butt6, butt7, butt8, butt9 };
            asserted = new bool[9];
            bot = new AIbot(this);
            win = false;
            foreach(Button b in albutt)
            {
                b.MouseEnter += XO_MouseEnter;
                b.MouseLeave += XO_MouseLeave;

            }
        }
        public void setComputer(bool comp)
        {
            computer = comp;
        }
        private void placeXO(int numButton)
        {
            if (!asserted[numButton])
            {
                if (win) { return; }
                // map button to array
                placeXO(numButton / 3, numButton % 3);

                // if against computer make computer play here
                if (computer) { bot.aiplay(); }
            }
        }
        public void placeXO(int x, int y)
        {
            XOBoard.placeXO(x, y);
            loadBoard();
            asserted[3*x+y] = true;
            win = XOBoard.checkWin();
            // if last turn and no win
            if (XOBoard.gameTurn >= 9 && !win)
            {
                textdisplay.Text = "It's a draw";
                Play.Visibility = Visibility.Visible;
                return;
            }
            else if (!win)
            {
                textdisplay.Text = "Player " + XOBoard.getPlayer().ToString() + "'s turn";

            }
            if (win)
            {
                textdisplay.Text = "Player " + XOBoard.getWinner().ToString() + " wins";
                Play.Visibility = Visibility.Visible;
                return;
            }
        }

        private void XO_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            // get index of button pressed
            int Buttonpressed = button.Name[4] - '0' - 1;
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
            asserted = new bool[9];
            Play.Visibility = Visibility.Collapsed;
            textdisplay.Text = "Player 1's turn";
        }
        private void loadBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    albutt[3 * i + j].Content = XOBoard.ticgb[i, j] == '0' ? "" : XOBoard.ticgb[i, j].ToString();
                    albutt[3 * i + j].FontSize = 0.7*Math.Min(albutt[3*i+j].ActualHeight, albutt[3 * i + j].ActualWidth);
                    albutt[3 * i + j].Foreground = XOBoard.ticgb[i, j] == 'X' ? colour[0] : colour[1];
                }
            }
        }
        private void XO_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            int currButton = button.Name[4] - '0' - 1;
            if (button != null && asserted[currButton] == false)
            {
                button.FontSize = 100;
                button.Content = XOBoard.xo[XOBoard.getPlayer()-1];
                button.Foreground = colour[XOBoard.getPlayer()-1];
            }
        }

        private void XO_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            int currButton = button.Name[4] - '0' - 1;
            if (button != null && asserted[currButton] == false)
            {
                button.Content = "";
            }
        }
    }
}
