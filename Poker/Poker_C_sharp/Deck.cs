using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_C_sharp
{
    internal class Deck
    {
        public Card[] DeckCards = new Card[0];
        private int[,] allcards = new int[52, 2];
        public Deck()
        {
            CreateDeck();
            Shuffle();
        }
        public void CreateDeck()
        {
            int k = 0;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 2; j <= 14; j++)
                {
                    allcards[k, 0] = i;
                    allcards[k, 1] = j;
                    k++;
                }
            }
        }
        public Card GiveCard(int c)
        {
            return DeckCards[c];
        }
        public void Shuffle() {
            Console.WriteLine("Shuffling cards....");
            DeckCards = new Card[52];
            for (int i = 0; i < 52; i++)
            {
                DeckCards[i] = new Card();
            }
            Random r = new Random();
            int rnd = r.Next(52);
            bool tmp = false;
            for (int i = 0; i < 52; i++)
            {
                while (true)
                {
                    if (DeckCards[rnd].Rank == 0)
                    {
                        tmp = true;
                        DeckCards[rnd].Suit = allcards[i, 0];
                        DeckCards[rnd].Rank = allcards[i, 1];
                    }
                    if (tmp)
                    {
                        tmp = false;
                        rnd = r.Next(52);
                        break;
                    }
                    rnd = r.Next(52);
                }
            }
        }
        public void show()
        {
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine("Suit = " + DeckCards[i].Suit + " Rank = " + DeckCards[i].Rank);
            }
        }
    }
}
