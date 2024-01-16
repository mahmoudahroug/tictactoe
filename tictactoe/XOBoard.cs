using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    internal class XOBoard
    {
        public static char[,] ticgb = { { '0', '0', '0' },
                                      { '0', '0', '0' },
                                      { '0', '0', '0' } };
        protected static int player = 0;
        static char[] xo = { 'X', 'O' };
        protected static int gameTurn = 0;
        protected static bool IsWinner()
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
        protected static void resetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ticgb[i, j] = '0';
                }
            }
            player = 0;
            gameTurn = 0;
        }
    }

}
