using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        string[,] boardSpots;
        public static int width;
        public static int height;
        public static int displayWidth;
        public Destroyer destroyer;
        public Submarine submarine;
        public Battleship battleship;
        public AircraftCarrier aircraftCarrier;

        public Board()
        {
            GetBoardSize();
            destroyer = new Destroyer();
            submarine = new Submarine();
            battleship = new Battleship();
            aircraftCarrier = new AircraftCarrier();
        }

        public void GetBoardSize()
        {
            width = GetDesiredWidth();
            height = GetHeightFromWidth();
        }

        public int GetDesiredWidth()
        {
            if (width >= 20)
            {
                return width;
            }
            else
            {
                Console.WriteLine("How many spaces wide do you want the boards to be? Must be at least 20.");
                string widthString = Console.ReadLine();
                width = 0;
                bool isNumericAnswer = int.TryParse(widthString, out width);
                while (!isNumericAnswer || width < 20)
                {
                    Console.WriteLine("You didn't type a number that is 20 or more! Try again.");
                    widthString = Console.ReadLine();
                    isNumericAnswer = int.TryParse(widthString, out width);
                }
                return width;
            }
        }

        public int GetHeightFromWidth()
        {
            if (height >= 20)
            {
                return height;
            }
            else
            {
                height = width;
                return height;
            }
        }

        public void DisplayBoard()
        {
            DecideTableCellSize(boardSpots);
            ShowBoard(boardSpots);
        }

        public void CreateBoardInitially()
        {
            getDisplayWidth();
            CreateBoard();
        }
        public void getDisplayWidth()
        {
            displayWidth = width + 2;
        }

        public void CreateBoard()
        {
            boardSpots = new string[displayWidth, displayWidth];

            for (int x = 0; x < displayWidth; x++)
            {
                for (int y = 0; y < displayWidth; y++)
                {
                    boardSpots[x, y] = "O";
                }
            }
            boardSpots[0, 0] = "+";
            for (int x = 2; x < displayWidth; x++)
            {
                boardSpots[x, 0] = (x - 1).ToString();
            }
            for (int y = 2; y < displayWidth; y++)
            {
                boardSpots[0, y] = (y - 1).ToString();
            }
            for (int x = 0; x < displayWidth; x++)
            {
                boardSpots[x, 1] = "|";
            }
            for (int y = 0; y < displayWidth; y++)
            {
                boardSpots[1, y] = "|";
            }



        }

        public void ShowBoard(string[,] board)
        {
            for (int y = 0; y < displayWidth; y++)
            {
                for (int x = 0; x < displayWidth; x++)
                {
                    Console.Write(string.Format("{0}", board[x, y]));
                }
                Console.Write(Environment.NewLine);
            }
        }

        public void DecideTableCellSize(string[,] board)
        {
            for (int x = 0; x < displayWidth; x++)
            {
                for (int y = 0; y < displayWidth; y++)
                {
                    if (board[x, y].Length == 1)
                    {
                        board[x, y] += "  ";
                    }
                    else if (board[x, y].Length == 2)
                    {
                        board[x, y] += " ";
                    }
                }
            }
        }

        public bool CheckIfShipIsOnTheBoard(int shipStartLocation, int shipSize, string shipOrientation)
        {
            bool isValidStartLocation;
            if (shipStartLocation > width)
            {
                isValidStartLocation = false;
            } 
            else if (width - shipStartLocation < shipSize - 1)
            {
                isValidStartLocation = false;
            }
            else
            {
                isValidStartLocation = true;
            }
            return isValidStartLocation;
        }

        public bool CheckIfValidSecondAxisLocation(int shipSecondAxisLocation)
        {
            bool isValidSecondAxisLocation = true;
            if (shipSecondAxisLocation < 1)
            {
                isValidSecondAxisLocation = false;
            }
            else if (shipSecondAxisLocation > width)
            {
                isValidSecondAxisLocation = false;
            }
            return isValidSecondAxisLocation;
        }

        public void PutShipOnBoard(int startLocation, int secondAxisLocation, string orientation, int shipSize) 
        {
            int displayLocation = startLocation + 1;
            int secondAxisDisplayLocation = secondAxisLocation + 1;
            for (int x = displayLocation; x < displayLocation + shipSize; x++)
            {
                if (orientation == "H")
                {
                    boardSpots[x, secondAxisDisplayLocation] = "S";
                }
                else if (orientation == "V")
                {
                    boardSpots[secondAxisDisplayLocation, x] = "S";
                }
            }
        }

        public bool CheckIfSpotOccupied(int startLocation, int secondAxisLocation, string orientation, int shipSize)
        {
            bool isSpotOccupied = false;
            int displayLocation = startLocation + 1;
            int secondAxisDisplayLocation = secondAxisLocation + 1;
            for (int x = displayLocation; x < displayLocation + shipSize; x++)
            {
                if (orientation == "H")
                {
                    if (boardSpots[x, secondAxisDisplayLocation] == "S")
                    {
                        isSpotOccupied = true;
                        break;
                    }   
                }
                else if (orientation == "V")
                {
                    if (boardSpots[secondAxisDisplayLocation, x] == "S")
                    {
                        isSpotOccupied = true;
                        break;
                    }
                }
            }
            return isSpotOccupied;

        }


    }
}
