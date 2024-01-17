using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    internal class AIbot
    {
        MainWindow m;
        public AIbot(MainWindow m) {
            this.m = m;
        }
        public void aiplay()
        {
            Random r = new Random();
            int x = r.Next(3);
            int y = r.Next(3);
            while (XOBoard.ticgb[x, y] != '0') {
                x = r.Next(3);
                y = r.Next(3);
            }
            m.placeXO(x, y);
        }
    }
}
