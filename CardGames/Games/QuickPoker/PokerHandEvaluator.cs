using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    public enum Hand
    {
        Nothing,
        OnePair,
        TwoPairs,
        ThreeKind,
        Straight,
        Flush,
        FullHouse,
        FourKind
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    class PokerHandEvaluator : PlayingCard
    {
        private int heartsSum;
        private int diamondsSum;
        private int clubsSum;
        private int spadesSum;
        private PlayingCard[] cards;
        private HandValue handValue;

        public PokerHandEvaluator(PlayingCard[] sortedHand)
        {
            heartsSum = 0;
            diamondsSum = 0;
            clubsSum = 0;
            spadesSum = 0;
            cards = new PlayingCard[5];
            Cards = sortedHand;
            handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return handValue;  }
            set { handValue = value; }
        }

        public PlayingCard[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }

        }

        public Hand EvaluateHand()
        {
            //get the number of each suit in hand
            GetNumberOfSuit();
            if (FourOfKind())
                return Hand.FourKind;
            else if (FullHouse())
                return Hand.FullHouse;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (ThreeKind())
                return Hand.ThreeKind;
            else if (TwoPairs())
                return Hand.TwoPairs;
            else if (OnePair())
                return Hand.OnePair;

            //if the hand is nothing, then the player with the highest card wins
            handValue.HighCard = (int)cards[4].MyValue;
            return Hand.Nothing;
            
        }

        private void GetNumberOfSuit()
        {
            foreach (var element in Cards)
            {
                if (element.MySuit == PlayingCard.SUIT.HEARTS)
                    heartsSum++;
                else if (element.MySuit == PlayingCard.SUIT.DIAMONDS)
                    diamondsSum++;
                else if (element.MySuit == PlayingCard.SUIT.CLUBS)
                    clubsSum++;
                else if (element.MySuit == PlayingCard.SUIT.SPADES)
                    spadesSum++;

            }
        }

        private bool FourOfKind()
        {
            //if the first 4 cards, add values of the four cards and last card is the highest
            if (cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[0].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;


            }
            else if(cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue && cards[1].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                handValue.HighCard = (int)cards[0].MyValue;
                return true;

            }

            return false;
        }

        private bool FullHouse()
        {
            //the first three cards and the last two cards are of the same value
            //first two cards, and the last three cards are of the same value
            if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue) ||
               (cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue))
            {
                handValue.Total = (int)(cards[0].MyValue) + (int)(cards[1].MyValue) + (int)(cards[2].MyValue) +
                    (int)(cards[3].MyValue) + (int)(cards[4].MyValue);
                    return true;
            }

            return false;


        }

        private bool Flush()
        {
            //if all suits are the same
            if(heartsSum == 5 || diamondsSum == 5 || clubsSum == 5 || spadesSum == 5)
            {
                //if flush the player with higher cards win
                //whoevver has the last card the highest, has automatically all the cards total higher
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }

            return false;
        }

        private bool Straight()
        {
            //if 5 consecutive values
            if (cards[0].MyValue + 1 == cards[1].MyValue &&
                cards[1].MyValue + 1 == cards[2].MyValue &&
                cards[2].MyValue + 1 == cards[3].MyValue &&
                cards[3].MyValue + 1 == cards[4].MyValue)
            {
                //player with the highest value of the last card win
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }

            return false;

            
        }

        private bool ThreeKind()
        {
            //if the 1,2,3 cards are the same  OR
            // 2,3,4 cards are the same OR
            //3,4,5 same OR
            //3rdst card will always be a part of THREE KIND
            if((cards[0].MyValue == cards[1].MyValue) && cards[0].MyValue == cards[3].MyValue ||
               (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue))
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if(cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                handValue.Total = (int)cards[1].MyValue;
                return true;
            }
            return false;


        }
        private bool TwoPairs()
        {
            //if 1,2 and 3,4
            //if 1,2 and 4,5
            //if 2,3 and 4,5
            // with two pairs the 2nd card will alway be a part of one pair
            //and 4th card will alway be a part of second pair
            if (cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[0].MyValue == cards[1].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[0].MyValue;
                return true;
            }
            return false;
        }

        private bool OnePair()
        {
            //if 1,2 -> 5th card has the highest value
            //2,3
            //3,4
            //4,5 -> card nr 3 has the highest value
            if (cards[0].MyValue == cards[1].MyValue)
            {
                handValue.Total = (int)cards[0].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[2].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[3].MyValue * 2;
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }

            return false;
        }


    }
}
