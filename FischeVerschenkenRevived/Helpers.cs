using System;
using System.Runtime.InteropServices;

namespace FischeVerschenkenRevived
{
    internal class Helpers
    {
        private static int AmountOfPlacedShips;
        private static Random random = new Random();

    public static string[] MainMenu()
        {
            string Line1and11 = "+-----------------------------+";
            string Line2 = "|                       _ O X |";
            string Line3 = "|                             |";
            string Line4and10 = "|  +-----------------------+  |";
            string Line5 = "|  | { } Schnelles Spiel   |  |";
            string Line6 = "|  | { } Höhe einrichten   |  |";
            string Line7 = "|  | { } Breite einrichten |  |";
            string Line8 = "|  | { } Spiel starten     |  |";
            string Line9 = "|  | { } Beenden           |  |";

            string[] toReturn = new string[11];
            toReturn[0] = Line1and11;
            toReturn[1] = Line2;
            toReturn[2] = Line3;
            toReturn[3] = Line4and10;
            toReturn[4] = Line5;
            toReturn[5] = Line6;
            toReturn[6] = Line7;
            toReturn[7] = Line8;
            toReturn[8] = Line9;
            toReturn[9] = Line4and10;
            toReturn[10] = Line1and11;


            return toReturn;

        }
        public static string[] MainMenuSelected()
        {
            string Line1and11 = "+-----------------------------+";
            string Line2 = "|                       _ O X |";
            string Line3 = "|                             |";
            string Line4and10 = "|  +-----------------------+  |";
            string Line5 = "|  | {o} Schnelles Spiel   |  |";
            string Line6 = "|  | {o} Höhe einrichten   |  |";
            string Line7 = "|  | {o} Breite einrichten |  |";
            string Line8 = "|  | {o} Spiel starten     |  |";
            string Line9 = "|  | {o} Beenden           |  |";

            string[] toReturn = new string[11];
            toReturn[0] = Line1and11;
            toReturn[1] = Line2;
            toReturn[2] = Line3;
            toReturn[3] = Line4and10;
            toReturn[4] = Line5;
            toReturn[5] = Line6;
            toReturn[6] = Line7;
            toReturn[7] = Line8;
            toReturn[8] = Line9;
            toReturn[9] = Line4and10;
            toReturn[10] = Line1and11;


            return toReturn;

        }

        internal static int StartInput(string v)
        {
            int width;
            int height;

            switch (v)
            {
                case "Height":
                    int maxHeight = Console.LargestWindowHeight - 10;
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie die Höhe");
                    Console.WriteLine("des Spielfelds als Zahl ein");
                    Console.WriteLine("gültig: 20 - " + maxHeight.ToString());
                    if (Int32.TryParse(Console.ReadLine(), out height) == true && height <= maxHeight && height > 19)
                    {
                        return height;
                    }
                    else
                    {
                        Console.WriteLine("Die eingegebene Zahl ist leider nicht gültig. Bitte neue Höhe eingeben.");
                        StartInput(v);
                    }
                    break;
                case "Width":
                    int maxWidth = (Console.LargestWindowWidth - 10) / 2;
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie die Breite");
                    Console.WriteLine("des Spielfelds als Zahl ein");
                    Console.WriteLine("gültig: 20 - " + maxWidth.ToString());
                    if (Int32.TryParse(Console.ReadLine(), out width) == true && width <= maxWidth && width > 19)
                    {
                        return width;
                    }
                    else
                    {
                        Console.WriteLine("Die eingegebene Zahl ist leider nicht gültig. Bitte neue Höhe eingeben.");
                        StartInput(v);
                    }
                    break;
                default:
                    break;
            }
            return 0;
        }

        internal static Game.ShipType RandomShipType()
        {

            return (Game.ShipType)random.Next(2, 6);
        }

        internal static bool CheckSurroundingFor(Position possiblePosition, System.Collections.Generic.List<Ship> battlefield, bool debug)
        {
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                { 
                    if (!(possiblePosition.XValue + x < 0) && !(possiblePosition.YValue + y < 0))
                    {
                        if (!(possiblePosition.XValue + x > Program.BoardWidth) && !(possiblePosition.YValue > Program.BoardHeight))
                        {
                            if (debug)
	                        {
                                DrawCheckGenerator(possiblePosition, x, y);
                            }
                            foreach (Ship s in battlefield)
                            {
                                foreach (Position subship in s.subShips)
                                {
                                    if (debug)
	                                {
                                        DrawShipGenerator(subship);
                                    }
                                    if (possiblePosition.XValue + x == subship.XValue && possiblePosition.YValue + y == subship.YValue)
                                    {
                                        Console.SetCursorPosition(possiblePosition.XValue + x, possiblePosition.YValue + y);
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.Write("/");
                                        Console.ResetColor();
                                        return false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        internal static void DrawCheckGenerator(Position possiblePosition, int x, int y)
        {
            // draw X,Y Coordinates
            Console.SetCursorPosition(Program.BoardWidth + 4, Program.BoardHeight + 4);
            Console.Write("XXXXX");
            Console.SetCursorPosition(Program.BoardWidth + 4, Program.BoardHeight + 4);
            Console.Write((possiblePosition.XValue + x) + "," + (possiblePosition.YValue + y));
            //draw Checked Fields
            Console.SetCursorPosition(possiblePosition.XValue + x, possiblePosition.YValue + y);
            Console.Write("X");
        }
        internal static void DrawShipGenerator(Position subship)
        {
            Console.SetCursorPosition(subship.XValue, subship.YValue);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
            Console.ResetColor();
        }
    }
}