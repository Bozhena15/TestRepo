using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_C_sharp
{
    internal class Player
    {
        public Card[] UsefulCards;
        private string Name;
        private int money;
        private int PlBet;
        public int PlayerBet { get { return PlBet; } set { PlBet = value; } }
        public int Cash { get { return money; } set { money = value; } }
        public Card[] cards = { new Card(), new Card()};
        private bool play;
        public bool Playing
        {
            get { return play; }
            set
            {
                if (value == true || value == false)
                {
                    play = value;
                }
                else
                {

                }
            }
        }
        private bool knock;
        public bool Knock
        {
            get { return knock; }
            set
            {
                if (value == true || value == false)
                {
                    knock = value;
                }
                else
                {

                }
            }
        }
        public Player(string name)
        {
            UsefulCards = new Card[5] { new Card() ,new Card(),new Card(),new Card(),new Card()};
            Name = name;
            Cash = 10000;
            Playing = true;
            PlayerBet = 0;
        }
        public string name()
        {
            return Name;
        }
        public string cash()
        {
            string tmp = Convert.ToString(Cash);
            if (Cash == 0)
                return "Knockout";
            else
            return $"${tmp}";
        }
    }
}
        
