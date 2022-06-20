using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_C_sharp
{
    internal class Card
    {

        private int suit;
        public int Suit { get { return suit; } set { suit = value; } }
        private int rank;
        public int Rank { get { return rank; } set { rank = value; } }
        public Card()
        {
            Suit = 0;
            Rank = 0;
        }

    }
}
