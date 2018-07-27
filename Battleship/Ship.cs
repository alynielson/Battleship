using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    abstract class Ship
    {
        public int size;
        public int startRowOrColumn;
        public string orientation;
        public string name;

        public string GetShipOrientation()
        {
            Console.WriteLine("Would you like to place the " + name + " horizontally (H) or vertically (V) on the board? Type a letter.");
            orientation = Console.ReadLine().ToUpper().Trim();
            while (orientation != "H" && orientation != "V")
            {
                Console.WriteLine("You didn't type H or V! Try again.");
                orientation = Console.ReadLine().ToUpper().Trim();
            }
            return orientation;
        }

        public int GetStartingPoint()
        {
            if (orientation == "H")
            {
                Console.WriteLine("Enter the column number in which the left-most side of the " + name + " will be.");
            }
            else if (orientation == "V")
            {
                Console.WriteLine("Enter the row number in which the top-most side of the " + name + " will be.");
            }
            string response = Console.ReadLine();
            startRowOrColumn = 0;
            bool isNumericAnswer = Int32.TryParse(response, out startRowOrColumn);
            while (!isNumericAnswer || startRowOrColumn == 0)
            {
                Console.WriteLine("You didn't enter a number! Try again.");
                response = Console.ReadLine();
                isNumericAnswer = Int32.TryParse(response, out startRowOrColumn);
            }
            return startRowOrColumn;
        }

        
        

    }
}
