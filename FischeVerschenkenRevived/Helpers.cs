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

        internal static bool CheckSurroundingFor(Position possiblePosition, System.Collections.Generic.List<Position> battlefield, Game game)
        {
            foreach (Position pos in battlefield)
            {
                for (int x = -1; x < 3; x++)
                {
                    for (int y = -1; y < 3; y++)
                    {
                        // if Surroundings are blocked or out of Border
                        if ((pos.XValue + x == possiblePosition.XValue || pos.XValue - x < 0 || pos.XValue + x > Program.BoardWidth) || pos.YValue + y == possiblePosition.YValue || pos.YValue - y < 0 || pos.YValue + y > Program.BoardHeight)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}