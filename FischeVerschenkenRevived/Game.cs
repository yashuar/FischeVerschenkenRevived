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

        public static int countOfBattleShip = 1;
        public static int countOfCruiser = 2;
        public static int countOfDestroyer = 3;
        public static int countOfSubmarine = 4;
        public int[] countOf = new int[6];
        private static Random random = new Random();

        private bool debug;
        private int cursorX;
        private int cursorY;
        private bool isFirstGameStart = true;
        private List<Ship> Battlefield;
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
                    PrepareField(20,20);
                    ShowHints();
                    //TODO DrawGame();
                    break;
                case "Play":
                    PrepareField(Program.BoardHeight, Program.BoardWidth);
                    //TODO DrawGame();
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
            bool allShipsPlaced = false;
            while (allShipsPlaced == false)
            {
                allShipsPlaced = PlaceShip(Battlefield);
            }
            
            
        }

        private bool PlaceShip(List<Ship> battlefield)
        {
            bool GeneralCanPlace;
            bool AllSubshipsPlaced = false;
            if (this.Battlefield.Count == 10)
            {
                GeneralCanPlace = false;
            }
            else
            {
                GeneralCanPlace = true;
            }

            while (GeneralCanPlace)
            {
                if (this.Battlefield.Count == 10)
                {
                    GeneralCanPlace = false;
                }

                Ship ship = new Ship();
                ship.SetShipType(Helpers.RandomShipType());
                List<Position> subShips = new List<Position>();

                
                // while CountOf of Subships is smaller than a Ship of ShipType ship.GetShipType()
                // add Subships to Ship ship
                while (subShips.Count < (int)ship.GetShipType())
                {
                    bool ValidXValue = true;
                    bool ValidYValue = true;
                    Position possiblePosition = new Position();
                    // Place first Subship
                    if (subShips.Count == 0)
                    {
                        
                        possiblePosition.XValue = random.Next(0,Program.BoardWidth);
                        possiblePosition.YValue = random.Next(0, Program.BoardHeight);
                        ship.direction = (CardinalDirection)random.Next(0, 3);

                        // if there is a ship on the same Position already, set Valid_Value to false
                        foreach (Ship s in Battlefield)
                        {
                            foreach (Position subship in s.subShips)
                            {
                                if (subship.XValue == possiblePosition.XValue)
                                {
                                    ValidXValue = false;
                                }
                                if (subship.YValue == possiblePosition.YValue)
                                {
                                    ValidYValue = false;
                                }
                            }
                            
                        }
                        if (ValidXValue == true && ValidYValue == true)
                        {
                            subShips.Add(possiblePosition);
                        }
                        else return false;
                    }
                    else
                    {
                        Position nextPossiblePosition = new Position();
                        switch (ship.direction)
                        {
                            case CardinalDirection.North:
                                nextPossiblePosition.YValue = (subShips[subShips.Count - 1].YValue + 1);
                                nextPossiblePosition.XValue = subShips[subShips.Count - 1].XValue;
                                subShips.Add(nextPossiblePosition);
                                break;
                            case CardinalDirection.East:
                                nextPossiblePosition.YValue = subShips[subShips.Count - 1].YValue;
                                nextPossiblePosition.XValue = (subShips[subShips.Count - 1].XValue + 1);
                                subShips.Add(nextPossiblePosition);
                                break;
                            case CardinalDirection.South:
                                nextPossiblePosition.YValue = (subShips[subShips.Count - 1].YValue - 1);
                                nextPossiblePosition.XValue = subShips[subShips.Count - 1].XValue;
                                subShips.Add(nextPossiblePosition);
                                break;
                            case CardinalDirection.West:
                                nextPossiblePosition.YValue = subShips[subShips.Count - 1].YValue;
                                nextPossiblePosition.XValue = (subShips[subShips.Count - 1].XValue + 1);
                                subShips.Add(nextPossiblePosition);
                                break;
                            default:
                                break;
                        }
                        if (Helpers.CheckSurroundingFor(nextPossiblePosition, battlefield, ship, this) == false)
                        {
                            return false;
                        }
                    }
                    
                }
                ship.SetSubships(subShips);

                switch (ship.GetShipType())
                {
                    case ShipType.Battleship:
                        if (countOfBattleShip == 1)
                        {
                            AllSubshipsPlaced = true;
                            Battlefield.Add(ship);
                            countOfBattleShip++;
                        }
                        break;
                    case ShipType.Cruiser:
                        if (countOfCruiser == 2)
                        {
                            AllSubshipsPlaced = true;
                            Battlefield.Add(ship);
                            countOfCruiser++;
                        }
                        break;
                    case ShipType.Destroyer:
                        if (countOfDestroyer == 3)
                        {
                            AllSubshipsPlaced = true;
                            Battlefield.Add(ship);
                            countOfDestroyer++;
                        }
                        break;
                    case ShipType.Submarine:
                        if (countOfSubmarine == 4)
                        {
                            AllSubshipsPlaced = true;
                            Battlefield.Add(ship);
                            countOfSubmarine++;
                        }
                        break;
                    case ShipType.NoShip:
                        break;
                    default:
                        break;
                }

                if (this.Battlefield.Count == 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
