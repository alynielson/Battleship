using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        public Board board;
        public string name;
        

        public Player()
        {
            board = new Board();   
        }

        public void GetPlayerName(string playerNumber)
        {
            Console.WriteLine(playerNumber + ", what is your name?");
            name = Console.ReadLine();
            if (name.Length == 0)
            {
                Console.WriteLine("You didn't type anything! Try again.");
                GetPlayerName(playerNumber);
            }
            
        }

      
    }
}
