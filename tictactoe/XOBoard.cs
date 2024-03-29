﻿using System;
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
        private static int player = 0;
        public static char[] xo = { 'X', 'O' };
        public static int gameTurn = 0;
        public static int human = 0;
        public static int ai = 1;

        public static int getPlayer() {  return player+1; }
        public static int getWinner() { 
            for(int i = 0; i < 3; i++) 
            {
                if (ticgb[0, i] == ticgb[1, i] && ticgb[2, i] == ticgb[1, i] && ticgb[2, i] != '0')
                {
                    return ticgb[0,i] == 'X'? 1: 2 ;
                }
                if(ticgb[i, 0] == ticgb[i, 1] && ticgb[i, 2] == ticgb[i, 1] && ticgb[i, 2] != '0')
                {
                    return ticgb[i, 0] == 'X' ? 1 : 2;
                }
            }
            if (ticgb[0, 0] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 2] && ticgb[2, 2] != '0'
                || (ticgb[0, 2] == ticgb[1, 1] && ticgb[1, 1] == ticgb[2, 0] && ticgb[2, 0] != '0'))
            {
                return ticgb[1, 1] == 'X' ? 1: 2 ;
            }
            return 0;

        }
        public static bool checkWin()
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
        public static bool gameOver()
        {
            for(int i = 0; i < 3; i++) 
            { 
                for (int j = 0; j < 3; j++)
                {
                    if (ticgb[i, j] == '0')
                        return false;
                }
            }
            return true;
        }
        public static void resetGame()
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
        public static void placeXO(int x, int y)
        {
            if (ticgb[x, y] != '0')
            {
                return;
            }
            ticgb[x, y] = xo[player];
            gameTurn++;
            // switch player
            player = 1-player;
        }
                
    }

}
