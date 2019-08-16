using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DBDomain;
using Microsoft.EntityFrameworkCore;

namespace CardGames
{
    static class Players
    {
        public static string PlayerName = "Spelare 1";
        public static int PlayerPoints;

        public static void DrawPlayer()
        {
            int x = 7;
            int y = 2;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Global.ClearCurrentConsoleLine(y);
            Console.SetCursorPosition(x, y);
            Console.WriteLine("{0}", PlayerName);

            Global.ClearCurrentConsoleLine(y + 1);
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("{0} poäng", PlayerPoints);
        }

        public static void SetPlayerName()
        {
            int x = 4;
            int y = 2;

            Global.ClearCurrentConsoleLine(y);
            Console.SetCursorPosition(x, y);
            Console.Write("Skriv in namn för spelare");

            Global.ClearCurrentConsoleLine(y + 1);
            Console.SetCursorPosition(x, y + 1);
            Console.Write("Namn: ");

            Console.CursorVisible = true;
            PlayerName = Console.ReadLine();
            Console.CursorVisible = false;

            if (PlayerName == string.Empty)
            {
                PlayerName = "Spelare 1";
            }

            PlayerPoints = 0;

            DrawPlayer();
        }

        public static void SavePlayerNameAndHighscore()
        {
            using (var context = new DB_context())
            {
                DB_player player = new DB_player();
                player.Name = PlayerName;
                context.DPlayer.Add(player);
                context.SaveChanges();

                DB_highScore highscore = new DB_highScore();
                highscore.Points = PlayerPoints;
                highscore.Player = context.DPlayer.Where(h => h.Id == player.Id).First();

                context.DHighScore.Add(highscore);
                context.SaveChanges();
            }
        }

        public static void GetHighScore()
        {
            using (var context = new DB_context())
            {
                var show = context.DHighScore
                    .Include(a => a.Player)
                    .OrderByDescending(u => u.Points)
                    .Take(5).ToList();

                Console.SetCursorPosition(12, 2);
                Console.Write("Highscore");

                int x = 4;
                int y = 3;
                int i = 0;

                foreach (var item in show)
                {
                    Console.SetCursorPosition(x, y + i);
                    Console.Write("{0} [ {1} poäng ]", item.Player.Name, item.Points);
                    i++;
                }
       
            }
        }
    }
}