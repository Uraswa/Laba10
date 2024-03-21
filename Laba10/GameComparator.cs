using Laba10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10Classes
{
    internal class GameComparator : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;

            if (x is int xint && y is Game ygm)
            {
                if (xint == ygm.MaximumPlayers) return 0;
                


            }

            Game game1 = (Game)x;
            Game game2 = (Game)y;

            if (game1.MaximumPlayers > game2.MaximumPlayers)
            {
                return -1;
            } else if (game1.MaximumPlayers < game2.MaximumPlayers)
            {
                return 1;
            } else
            {
                return 0;
            }
        }
    }
}
