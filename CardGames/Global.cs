using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    static class Global
    {
        public static void ClearCurrentConsoleLine(int y, int x = 0)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', Console.WindowHeight));
            Console.SetCursorPosition(x, currentLineCursor);
        }
    }
}
