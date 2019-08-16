using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    class PlayingCard
    {
        public enum SUIT
        {
            //stora bokstäver för den egna typen SUIT enumvärdena
            HEARTS,
            SPADES,
            DIAMONDS,
            CLUBS
        }

        public enum VALUE
        {
            
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
            EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE

        }

        public enum SIDEUP
        {
            OPEN,
            CLOSE     
        }

        //properties
        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }
        public SIDEUP MySideup { get; set; }
    }
}
