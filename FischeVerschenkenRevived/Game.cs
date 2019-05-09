using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FischeVerschenkenRevived
{
    class Game
    {
        private static bool debug;
        private static int cursorX;
        private static int cursorY;
        private static bool isFirstGameStart = true;

        public static bool RunGame(string v)
        {
            switch (v)
            {
                case "QuickPlay":
                    PrepareField(20,20);
                    break;
                case "Play":
                    PrepareField(Program.BoardHeight, Program.BoardWidth);
                    break;
                default:
                    break;
            }
            if (Program.BoardHeight <= 0 && Program.BoardWidth <= 0)
            {
                return false;
            }
            if (isFirstGameStart == true)
            {
                Console.Clear();
                ShowHints();
            }
            Console.Clear();

            return true;

        }

        private static void ShowHints()
        {
            // Windows-Size has to be set twice
            Console.SetWindowSize(Program.BoardWidth * 2 + 10, Program.BoardHeight + 10);
            Console.SetBufferSize(Program.BoardWidth * 2 + 10, Program.BoardHeight + 10);
            Console.SetWindowSize(Program.BoardWidth * 2 + 10, Program.BoardHeight + 10);
            Console.WriteLine("Gleich geht es los, F2 Beendet das Spiel.");
            Console.Write("Fehlschüsse");
            Console.Write("getroffene Schiffe");
            Console.Write("leere Felder");
            Console.Write("Cursor");
            Console.WriteLine("Gesteuert wird mit den Pfeiltasten, geschossen mit der Leertaste.");
            Console.ReadLine();
            Console.Clear();
            isFirstGameStart = false;
        }

        private static void PrepareField(int boardHeight, int boardWidth)
        {
            throw new NotImplementedException();
        }
    }
}
