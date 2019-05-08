using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FischeVerschenkenRevived
{
    class Program
    {
        GameCell[] gameCellsField;
        private static bool isMenuFinished;

        public static ConsoleKey CurrentKey = ConsoleKey.NoName;
        public static int myIndex;

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
                default:
                    break;
            }
            Console.Clear();
            for (int i = 0; i < Menu.Length; i++)
            {
                if (myIndex == i)
                {
                    Console.WriteLine(MenuSelected[i]); 
                }
                else
                {
                    Console.WriteLine(Menu[i]);
                }
                
            }
            
        }
    }
}
