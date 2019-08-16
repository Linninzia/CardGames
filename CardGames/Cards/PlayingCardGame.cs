using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CardGames
{
    class PlayingCardGame : PlayingCardDeck
    {
        private PlayingCard[] playerHand;
        private PlayingCard[] computerHand;
        private PlayingCard[] sortedPlayerHand;
        private PlayingCard[] sortedComputerHand;

        public PlayingCardGame()
        {
            playerHand = new PlayingCard[5];
            sortedPlayerHand = new PlayingCard[5];
            computerHand = new PlayingCard[5];
            sortedComputerHand = new PlayingCard[5];
        }

        public void Deal()
        {
            SetUpDeck(); //create the deck of cards and shuffle them
            GetHand();
            SortCards();
            DisplayCards();
            EvaluateHands();
        }

        public void GetHand()
        {
            //5 cards for player
            for (int i = 0; i < 5; i++)
            playerHand[i] = GetDeck[i];

            //5 cards for computer
            for (int i = 5; i < 10; i++)
                computerHand[i - 5] = GetDeck[i];
        }

        public void SortCards()
        {
            var queryPlayer = from hand in playerHand
                              orderby hand.MyValue
                              select hand;

            var queryComputer = from hand in computerHand
                              orderby hand.MyValue
                              select hand;

            var index = 0;
            foreach (var element in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = element;
                index++;
            }

            index = 0;
            foreach (var element in queryComputer.ToList())
            {
                sortedComputerHand[index] = element;
                index++;
            }

        }
        public void DisplayCards()
        {

            int x = 0; //x position of cursor. we move it left and right
            int y = 1; //y position of cursor . we move it up and down
 
            for (int i = 0; i < 5; i++)
            {
                DrawCards.DrawCardOutline(sortedPlayerHand[i], x, y);
                DrawCards.DrawCardsSuitValue(sortedPlayerHand[i], x, y);
                x++;
            }

            x = 0; // reset x position
            y = 12; // move the row of the computer cards below the players cards

            for (int i = 5; i < 10; i++)
            {
                DrawCards.DrawCardOutline(sortedPlayerHand[i-5], x, y);
                DrawCards.DrawCardsSuitValue(sortedComputerHand[i - 5], x, y);
                x++;// move to the right
            }
        }
        public void EvaluateHands()
        {
            //create players computers evaluation objects(passing sorted hand to constructor)
            PokerHandEvaluator playerHandEvaluator = new PokerHandEvaluator(sortedPlayerHand);
            PokerHandEvaluator computerHandEvaluator = new PokerHandEvaluator(sortedComputerHand);

            //get the player:s and computer:s hand
            Hand playerHand = playerHandEvaluator.EvaluateHand();
            Hand computerHand = computerHandEvaluator.EvaluateHand();
            string result;

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;

            //evaluate hands
            if (playerHand > computerHand)
            {
                result = Players.PlayerName + " vann!";
                Players.PlayerPoints += 1;
            }
            else if (playerHand < computerHand)
            {
                result = "Dator vann!";
                Players.PlayerPoints -= 1;
            }
            else //if the hands are the same, evaluate the values
            {
                //first evaluate who has the higher value of poker hand
                if (playerHandEvaluator.HandValues.Total > computerHandEvaluator.HandValues.Total)
                {
                    result = Players.PlayerName + " vann!";
                    Players.PlayerPoints += 1;
                }  
                else if (playerHandEvaluator.HandValues.Total < computerHandEvaluator.HandValues.Total)
                {
                    result = "Dator vann!";
                    Players.PlayerPoints -= 1;
                }
                    
                //if both hands have the same poker hand
                //then the player with the next highest card wins
                else if (playerHandEvaluator.HandValues.HighCard > computerHandEvaluator.HandValues.HighCard)
                {
                    result = Players.PlayerName + " vann!";
                    Players.PlayerPoints += 1;
                }
                else if (playerHandEvaluator.HandValues.HighCard < computerHandEvaluator.HandValues.HighCard)
                {
                    result = "Dator vann!";
                    Players.PlayerPoints -= 1;
                }     
                else
                {
                    result = "Oavgjort!";
                }
                   
            }

            int xCoor = 0;
            int yCoor = 0;

            Global.ClearCurrentConsoleLine(yCoor + 14, xCoor + 69);
            Console.SetCursorPosition(xCoor + 69, yCoor + 14);
            Console.WriteLine("{0}", result);

            //display each hand
            Global.ClearCurrentConsoleLine(yCoor + 4, xCoor + 47);
            Console.SetCursorPosition(xCoor + 47, yCoor + 4);
            Console.WriteLine("{0} hand: {1}", Players.PlayerName, playerHand);

            Global.ClearCurrentConsoleLine(yCoor + 25, xCoor + 47);
            Console.SetCursorPosition(xCoor + 47, yCoor + 25);
            Console.WriteLine("Datorns Hand: {0}\n", computerHand);

            Players.DrawPlayer();
        }

    }
}
