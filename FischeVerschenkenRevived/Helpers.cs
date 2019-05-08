namespace FischeVerschenkenRevived
{
    internal class Helpers
    {
        public static string[] MainMenu()
        {
            string Line1and11   = "+-----------------------------+";
            string Line2        = "|                       _ O X |";
            string Line3        = "|                             |";
            string Line4and10   = "|  +-----------------------+  |";
            string Line5        = "|  | { } Schnelles Spiel   |  |";
            string Line6        = "|  | { } Höhe einrichten   |  |";
            string Line7        = "|  | { } Breite einrichten |  |";
            string Line8        = "|  | { } Spiel starten     |  |";
            string Line9        = "|  | { } Beenden           |  |";

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
            string Line1and11   = "+-----------------------------+";
            string Line2        = "|                       _ O X |";
            string Line3        = "|                             |";
            string Line4and10   = "|  +-----------------------+  |";
            string Line5        = "|  | {o} Schnelles Spiel   |  |";
            string Line6        = "|  | {o} Höhe einrichten   |  |";
            string Line7        = "|  | {o} Breite einrichten |  |";
            string Line8        = "|  | {o} Spiel starten     |  |";
            string Line9        = "|  | {o} Beenden           |  |";

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
    }
}