using System;

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

            return (Game.ShipType)random.Next(2, 5);
        }

        internal static bool CheckSurroundingFor(Position possiblePosition, System.Collections.Generic.List<Ship> battlefield, Ship ship, Game game)
        {

            foreach (Ship s in battlefield)
            {
                foreach (Position subship in s.subShips)
                {

                    for (int x = -1; x < 2; x++)
                    {
                        for (int y = -1; y < 2; y++)
                        {
                            Console.WriteLine("X:" + (possiblePosition.XValue + x) + "Y:" + (possiblePosition.YValue + y) );
                            // if Surroundings are blocked or out of Border
                            //if ((subship.XValue + x == possiblePosition.XValue || possiblePosition.XValue - x < 0 || possiblePosition.XValue + x > Program.BoardWidth) || subship.YValue + y == possiblePosition.YValue || possiblePosition.YValue - y < 0 || possiblePosition.YValue + y > Program.BoardHeight)
                            //{
                            //}

                            foreach (Ship sh in battlefield)
                            {
                                foreach (Position pos in sh.subShips)
                                {
                                    Console.SetCursorPosition(pos.XValue, pos.YValue);
                                    Console.Write("x");
                                    Console.SetCursorPosition(0, 0);
                                }
                            }
                            if (    possiblePosition.XValue + x > 0 &&
                                   (possiblePosition.XValue + x < Program.BoardWidth) &&
                                   possiblePosition.YValue + y > 0 &&
                                   possiblePosition.YValue + y < Program.BoardHeight
                                )
                            {
                                Console.SetCursorPosition(possiblePosition.XValue + x, possiblePosition.YValue + y);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("O");
                                Console.SetCursorPosition(0, 0);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (    subship.XValue == possiblePosition.XValue + x ||
                                    possiblePosition.XValue + x < 0 ||
                                    (possiblePosition.XValue + x > Program.BoardWidth) ||

                                    subship.YValue == possiblePosition.YValue + y||
                                    possiblePosition.YValue + y < 0 ||
                                    possiblePosition.YValue + y > Program.BoardHeight
                                 )
                            {
                                Console.WriteLine("FALSE");
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}