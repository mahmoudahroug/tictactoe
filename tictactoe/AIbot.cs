using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace tictactoe
{
    internal class AIbot
    {
        MainWindow m;
        Dictionary<int, int> scores = new Dictionary<int, int>{
            { 0, 0 },
            {XOBoard.human+1, -1 },
            { XOBoard.ai+1, 1 }
        };
        public AIbot(MainWindow m) {
            this.m = m;
        }
        public void aiplay()
        {
            //Random r = new Random();
            //int x = r.Next(3);
            //int y = r.Next(3);
            //while (XOBoard.ticgb[x, y] != '0') {
            //    x = r.Next(3);
            //    y = r.Next(3);
            //}
            int bestScore = Int32.MinValue;
            Point bestMove = new Point();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++) 
                {
                    if (XOBoard.ticgb[i,j] == '0')
                    {
                        XOBoard.ticgb[i, j] = XOBoard.xo[XOBoard.ai];
                        int score = minimax(false);
                        XOBoard.ticgb[i, j] = '0';
                        if(score > bestScore)
                        {
                            bestScore = score;
                            bestMove = new Point(i,j);
                        }
                    }
                }
            }
            m.placeXO(bestMove.X, bestMove.Y);
        }
        private int minimax(bool maximize)
        {
            bool win = XOBoard.checkWin();
            if(!win && XOBoard.gameOver())
            {
                return 0;
            }
            if (win)
            {
                return scores[XOBoard.getWinner()];
            }
            int bestScore;
            if (maximize)
            {
                bestScore = Int32.MinValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (XOBoard.ticgb[i, j] == '0')
                        {
                            XOBoard.ticgb[i, j] = XOBoard.xo[XOBoard.ai];
                            int score = minimax(false);
                            XOBoard.ticgb[i, j] = '0';
                            bestScore = Math.Max(score, bestScore);
                        }
                    }
                }
            }
            else
            {
                bestScore = Int32.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (XOBoard.ticgb[i, j] == '0')
                        {
                            XOBoard.ticgb[i, j] = XOBoard.xo[XOBoard.human];
                            int score = minimax(true);
                            XOBoard.ticgb[i, j] = '0';
                            bestScore = Math.Min(score, bestScore);
                        }
                    }
                }
            }
            return bestScore;
        }
    }
}
