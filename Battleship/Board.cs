﻿using System;
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

        public void DisplayInitialBoard()
        {
            getDisplayWidth();
            CreateEmptyBoard();
            DecideTableCellSize(boardSpots);
            ShowBoard(boardSpots);
        }
        public void getDisplayWidth()
        {
            displayWidth = width + 2;
        }

        public void CreateEmptyBoard()
        {
            boardSpots = new string[displayWidth, displayWidth];
            
            for (int x=0; x < displayWidth; x++)
                {
                    for (int y=0; y < displayWidth; y++)
                    {    
                        boardSpots[x, y] = "O";
                    }
                }
            boardSpots[0, 0] = "+";
            for (int x=2; x < displayWidth; x++)
            {
                boardSpots[x, 0] = (x-1).ToString();
            }
            for (int y=2; y < displayWidth; y++)
            {
                boardSpots[0, y] = (y-1).ToString();
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
                    Console.Write(string.Format("{0}", board[x, y] ));
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadLine();
        }

        public void DecideTableCellSize(string [,] board)
        {
           for (int x=0; x< displayWidth; x++)
            {
                for (int y=0; y< displayWidth; y++)
                {
                    if (board[x,y].Length == 1)
                    {
                        board[x, y] += "  ";
                    }
                    else if (board[x,y].Length == 2)
                    {
                        board[x, y] += " ";
                    }
                }
            }
        }
    }
}
