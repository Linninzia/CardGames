using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    class DrawMenu
    {
        public void DrawMenuBox()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 4);

            string[] imageArray = {"\x2260", "\x2665", "\x2666", "\x2663"};

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.OutputEncoding = Encoding.Unicode;

            int x = 0;
            int y = 0;
            int boxWidth = Console.WindowWidth / 4;
            int boxHeight = Console.WindowHeight;
            const string cw = " ";

            //loopar för varje kort som ska ritas upp
            for (int i = 0; i < boxHeight; i++)
            {
                string width = string.Empty;
                string image = string.Empty;

                //boxens placering
                Console.SetCursorPosition(x, y + i);
                Console.BackgroundColor = ConsoleColor.Black;

                //loopar kortens bredd, varje gång den loopar lägger den till ett mellanrum
                for (int bx = 0; bx < boxWidth; bx++)
                {
                    width += cw;
                    image = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(imageArray[randomNumber]));
                }

                //ritar upp bredd
                Console.Write(" {0} {1} ", width, image);

            }

        }        

    }
}
