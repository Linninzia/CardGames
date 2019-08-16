using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    class DrawCards : PlayingCard
    {

        public static void DrawCardOutline(PlayingCard card, int xcoor, int ycoor)
        {

            int x = xcoor * 12 + 47;
            int y = ycoor + 5;
            int cardWidth = 12;
            int cardHeight = 7;
            const string cw = " ";

            //loopar för varje kort som ska ritas upp
            for (int i = 0; i < cardHeight; i++)
            {
                string width = string.Empty;

                //kortens placering
                Console.SetCursorPosition(x, y + i);

                Console.BackgroundColor = ConsoleColor.White;

                //loopar kortens bredd, varje gång den loopar lägger den till ett mellanrum
                for (int cx = 1; cx < cardWidth; cx++)
                {
                    width += cw;
                }

                //ritar upp kortens bredd
                Console.Write(width);
            }
            
        }        

        public static void DrawCardsSuitValue(PlayingCard card, int xcoor, int ycoor)
        {
            Console.OutputEncoding = Encoding.Unicode;

            //displays suit and value of the card inside its outline
            string cardSuit = " ";
            int x = xcoor * 12 + 45;
            int y = ycoor + 2;

            //lista med x och y positioner för innehållet i kortet
            List<int> cx = new List<int>();
            List<int> cy = new List<int>();

            int cv; //kort value
            int drawCount; //antalet symboler som ska ritas upp, räknar in kortets value också

            // encode each byte array from the CodePage437 into a character
            // hearts and diamonds are red , clubs and spades are black
            switch (card.MySuit)
            {
                case PlayingCard.SUIT.HEARTS:
                    cardSuit = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes("\x2665"));
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case PlayingCard.SUIT.DIAMONDS:
                    cardSuit = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes("\x2666"));
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case PlayingCard.SUIT.CLUBS:
                    cardSuit = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes("\x2663"));
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case PlayingCard.SUIT.SPADES:
                    cardSuit = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes("\x2660"));
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            switch (card.MyValue)
            {
                case PlayingCard.VALUE.TWO:
                    cv = 2; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 7, 7, 11 });
                    cy.AddRange(new int[] { 3, 5, 7, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.THREE:
                    cv = 3; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 7, 7, 7, 11 });
                    cy.AddRange(new int[] { 3, 5, 6, 7, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.FOUR:
                    cv = 4; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 8, 8, 11 });
                    cy.AddRange(new int[] { 3, 5, 7, 5, 7, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.FIVE:
                    cv = 5; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 7, 9, 9, 11 });
                    cy.AddRange(new int[] { 3, 5, 7, 6, 5, 7, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.SIX:
                    cv = 6; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 5, 9, 9, 9, 11 });
                    cy.AddRange(new int[] { 3, 5, 6, 7, 5, 6, 7, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.SEVEN:
                    cv = 7; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 5, 7, 9, 9, 9, 11 });
                    cy.AddRange(new int[] { 3, 5, 6, 7, 6, 5, 6, 7, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.EIGHT:
                    cv = 8; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 5, 7, 9, 9, 9, 7, 11 });
                    cy.AddRange(new int[] { 3, 5, 6, 7, 4, 5, 6, 7, 8, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.NINE:
                    cv = 9; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 5, 7, 7, 9, 9, 9, 7, 11 });
                    cy.AddRange(new int[] { 3, 5, 6, 7, 4, 6, 5, 6, 7, 8, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.TEN:
                    cv = 10; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 5, 7, 7, 7, 9, 9, 9, 7, 11 });
                    cy.AddRange(new int[] { 3, 5, 6, 7, 4, 5, 7, 5, 6, 7, 8, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.JACK:
                    cv = 10; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 5, 7, 7, 7, 9, 9, 9, 7, 11 });
                    cy.AddRange(new int[] { 3, 5, 6, 7, 4, 5, 7, 5, 6, 7, 8, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.QUEEN:
                    cv = 10; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 5, 7, 7, 7, 9, 9, 9, 7, 11 });
                    cy.AddRange(new int[] { 3, 5, 6, 7, 4, 5, 7, 5, 6, 7, 8, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.KING:
                    cv = 10; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 5, 5, 5, 7, 7, 7, 9, 9, 9, 7, 11 });
                    cy.AddRange(new int[] { 3, 5, 6, 7, 4, 5, 7, 5, 6, 7, 8, 9 });

                    CardLoop();
                    break;
                case PlayingCard.VALUE.ACE:
                    cv = 1; //kort value
                    drawCount = cv + 2; //antalet symboler som ska ritas upp, räknar in kortets value också

                    //lägger till i cx och cy
                    cx.AddRange(new int[] { 3, 7, 11 });
                    cy.AddRange(new int[] { 3, 6, 9 });

                    CardLoop();
                    break;
            }

            //ritar upp innehåll på korten
            void CardLoop()
            {
                for (int i = 0; i < drawCount; i++)
                {
                    Console.SetCursorPosition(x + cx[i], y + cy[i]);

                    if (i == 0 || i == drawCount - 1)
                    {
                        switch (card.MyValue)
                        {
                            case PlayingCard.VALUE.JACK:
                                Console.Write('J');
                                break;
                            case PlayingCard.VALUE.QUEEN:
                                Console.Write('Q');
                                break;
                            case PlayingCard.VALUE.KING:
                                Console.Write('K');
                                break;
                            case PlayingCard.VALUE.ACE:
                                Console.Write('A');
                                break;
                            default:
                                Console.Write(cv);
                                break;
                        }
                    }
                    else
                    {
                        Console.Write(cardSuit);
                    }

                }
            }

        }

    }
}
