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
            player1.board.DisplayInitialBoard();
            
        }

        

    }


}
