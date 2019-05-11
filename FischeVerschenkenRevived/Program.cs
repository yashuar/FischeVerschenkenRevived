using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FischeVerschenkenRevived
{
    class Program
    {
        Game gameInstance = new Game();

        private static bool isMenuFinished;
        public static ConsoleKey CurrentKey = ConsoleKey.NoName;

        // Menü-Index
        public static int myIndex;

        // Menütyp-Indikator
        public static bool MainMenu = true;

        public static int BoardWidth;
        public static int BoardHeight;
        internal static bool isFirstGameStart;

        static void Main(string[] args)
        {
            myIndex = 4;
            StartApp();
        }

        private static void StartApp()
        {
            bool firstMenuDraw = true;
            string[] myMenu  = Helpers.MainMenu();
            string[] myMenuSelected = Helpers.MainMenuSelected();
            do
            {
                if (!firstMenuDraw)
                {
                    CurrentKey = Console.ReadKey().Key;
                }
                else
                {
                    Console.CursorVisible = false;
                    firstMenuDraw = false;
                }
                DrawMenu(myMenu, myMenuSelected, myIndex, 4, 5);
            } while (!isMenuFinished);

        }

        private static void DrawMenu(string[] Menu, string[] MenuSelected, int MenuIndex, int firstMenuOptionIndex, int MenuOptionCount)
        {
            switch (CurrentKey)
            {
                case ConsoleKey.DownArrow:
                    if (myIndex < (firstMenuOptionIndex + MenuOptionCount) - 1)
                    {
                        myIndex++;
                    }
                    else if (myIndex == (firstMenuOptionIndex + MenuOptionCount) - 1)
                    {
                        myIndex = firstMenuOptionIndex;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (myIndex > firstMenuOptionIndex)
                    {
                        myIndex--;
                    }
                    else if (myIndex == firstMenuOptionIndex)
                    {
                        myIndex = (firstMenuOptionIndex + MenuOptionCount) - 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (myIndex >= firstMenuOptionIndex && myIndex <= firstMenuOptionIndex + MenuOptionCount)
                    {
                        RunMenuOption(myIndex - firstMenuOptionIndex);
                    }
                    
                    break;
                default:
                    break;
                    
            }
            Console.Clear();
            for (int i = 0; i < Menu.Length; i++)
            {
                if (myIndex == i)
                {
                    Console.WriteLine(MenuSelected[i]);
                    if (isMenuFinished == false && i == 5)
                    {
                        string Line;
                        switch (BoardHeight.ToString().Length)
                        {
                            case 2:
                                Line = "|  | " + BoardHeight + "                    |  |";
                                Console.WriteLine(Line);
                                break;
                            case 3:
                                Line = "|  | " + BoardHeight + "                   |  |";
                                Console.WriteLine(Line);
                                break;
                            default:
                                break;
                        }
                        
                    }
                    if (isMenuFinished == false && i == 6)
                    {
                        string Line;
                        switch (BoardWidth.ToString().Length)
                        {
                            case 2:
                                Line = "|  | " + BoardWidth + "                    |  |";
                                Console.WriteLine(Line);
                                break;
                            case 3:
                                Line = "|  | " + BoardWidth + "                   |  |";
                                Console.WriteLine(Line);
                                break;
                            default:
                                break;
                        }

                    }
                }
                else
                {
                    Console.WriteLine(Menu[i]);
                }
                
            }
            
        }

        private static void RunMenuOption(int MenuIndex)
        {
            if (MainMenu)
            {
                switch (MenuIndex)
                {
                    case 0:
                        StartPreparedGame("Quickplay");
                        break;
                    case 1:
                        SetFieldHeight();
                        break;
                    case 2:
                        SetFieldWidth();
                        break;
                    case 3:
                        StartPreparedGame("Play");
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void StartPreparedGame(string GameType)
        {
            Game instanceOfGame = new Game();

            if ((BoardHeight > 0 && BoardWidth > 0) || GameType == "Quickplay")
            {
                isMenuFinished = true;
                instanceOfGame.RunGame(GameType);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bitte stellen Sie zuerst");
                Console.WriteLine("die Größe des Spielfelds");
                Console.WriteLine("ein oder wählen Sie");
                Console.WriteLine("Schnelles Spiel.");
                Console.ReadLine();
                myIndex = 4;
            }
        }

        private static void SetFieldWidth()
        {
            BoardWidth = Helpers.StartInput("Width");
        }

        private static void SetFieldHeight()
        {
            BoardHeight = Helpers.StartInput("Height");
        }
    }
}
