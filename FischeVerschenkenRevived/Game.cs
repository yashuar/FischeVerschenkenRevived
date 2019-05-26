using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FischeVerschenkenRevived
{
    class Game
    {
        public enum CardinalDirection { North = 0, East = 1, South = 2, West = 3 }
        public enum ShipType { Battleship = 5, Cruiser = 4, Destroyer = 3, Submarine = 2, NoShip = 1 }

        public static int countOfBattleShip = 0;
        public static int countOfCruiser = 0;
        public static int countOfDestroyer = 0;
        public static int countOfSubmarine = 0;
        public int[] countOf = new int[6];
        private static Random random = new Random();
        private List<Position> shotAt = new List<Position>();
        private bool debug;
        private int cursorX;
        private int cursorY;
        private bool isFirstGameStart = true;
        private List<Ship> Battlefield;
        private bool gamefinished = false;

        public bool RunGame(string v)
        {
            Random random = new Random();
            countOf[5] = countOfBattleShip;
            countOf[4] = countOfCruiser;
            countOf[3] = countOfDestroyer;
            countOf[2] = countOfSubmarine;

            switch (v)
            {
                case "Quickplay":
                    Program.BoardHeight = 20;
                    Program.BoardWidth = 20;
                    ShowHints();
                    PrepareField(20, 20);
                    DrawGame();
                    Console.ReadKey();
                    break;
                case "Play":
                    PrepareField(Program.BoardHeight, Program.BoardWidth);
                    DrawGame();
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
            if (Program.BoardHeight <= 0 && Program.BoardWidth <= 0)
            {
                return false;
            }
            if (Program.isFirstGameStart == true)
            {
                Console.Clear();
                ShowHints();
            }
            Console.Clear();

            return true;

        }

        private void DrawGame()
        {
            Console.CursorVisible = false;
            do
            {
                Console.Clear();
                CheckForWin();
                DrawField();
                DrawCursor(cursorX, cursorY);
                UserInteraction();
            } while (!gamefinished);
            
        }

        private void CheckForWin()
        {
            int DestructionCounter = 0;
            foreach (Ship ship in Battlefield)
            {
                if (ship.isDestroyed)
                {
                    DestructionCounter++;
                }
            }
            if (DestructionCounter == 10)
            {
                ShowWin();
                gamefinished = true;
            }
        }

        private void ShowWin()
        {
            string[] WinArray = {
                "+---------------------+",
                "|                     |",
                "| Glückwunsch         |",
                "| Sie haben gewonnen! |",
                "|                     |",
                "+---------------------+" };
            Console.SetCursorPosition(Console.BufferWidth / 2, Console.BufferHeight / 2);
            for (int i = Console.BufferWidth / 2; i < (Console.BufferWidth / 2 ) + WinArray.Length; i++)
            {
                    Console.SetCursorPosition(i, Console.BufferHeight / 2);
                    Console.WriteLine(WinArray[i - (Console.BufferWidth / 2)]);
            }
            
            Console.ReadLine();
        }

        private void UserInteraction()
        {
            ConsoleKey key= Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.Backspace:
                    break;
                case ConsoleKey.Tab:
                    break;
                case ConsoleKey.Clear:
                    break;
                case ConsoleKey.Enter:
                    Shoot();
                    break;
                case ConsoleKey.Pause:
                    break;
                case ConsoleKey.Escape:
                    break;
                case ConsoleKey.Spacebar:
                    Shoot();
                    break;
                case ConsoleKey.PageUp:
                    break;
                case ConsoleKey.PageDown:
                    break;
                case ConsoleKey.End:
                    break;
                case ConsoleKey.Home:
                    break;
                case ConsoleKey.LeftArrow:
                    if (cursorX - 1 >= 0)
                    {
                        cursorX--;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (cursorY - 1 >= 0)
                    {
                        cursorY--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (cursorX + 1 <= Program.BoardWidth)
                    {
                        cursorX++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (cursorY + 1 <= Program.BoardHeight)
                    {
                        cursorY++;
                    }
                    break;
                case ConsoleKey.Select:
                    break;
                case ConsoleKey.Print:
                    break;
                case ConsoleKey.Execute:
                    break;
                case ConsoleKey.PrintScreen:
                    break;
                case ConsoleKey.Insert:
                    break;
                case ConsoleKey.Delete:
                    break;
                case ConsoleKey.Help:
                    break;
                case ConsoleKey.D0:
                    break;
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.D7:
                    break;
                case ConsoleKey.D8:
                    break;
                case ConsoleKey.D9:
                    break;
                case ConsoleKey.A:
                    break;
                case ConsoleKey.B:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.D:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.F:
                    break;
                case ConsoleKey.G:
                    break;
                case ConsoleKey.H:
                    break;
                case ConsoleKey.I:
                    break;
                case ConsoleKey.J:
                    break;
                case ConsoleKey.K:
                    break;
                case ConsoleKey.L:
                    break;
                case ConsoleKey.M:
                    break;
                case ConsoleKey.N:
                    break;
                case ConsoleKey.O:
                    break;
                case ConsoleKey.P:
                    break;
                case ConsoleKey.Q:
                    break;
                case ConsoleKey.R:
                    break;
                case ConsoleKey.S:
                    break;
                case ConsoleKey.T:
                    break;
                case ConsoleKey.U:
                    break;
                case ConsoleKey.V:
                    break;
                case ConsoleKey.W:
                    break;
                case ConsoleKey.X:
                    break;
                case ConsoleKey.Y:
                    break;
                case ConsoleKey.Z:
                    break;
                case ConsoleKey.LeftWindows:
                    break;
                case ConsoleKey.RightWindows:
                    break;
                case ConsoleKey.Applications:
                    break;
                case ConsoleKey.Sleep:
                    break;
                case ConsoleKey.NumPad0:
                    break;
                case ConsoleKey.NumPad1:
                    break;
                case ConsoleKey.NumPad2:
                    break;
                case ConsoleKey.NumPad3:
                    break;
                case ConsoleKey.NumPad4:
                    break;
                case ConsoleKey.NumPad5:
                    break;
                case ConsoleKey.NumPad6:
                    break;
                case ConsoleKey.NumPad7:
                    break;
                case ConsoleKey.NumPad8:
                    break;
                case ConsoleKey.NumPad9:
                    break;
                case ConsoleKey.Multiply:
                    break;
                case ConsoleKey.Add:
                    break;
                case ConsoleKey.Separator:
                    break;
                case ConsoleKey.Subtract:
                    break;
                case ConsoleKey.Decimal:
                    break;
                case ConsoleKey.Divide:
                    break;
                case ConsoleKey.F1:
                    break;
                case ConsoleKey.F2:
                    break;
                case ConsoleKey.F3:
                    break;
                case ConsoleKey.F4:
                    break;
                case ConsoleKey.F5:
                    break;
                case ConsoleKey.F6:
                    break;
                case ConsoleKey.F7:
                    break;
                case ConsoleKey.F8:
                    break;
                case ConsoleKey.F9:
                    break;
                case ConsoleKey.F10:
                    break;
                case ConsoleKey.F11:
                    break;
                case ConsoleKey.F12:
                    break;
                case ConsoleKey.F13:
                    break;
                case ConsoleKey.F14:
                    break;
                case ConsoleKey.F15:
                    break;
                case ConsoleKey.F16:
                    break;
                case ConsoleKey.F17:
                    break;
                case ConsoleKey.F18:
                    break;
                case ConsoleKey.F19:
                    break;
                case ConsoleKey.F20:
                    break;
                case ConsoleKey.F21:
                    break;
                case ConsoleKey.F22:
                    break;
                case ConsoleKey.F23:
                    break;
                case ConsoleKey.F24:
                    break;
                case ConsoleKey.BrowserBack:
                    break;
                case ConsoleKey.BrowserForward:
                    break;
                case ConsoleKey.BrowserRefresh:
                    break;
                case ConsoleKey.BrowserStop:
                    break;
                case ConsoleKey.BrowserSearch:
                    break;
                case ConsoleKey.BrowserFavorites:
                    break;
                case ConsoleKey.BrowserHome:
                    break;
                case ConsoleKey.VolumeMute:
                    break;
                case ConsoleKey.VolumeDown:
                    break;
                case ConsoleKey.VolumeUp:
                    break;
                case ConsoleKey.MediaNext:
                    break;
                case ConsoleKey.MediaPrevious:
                    break;
                case ConsoleKey.MediaStop:
                    break;
                case ConsoleKey.MediaPlay:
                    break;
                case ConsoleKey.LaunchMail:
                    break;
                case ConsoleKey.LaunchMediaSelect:
                    break;
                case ConsoleKey.LaunchApp1:
                    break;
                case ConsoleKey.LaunchApp2:
                    break;
                case ConsoleKey.Oem1:
                    break;
                case ConsoleKey.OemPlus:
                    break;
                case ConsoleKey.OemComma:
                    break;
                case ConsoleKey.OemMinus:
                    break;
                case ConsoleKey.OemPeriod:
                    break;
                case ConsoleKey.Oem2:
                    break;
                case ConsoleKey.Oem3:
                    break;
                case ConsoleKey.Oem4:
                    break;
                case ConsoleKey.Oem5:
                    break;
                case ConsoleKey.Oem6:
                    break;
                case ConsoleKey.Oem7:
                    break;
                case ConsoleKey.Oem8:
                    break;
                case ConsoleKey.Oem102:
                    break;
                case ConsoleKey.Process:
                    break;
                case ConsoleKey.Packet:
                    break;
                case ConsoleKey.Attention:
                    break;
                case ConsoleKey.CrSel:
                    break;
                case ConsoleKey.ExSel:
                    break;
                case ConsoleKey.EraseEndOfFile:
                    break;
                case ConsoleKey.Play:
                    break;
                case ConsoleKey.Zoom:
                    break;
                case ConsoleKey.NoName:
                    break;
                case ConsoleKey.Pa1:
                    break;
                case ConsoleKey.OemClear:
                    break;
                default:
                    break;
            }
        }

        private void Shoot()
        {
            Position subship = new Position(cursorX, cursorY, false);
            shotAt.Add(subship);
            foreach (Ship ship in Battlefield)
            {
                Position match = ship.subShips.FirstOrDefault(shipToCheck => shipToCheck.XValue == cursorX && shipToCheck.YValue == cursorY);
                if (match != null)
                {
                    match.isHit = true;
                }  
             }
         }

        private void DrawCursor(int cursorX, int cursorY)
        {
            Console.SetCursorPosition(cursorX * 2,cursorY);
            Console.Write("><");
            Position Cursorposition = new Position(cursorX, cursorY, true);
            foreach (Ship ship in Battlefield)
            {
                foreach (Position sub in ship.subShips)
                {
                    if (sub.isHit && sub.XValue == cursorX && sub.YValue == cursorY)
                    {                        
                        if (ship.isDestroyed == true)
                        {
                            Console.SetCursorPosition(Console.BufferWidth / 2 - 5, Console.BufferHeight - 4);
                            Console.Write(ship.GetShipType() + " zerstört ");
                        }
                        

                    }
                }
            }
            Console.SetCursorPosition(Console.BufferWidth - 10, Console.BufferHeight - 4);
            Console.Write(cursorX.ToString() +"X, " + cursorY.ToString() + "Y");
        }

        private void DrawField()
        {
            for (int yIterator = 0; yIterator <= Program.BoardHeight; yIterator++)
            {
                string Line = "";
                string Cell = null;
                bool shotat = false;
                for (int xIterator = 0; xIterator <= Program.BoardWidth; xIterator++)
                {
                    foreach (Position pos in shotAt)
                    {
                        if (pos.XValue == xIterator && pos.YValue == yIterator)
                        {
                            shotat = true;
                        }
                    }
                    Position subShipPosition = new Position(xIterator, yIterator, true);
                    Ship match = null;
                    foreach (Ship ship in Battlefield)
                    {
                        int subshipHitCounter = 0;
                        foreach (Position subship in ship.subShips)
                        {
                            if (subship.isHit)
                            {
                                subshipHitCounter++;
                            }
                            if (subship.XValue == subShipPosition.XValue && subship.YValue == subShipPosition.YValue && subship.isHit == true)
                            {
                                match = ship;
                            }
                            if (ship.subShips.Count == subshipHitCounter)
                            {
                                ship.isDestroyed = true;
                            }
                        }
                    }
                    if (match != null && match.isDestroyed == false)
                    {
                        Cell = "■■";
                    }
                    else if (match != null && match.isDestroyed == true)
                    {
                        Cell =  "██";
                    }
                    else if (shotat == true)
                    {
                        Cell = "%%";
                    }
                    else
                    {
                        Cell = "~~";
                    }
                    Line += Cell;
                    shotat = false;
                }
                Console.WriteLine(Line);
            }
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
            Program.isFirstGameStart = false;
        }

        private void PrepareField(int boardHeight, int boardWidth)
        {
            Battlefield = new List<Ship>();
            Console.Clear();
            while (this.Battlefield.Count < 10)
            {
                PlaceShip(Battlefield);
            }


        }

        private void PlaceShip(List<Ship> battlefield)
        {
            Ship ship = new Ship();
            ship.SetShipType(Helpers.RandomShipType());
            List<Position> subShips = new List<Position>();

            // while Count of Subships is smaller than the number of Subships of ShipType ship.GetShipType()
            // add Subships to Ship ship
            while (subShips.Count < (int)ship.GetShipType())
            {
                Position possiblePosition = new Position();
                // Place first Subship
                if (subShips.Count == 0)
                {
                    possiblePosition.XValue = random.Next(0, Program.BoardWidth);
                    possiblePosition.YValue = random.Next(0, Program.BoardHeight);

                    ship.direction = (CardinalDirection)random.Next(0, 3);
                    if (Helpers.CheckSurroundingFor(possiblePosition, battlefield, true) == true)
                    {
                        subShips.Add(possiblePosition);
                    }
                }

                // Continue placing
                else
                {
                    Position nextPossiblePosition = new Position();
                    switch (ship.direction)
                    {
                        // Check if Ship does not run out of Map and prepare Position for next Subship, then Check Surrounding of next Postition for other Ships
                        case CardinalDirection.North:
                            if (subShips[0].YValue + (int)ship.GetShipType() <= Program.BoardHeight)
                            {
                                nextPossiblePosition.YValue = (subShips[subShips.Count - 1].YValue + 1);
                                nextPossiblePosition.XValue = subShips[subShips.Count - 1].XValue;
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case CardinalDirection.East:
                            if (subShips[0].XValue + (int)ship.GetShipType() <= Program.BoardWidth)
                            {
                                nextPossiblePosition.YValue = subShips[subShips.Count - 1].YValue;
                                nextPossiblePosition.XValue = (subShips[subShips.Count - 1].XValue + 1);
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case CardinalDirection.South:
                            if (subShips[0].YValue - (int)ship.GetShipType() >= 0)
                            {
                                nextPossiblePosition.YValue = (subShips[subShips.Count - 1].YValue - 1);
                                nextPossiblePosition.XValue = subShips[subShips.Count - 1].XValue;
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case CardinalDirection.West:
                            if (subShips[0].XValue - (int)ship.GetShipType() >= 0)
                            {
                                nextPossiblePosition.YValue = (subShips[subShips.Count - 1].YValue);
                                nextPossiblePosition.XValue = subShips[subShips.Count - 1].XValue - 1;
                            }
                            else
                            {
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                    if (Helpers.CheckSurroundingFor(nextPossiblePosition, battlefield, true) == true)
                    {
                        subShips.Add(nextPossiblePosition);
                    }
                    else return;

                }
            }

            // if all subships are placed, add ship to battlefield
            switch (ship.GetShipType())
            {
                case ShipType.Battleship:
                    if (countOfBattleShip < 1)
                    {
                        ship.SetSubships(subShips);
                        Battlefield.Add(ship);
                        countOfBattleShip++;
                    }
                    break;
                case ShipType.Cruiser:
                    if (countOfCruiser < 2)
                    {
                        ship.SetSubships(subShips);
                        Battlefield.Add(ship);
                        countOfCruiser++;
                    }
                    break;
                case ShipType.Destroyer:
                    if (countOfDestroyer < 3)
                    {
                        ship.SetSubships(subShips);
                        Battlefield.Add(ship);
                        countOfDestroyer++;
                    }
                    break;
                case ShipType.Submarine:
                    if (countOfSubmarine < 4)
                    {
                        ship.SetSubships(subShips);
                        Battlefield.Add(ship);
                        countOfSubmarine++;
                    }
                    break;
                case ShipType.NoShip:
                    break;
                default:
                    break;
            }
        }
    }
}
