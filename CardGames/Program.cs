using System;
using System.Collections.Generic;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args) // Kommentar
        {
            Console.Title = "Multikortspel";
            List<string> mainMenu = new List<string> { "Spela Snabbpoker", "Välj spelarnamn", "Visa hichscorelista", "Spara & avsluta" };

            //init
            var menu = new Menu();
            menu.DrawMenuBox();
            menu.SetUpMenuList(mainMenu);

            //menu
            menu.MainMenu();

            Console.ReadKey();
        }
    }
}