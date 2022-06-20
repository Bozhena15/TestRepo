using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_C_sharp
{
    internal class Table
    {
        private int[] bb_s = { 30, 40, 50, 60, 80, 100, 120, 150, 200, 250, 300, 400, 500, 700, 800, 1000, 1200, 1400, 1600, 1800, 2000, 2500, 3000, 3500, 4000, 5000 };
        private int[] ante_s = { 2, 3, 4, 5, 6, 8, 10, 12, 16, 20, 25, 30, 40, 50, 60, 80, 100, 120, 160, 200, 240, 280, 320, 360, 400 };
        private Player[] Players = {new Player("Player"), new Player("Alex"), new Player("Lasse"),
                                    new Player("Steven"), new Player("Mattew"), new Player("Kris")};
        private int Pot;
        private int NewPot;
        private int BigBlind;
        private int SmallBlind;
        private int Ante;
        private int BoardRound;
        private Card[] BoardCard = { new Card(), new Card(), new Card(), new Card(), new Card() };
        private Deck fDeck = new Deck();
        private int DealerPlayer;
        private int MinBet = 0;
        private int queue = 0;
        private int[] ReadyPlayers = new int[6];
        private string[] PlayersBets = new string[6];
        private string Action;
        private string[] HistoryAction = new string[20];
        private int NextInQueue;
        private int RaisePlayer = 6;
        public Table()
        {
            Ante = ante_s[0];
            BigBlind = bb_s[0];
            SmallBlind = BigBlind / 2;
            BoardRound = 1;
            DealerPlayer = 3;
            NewPot = 0;
            Pot = 0;
            Action = String.Empty;
            NextInQueue = 0;
        }
        
        public void StartGame()
        {
            PreFlop();
            //Flop();
            //Turn();
            //River();
        }
        public void PreFlop()
        {
            for (int i = 0; i < ReadyPlayers.Length; i++)
            {
                ReadyPlayers[i] = 0;
            }
            FirstBets();
            DealBets();
        }
        public void Flop()
        {
            DealBets();
        }
        public void Turn()
        {
            DealBets();
        }
        public void River()
        {
            DealBets();
        }
        public void DealBets()
        {
            /*
             * int i = queue;
             * while(ReadyPlayer!=true){
             *      if(i==0){
             *          Bet()
             *      }
             *      else{
             *           BetB(i);
             *      }
             * }
             */
            HistoryAction = new string[20];
            int aCnt = 0;
            int CountReady = 0;
            bool AllReady = false;
            if (BoardRound != 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    PlayersBets[i] = " ";
                }
            }
            GiveCards();
            Thread.Sleep(1000);
            TableView();

            while (AllReady != true)
            {
                int i_first = 0;
                int i_last = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (ReadyPlayers[i] == 0)
                    {
                        i_first = i;
                        break;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (ReadyPlayers[i] == 0)
                    {
                        i_last = i;
                    }
                }
                i_last++;
                CountReady = 0;
                //         0              3
                for (int i = i_first; i < i_last; i++)
                {
                    // 0 0 1 0 0 0
                    // after next in queue
                    if (queue == 0)
                    {
                        Bet();
                    }
                    else
                    {
                        BetB(i);
                    }
                    HistoryAction[aCnt] = Action;
                    aCnt++;
                    queue++;

                    Console.Clear();
                    TableView();
                    for (int k = 0; k < HistoryAction.Length; k++)
                    {
                        Console.WriteLine(HistoryAction[k]);
                    }
                    Thread.Sleep(2000);
                }
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine(ReadyPlayers[i]);
                    if (ReadyPlayers[i] == 2)
                    {
                        CountReady++;
                    }
                    if(i == RaisePlayer)
                    {
                        CountReady++;
                        RaisePlayer = 6;
                    }
                }
                Console.WriteLine("---------------------------");
                if (CountReady == 6)
                {
                    AllReady = true;
                }
                // 0 3 1 2 2 2
            }
            queue = (NextInQueue + 1) % 6; 
            BoardRound++;
        }
        public void FirstBets()
        {
            for (int i = 0; i < 6; i++)
            {
                PlayersBets[i] = " ";
            }
            int Dealer = DealerPlayer;
            int sb = (Dealer + 1) % 6;
            int bb = (Dealer + 2) % 6;
            Players[sb].PlayerBet = SmallBlind;
            Players[bb].PlayerBet = BigBlind;
            Players[sb].Cash -= SmallBlind;
            Players[bb].Cash -= BigBlind;
            PlayersBets[sb] = "$" + Convert.ToString(Players[sb].PlayerBet);
            PlayersBets[bb] = "$" + Convert.ToString(Players[bb].PlayerBet);
            MinBet = BigBlind;
            if (BoardRound == 0)
            {
                queue = (Dealer + 3) % 6;

                for (int i = 0; i < 6; i++)
                {
                    Pot += Ante;
                    Players[i].Cash -= Ante;
                }
            }
        }
        public void ChangeDealer()
        {
            DealerPlayer++;
            int i = DealerPlayer;
            while (Players[i].Knock != true)
            {
                DealerPlayer++;
            }
            DealerPlayer = DealerPlayer % 6;
        }
        public void BetB(int pl)
        {
            if (queue == pl)
            {
                if (Players[pl].Cash != 0 && Players[pl].Playing == true)
                {
                    Random rnd = new Random();
                    int difb = 0;
                    int tmpcash;
                    int ch;
                    int Raise;
                    if (Players[pl].Cash < MinBet)
                    {
                        ch = rnd.Next(1, 100);
                        if (ch < 65)
                            ch = 2;
                        else
                            ch = 3;
                    }
                    else
                    {
                        ch = rnd.Next(1, 100);
                        if (ch < 15)
                            ch = 1;
                        else if (ch < 75)
                            ch = 2;
                        else
                            ch = 3;
                    }
                    switch (ch)
                    {
                        case 1:
                            Raise = rnd.Next(MinBet, Players[pl].Cash + 1);
                            difb = Raise - Players[pl].PlayerBet;
                            MinBet = Raise;
                            Players[pl].Cash -= difb;
                            NewPot += difb;
                            PlayersBets[pl] = $"${Raise}";
                            Players[pl].PlayerBet = Raise;
                            ReadyPlayers[pl] = 1;
                            for (int i = 0; i < 6; i++)
                            {
                                if (ReadyPlayers[i] != 2 && i != pl)
                                {
                                    ReadyPlayers[i] = 0;
                                }
                            }

                            Action = $"{Players[pl].name()} RAISE";
                            if (Raise == Players[pl].Cash && Raise > MinBet)
                            {
                                Action = "You are ALL IN";
                                ReadyPlayers[pl] = 2;
                                Players[pl].Playing = false;
                            }
                            break;
                        case 2:
                            if (MinBet > Players[pl].Cash)
                            {
                                Action = $"{Players[pl].name} ALL IN!";
                                tmpcash = Players[pl].Cash;
                                Players[pl].Cash = 0;
                                Players[pl].PlayerBet += tmpcash;
                                PlayersBets[pl] = "$" + Convert.ToString(Players[pl].PlayerBet);
                                ReadyPlayers[pl] = 2;
                                Players[pl].Playing = false;
                            }
                            else
                            {
                                difb = MinBet - Players[pl].PlayerBet;
                                Players[pl].Cash -= difb;
                                NewPot += difb;
                                Players[pl].PlayerBet += difb;
                                PlayersBets[pl] = "$" + Convert.ToString(Players[pl].PlayerBet);
                                ReadyPlayers[pl] = 1;
                                Action = $"{Players[pl].name()} CALL";
                            }
                            break;
                        case 3:
                            Players[pl].Playing = false;
                            Action = $"{Players[pl].name()} FOLD";
                            PlayersBets[pl] = "FOLD";
                            ReadyPlayers[pl] = 2;
                            break;
                    }
                }
                else
                {
                    PlayersBets[pl] = " ";
                }
            }
            else
            {
                PlayersBets[pl] = " ";
            }
            
        }
        public void Bet()
        {
            if (queue == 0)
            {
                if (Players[0].Cash != 0 && Players[0].Playing == true)
                {
                    int dif = 0;
                    int tmpcash;
                    int ch;
                    int Raise = 0;
                    Console.WriteLine("Your choice(1 - Raise, 2 - Call, 3 - Fold)");
                    ch = Convert.ToInt32(Console.ReadLine());
                    while (ch < 1 && ch > 3)
                    {
                        Console.WriteLine("Wrong choice, enter again! ");
                        ch = Convert.ToInt32(Console.ReadLine());
                    }
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Enter count to raise... ");
                            Raise = Convert.ToInt32(Console.ReadLine());
                            while (Raise < MinBet || Raise > Players[0].Cash)
                            {
                                if (Raise < MinBet)
                                {
                                    Console.WriteLine("Wrong \"Raise\", enter bigger number...");
                                    Raise = Convert.ToInt32(Console.ReadLine());
                                }
                                if (Raise > Players[0].Cash)
                                {
                                    Console.WriteLine("You don't have enough money. Enter another number...");
                                    Raise = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            dif = Raise - Players[0].PlayerBet;
                            MinBet = Raise;
                            Players[0].Cash -= dif;
                            NewPot += dif;
                            PlayersBets[0] = $"${Raise}";
                            Players[0].PlayerBet = Raise;
                            ReadyPlayers[0] = 1;
                            for (int i = 0; i < 6; i++)
                            {
                                if (ReadyPlayers[i] != 2 && i != 0)
                                {
                                    ReadyPlayers[i] = 0;
                                }
                            }
                            
                            Action = $"{Players[0].name()} RAISE";
                            if (Raise == Players[0].Cash && Raise > MinBet)
                            {
                                Action = "You are ALL IN";
                                ReadyPlayers[0] = 2;
                                Players[0].Playing = false;
                            }
                            break;
                        case 2:
                            // 100 200
                            // 150 200
                            if (MinBet > Players[0].Cash)
                            {
                                Action = $"{Players[0].name} ALL IN!";
                                tmpcash = Players[0].Cash;
                                Players[0].Cash = 0;
                                Players[0].PlayerBet += tmpcash;
                                PlayersBets[0] = "$" + Convert.ToString(Players[0].PlayerBet);
                                ReadyPlayers[0] = 2;
                                Players[0].Playing = false;
                            }
                            else
                            { // 0 150 call
                                // 100 200 call
                                dif = MinBet - Players[0].PlayerBet;
                                Players[0].Cash -= dif;
                                NewPot += dif;
                                Players[0].PlayerBet += dif;
                                PlayersBets[0] = "$" + Convert.ToString(Players[0].PlayerBet);
                                ReadyPlayers[0] = 1;
                                Action = $"{Players[0].name()} CALL";
                            }
                            break;
                        case 3:
                            Action = $"{Players[0].name()} FOLD";
                            Players[0].Playing = false;
                            PlayersBets[0] = "FOLD";
                            ReadyPlayers[0] = 2;
                            break;
                    }
                }
                else
                {
                    PlayersBets[0] = " ";
                }
            }
        }
        public string ReRank(int rank)
        {
            switch (rank)
            {
                case 11: return " J";
                case 12: return " Q";
                case 13: return " K";
                case 14: return " A";
                default: return "  ";
            }
        }
        public string ReSuit(int suit)
        {
            switch (suit)
            {
                case 1: return "_♥";
                case 2: return "_♦";
                case 3: return "_♣";
                case 4: return "_♠";
                default: return "  ";
            }
        }
        public string COI(int c, int tb)
        {
            if (tb == 1)
            {

                return $"{ReSuit(BoardCard[c].Suit)}";

            }
            else {
                if (BoardCard[c].Rank < 10)
                {
                    return $" {BoardCard[c].Rank}";
                }
                else if (BoardCard[c].Rank > 10)
                {
                    return $"{ReRank(BoardCard[c].Rank)}";
                }
                else
                    return $"{BoardCard[c].Rank}";
            }
        }
        public string COI_T(int pl, int c)
        {
            if(pl == 0)
            {
                if (Players[pl].cards[c].Rank < 10)
                {
                    return $" {Players[pl].cards[c].Rank}";
                }
                else if (Players[pl].cards[c].Rank > 10)
                {
                    return $"{ReRank(Players[pl].cards[c].Rank)}";
                }
                else
                    return $"{Players[pl].cards[c].Rank}";
            }
            if (Players[pl].Playing)
            {

                if (BoardRound == 1)
                {
                    if (Players[pl].cards[c].Rank < 10)
                    {
                        return $" {Players[pl].cards[c].Rank}";
                    }
                    else if (Players[pl].cards[c].Rank > 10)
                    {
                        return $"{ReRank(Players[pl].cards[c].Rank)}";
                    }
                    else
                        return $"{Players[pl].cards[c].Rank}";
                }
                else
                {
                    return " §";
                }
            }
            else
                return " N";
        }
        public string COI_B(int pl, int c)
        {
            if(pl == 0)
            {
                return $"{ReSuit(Players[pl].cards[c].Suit)}";
            }
            if (Players[pl].Playing)
            {
                if (BoardRound == 1)
                {
                    return $"{ReSuit(Players[pl].cards[c].Suit)}";
                }
                else
                {
                    return "_§";
                }
            }
            else
                return "_N";
        }
        public string Dealer(int pl)
        {
            if (pl == DealerPlayer)
            {
                return "D";
            }
            else
            {
                return " ";
            }
        }
        public string Space(string tmp)
        {
            if (tmp.Length == 8)
                return $"{tmp}";
            else if (tmp.Length == 7)
                return $"{tmp} ";
            else if (tmp.Length == 6)
                return $"{tmp}  ";
            else if (tmp.Length == 5)
                return $"{tmp}   ";
            else if (tmp.Length == 4)
                return $"{tmp}    ";
            else if (tmp.Length == 3)
                return $"{tmp}     ";
            else if (tmp.Length == 2)
                return $"{tmp}      ";
            else
                return $"{tmp}       ";

        }
        public string Space(int num)
        {
            string tmp = Convert.ToString(num);
            if (tmp.Length == 8)
                return $"{tmp}";
            else if (tmp.Length == 7)
                return $"{tmp} ";
            else if (tmp.Length == 6)
                return $"{tmp}  ";
            else if (tmp.Length == 5)
                return $"{tmp}   ";
            else if (tmp.Length == 4)
                return $"{tmp}    ";
            else if (tmp.Length == 3)
                return $"{tmp}     ";
            else if (tmp.Length == 2)
                return $"{tmp}      ";
            else
                return $"{tmp}       ";

        }
        //public void show1()
        //{
        //    for (int i = 0; i < 52; i++)
        //    {
        //        Console.WriteLine("Suit = " + Cards.DeckCards[i].Suit + " Rank = " + Cards.DeckCards[i].Rank);
        //    }
        //}
        //public string SpaceBoard()
        //{
        //    if(Board>0)
        //    {
        //        return "";
        //    }
        //    return "";
        //}
        public void GiveCards()
        {
            fDeck.Shuffle();
            int count = 0;
            for (int i = 0; i < Players.Length; i++)
            {
                Players[i].cards[0] = fDeck.GiveCard(count);
                count++;
                Players[i].cards[1] = fDeck.GiveCard(count);
                count++;
            }
            for (int i = 0; i < BoardCard.Length; i++)
            {
                BoardCard[i] = fDeck.GiveCard(count);
                count++;
            }
        }
        public void TableView()
        {
            Console.WriteLine(
                $"   Ante       Big/Small blind\n" +
                $"   {Space(Ante)}        {BigBlind} / {SmallBlind}\n\n" +
                $"                                         {Players[3].name()}                                                   {Players[4].name()}\n" +
                $"                                         {Space(Players[3].cash())}                                                 {Players[4].cash()} \n" +
                $"                              __________________________________________________________________________________________       \n" +
                $"                             /                                                                                          \\ \n" +
                $"                            /        ___    ___                                                        ___    ___        \\ \n" +
                $"                           /        |{COI_T(3, 0)} |  |{COI_T(3, 1)} |                                                      |{COI_T(4, 0)} |  |{COI_T(4, 1)} |        \\ \n" +
                $"                          /         |   |  |   |                                                      |   |  |   |         \\ \n" +
                $"                         /          |{COI_B(3,0)}_|  |{COI_B(3, 1)}_|                                                      |{COI_B(4, 0)}_|  |{COI_B(4, 1)}_|          \\ \n" +
                $"                        /                                                                                                    \\ \n" +
                $"                       /                    {Space($"{PlayersBets[3]}")}                                              {Space($"{PlayersBets[4]}")}                    \\ \n" +
                $"                      /                            {Dealer(3)}                                             {Dealer(4)}                             \\ \n" +
                $"                     /                                                                                                          \\ \n" +
                $"                    |                                                                                                           | \n" +
                $"                    |                                     ___    ___    ___      ___    ___                                     | \n" +
                $"                    |         {Space($"{PlayersBets[2]}")}                   |{COI(0,0)} |  |{COI(1, 0)} |  |{COI(2, 0)} |    |{COI(3, 0)} |  |{COI(4, 0)} |                                    | \n" +
                $"                    |       ___    ___                   |   |  |   |  |   |    |   |  |   |                   ___    ___       | \n" +
                $"      {Players[2].name()}         |      |{COI_T(2, 0)} |  |{COI_T(2, 1)} |                  |{COI(0, 1)}_|  |{COI(1, 1)}_|  |{COI(2, 1)}_|    |{COI(3, 1)}_|  |{COI(4, 1)}_|                  |{COI_T(5, 0)} |  |{COI_T(5, 1)} |      |        {Players[5].name()}\n" +
                $"      {Space(Players[2].cash())}      |      |   |  |   |     {Dealer(2)}                                                          {Dealer(5)}      |   |  |   |      |        {Players[5].cash()}\n" +
                $"                    |      |{COI_B(2, 0)}_|  |{COI_B(2, 1)}_|                             Pot: ${Space(Pot)}                            |{COI_B(5, 0)}_|  |{COI_B(5, 1)}_|      | \n" +
                $"                    |                                                                                                           | \n" +
                $"                    |                                                                                            {Space($"{PlayersBets[5]}")}       | \n" +
                $"                    |                                                                                                           | \n" +
                $"                    \\                                                                                                          / \n" +
                $"                     \\                                                                                                        / \n" +
                $"                      \\                           {Dealer(1)}                                             {Dealer(0)}                            / \n" +
                $"                       \\                                                                                                    / \n" +
                $"                        \\            ___    ___                                                       ___    ___           / \n" +
                $"                         \\          |{COI_T(1, 0)} |  |{COI_T(1, 1)} |                                                     |{COI_T(0, 0)} |  |{COI_T(0, 1)} |         / \n" +
                $"                          \\         |   |  |   |        {Space($"{PlayersBets[1]}")}                          {Space($"{PlayersBets[0]}")}   |---|  |---|        / \n" +
                $"                           \\        |{COI_B(1, 0)}_|  |{COI_B(1, 1)}_|                                                     |{COI_B(0, 0)}_|  |{COI_B(0, 1)}_|       / \n" +
                $"                            \\                                                                                          / \n" +
                $"                             ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬ \n" +
                $"                                         {Players[1].name()}                                                   {Players[0].name()} \n" +
                $"                                         {Space(Players[1].cash())}                                               {Players[0].cash()} \n"
                );
                 ;
            
        }
    }
}
