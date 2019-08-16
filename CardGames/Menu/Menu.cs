using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    class Menu : MenuList
    {
        private MenuList[] list;

        //resetar bara raden

        public void SetUpMenuList(List<string> arrList)
        {
            list = new MenuList[arrList.Count];
            int i = 0;
            
            foreach (var l in arrList)
            {
                list[i] = new MenuList { MyMenuTitle = l, MyIndex = i};
                i++;
            }
        }

        public void MainMenu()
        {            
            bool InMenu = true;
            string leftArrow = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes("\x25BA"));
            string rightArrow = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes("\x25C4"));

            //gömmer pekare
            Console.CursorVisible = false;

            int x = 5;
            int y = 13;

            while (InMenu)
            {

                //det menynamn som markeras får ändrad färg och symboler, annars är det normalt
                for (int i = 0; i < list.Length; i++)
                {
                    Console.SetCursorPosition(x, y + i);

                    if (i == MyIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.Write("{0} {1} {2}", leftArrow, list[i].MyMenuTitle, rightArrow);
                    }
                    else
                    {
                        Console.Write("  {0}  ", list[i].MyMenuTitle);
                    }

                    Console.ResetColor();
                }

                ConsoleKeyInfo button = Console.ReadKey();

                switch (button.Key)
                {
                    case ConsoleKey.DownArrow:

                        if (MyIndex == list.Length - 1) { MyIndex = 0; }
                        else { MyIndex++; }

                        break;
                    case ConsoleKey.UpArrow:

                        if (MyIndex <= 0) { MyIndex = list.Length - 1; }
                        else { MyIndex--; }
                        
                        break;
                    case ConsoleKey.Enter:
                        
                        switch (MyIndex)
                        {
                            case 0:
                                QuickPoker();
                                break;
                            case 1:
                                Players.SetPlayerName();
                                break;
                            case 2:
                                Players.GetHighScore();
                                break;
                            case 3:
                                Players.SavePlayerNameAndHighscore();
                                Exit();
                                break;
                        }
                        
                        break;
                }
 
            }

        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void QuickPoker()
        {
            Console.Title = "Multikortspel - Snabbpoker";

            PlayingCardGame pcg = new PlayingCardGame();
            pcg.Deal();
 
            //PokerMenu();
        }
    
       /* public void PokerMenu()
        {
            Console.SetCursorPosition(0, 0);

            //gömmer muspekaren
            Console.CursorVisible = false;

            while (InMenu)
            {
                for (int i = 0; i < QuickpokerMenu.Count; i++)
                {
                    if (i == menuList.IndexItem)
                    {

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.OutputEncoding = Encoding.Unicode;

                        Console.Write(" {0} {1} {2} ", leftArrow, QuickpokerMenu[i], rightArrow);

                    }
                    else
                    {
                        Console.Write("  {0} ", QuickpokerMenu[i]);
                    }

                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;

                }

                ConsoleKeyInfo button = Console.ReadKey();

                switch (button.Key)
                {
                    case ConsoleKey.RightArrow:
                        Console.Beep(264, 125);
                        if (menuList.IndexItem == QuickpokerMenu.Count - 1)
                        { menuList.IndexItem = 0; }
                        else
                        { menuList.IndexItem++; }

                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Beep(264, 125);
                        if (menuList.IndexItem <= 0)
                        { menuList.IndexItem = QuickpokerMenu.Count - 1; }
                        else
                        { menuList.IndexItem--; }

                        break;
                    case ConsoleKey.Enter:
                        Console.Beep(364, 125);
                        switch (menuList.IndexItem)
                        {
                            case 0:
                                QuickPoker();
                                break;
                            case 1:
                                SaveOnePlayerAlias();
                                menuList.IndexItem = 0;
                                Console.ResetColor();
                                Console.Clear();
                                MainMenu();
                                break;
                            case 2:
                                Exit();
                                break;
                        }

                        break;
                }

                ClearCurrentConsoleLine();
            }
        }*/

    }
}
