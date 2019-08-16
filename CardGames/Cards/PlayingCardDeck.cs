using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
     class PlayingCardDeck : PlayingCard
    {
        const int NUM_OF_CARDS = 52;
        private PlayingCard[] deck; //array med alla spelkort
 
        //constructor
        public PlayingCardDeck()
        {
            deck = new PlayingCard[NUM_OF_CARDS];
        }

        public PlayingCard[] GetDeck { get { return deck; } } //get current deck

        //create deck of 52 cards : 13 values each , with 4 suits
        public void SetUpDeck()
        {
            int i = 0;
            foreach (SUIT  s in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new PlayingCard { MySuit = s, MyValue = v};
                    i++;
                }
            }
            ShuffleCards();
        }
        //blandaaar kortleken
        public void ShuffleCards()
        {
            Random rand = new Random();
            PlayingCard temp;

            // blanda 1000ggr?
            for (int shuffleTimes = 0; shuffleTimes < 1000; shuffleTimes++)
            {
                for (int i = 0; i < NUM_OF_CARDS; i++)
                {
                    //swap the cards
                    int secondCardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }

        
    }
}
