using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Game
    {
        Player player1;
        Player player2;






        public Game()
        {

        }

        public void StartGame()
        {
            player1 = new Player();
            player2 = new Player();
            player1.GetPlayerName("Player 1");
            player2.GetPlayerName("Player 2");
        }

        public void PlaceShipsInitialDialogue()
        {
            Console.WriteLine("Time to place your ships! " + player2.name + ", leave the screen so " + player1.name + " can place their ships.");
            Console.WriteLine(player1.name + ", press any key to continue.");
            Console.ReadLine();
            Console.Clear();
            player1.board.CreateBoardInitially();
        }
        public void PlaceShips()
        {
            bool isSpotOccupied = false;
            do
            {
                if (isSpotOccupied == true)
                {
                    Console.WriteLine("You tried to put a ship on top of another! Must choose a different spot.");
                }
                player1.board.DisplayBoard();
                string orientation = player1.board.destroyer.GetShipOrientation();
                int shipStartLocation = player1.board.destroyer.GetStartingPoint();
                bool isValidStartLocation = player1.board.CheckIfShipIsOnTheBoard(shipStartLocation, player1.board.destroyer.size, orientation);
                while (isValidStartLocation == false)
                {
                    Console.WriteLine("Your ship is not on the board! Try again. Press enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    player1.board.DisplayBoard();
                    orientation = player1.board.destroyer.GetShipOrientation();
                    shipStartLocation = player1.board.destroyer.GetStartingPoint();
                    isValidStartLocation = player1.board.CheckIfShipIsOnTheBoard(shipStartLocation, player1.board.destroyer.size, orientation);
                }
                int shipSecondAxisLocation = player1.board.destroyer.GetSecondAxisLocation();
                bool isValidSecondAxisLocation = player1.board.CheckIfValidSecondAxisLocation(shipSecondAxisLocation);
                while (isValidSecondAxisLocation == false)
                {
                    Console.WriteLine("That choice is not on the board! Try again. Press enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    player1.board.DisplayBoard();
                    shipSecondAxisLocation = player1.board.destroyer.GetSecondAxisLocation();
                    isValidSecondAxisLocation = player1.board.CheckIfValidSecondAxisLocation(shipSecondAxisLocation);
                }
                int shipSize = player1.board.destroyer.size;
                isSpotOccupied = player1.board.CheckIfSpotOccupied(shipStartLocation, shipSecondAxisLocation, orientation, shipSize);
                if (!isSpotOccupied)
                {
                    player1.board.PutShipOnBoard(shipStartLocation, shipSecondAxisLocation, orientation, shipSize);
                    player1.board.DisplayBoard();
                    Console.WriteLine("Ship has been placed! Next ship.");
                    Console.ReadLine();
                }

            }
            while (isSpotOccupied == true);
        }
    }


}
