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

        public void PlaceShips()
        {
            Console.WriteLine("Time to place your ships! " + player2.name + ", leave the screen so " + player1.name + " can place their ships.");
            Console.WriteLine(player1.name + ", press any key to continue.");
            Console.ReadLine();
            Console.Clear();
            player1.board.DisplayBoard();
            string orientation = player1.board.destroyer.GetShipOrientation();
            int shipStartLocation = player1.board.destroyer.GetStartingPoint();
            bool isValidStartLocation = player1.board.CheckIfShipIsOnTheBoard(shipStartLocation, player1.board.destroyer.size, orientation);
            while (isValidStartLocation == false)
            {
                Console.WriteLine("Your ship is not on the board! Try again. Press any key to continue.");
                Console.ReadLine();
                Console.Clear();
                player1.board.DisplayBoard();
                orientation = player1.board.destroyer.GetShipOrientation();
                shipStartLocation = player1.board.destroyer.GetStartingPoint();
                isValidStartLocation = player1.board.CheckIfShipIsOnTheBoard(shipStartLocation, player1.board.destroyer.size, orientation);
            }
            Console.WriteLine("Ship has been placed! Next ship.");
            Console.ReadLine();
        }
        

    }


}
