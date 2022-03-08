using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class Helper
    {
        /// <summary>
        /// Gets the position number from  the button,
        /// inserts into the board,
        /// and changes the caller button's text to player symbol
        /// </summary>
        /// <param name="button">Button caller</param>
        public static void playerMove(Button button, Board board, GameSymbol playerSymbol)
        {
            // get number of the cell from random? empty button field
            int cellNumber = int.Parse(button.AccessibleName);

            // insert the symbol into the board
            board.InsertIntoCell(cellNumber, playerSymbol);

            // change button symbol
            button.Text = playerSymbol.ToString();
        }

        private static Random random = new Random();

        /// <summary>
        /// Insert AI symbol into random position in the board
        /// </summary>
        /// <returns>The insert position from 1 to 9</returns>
        private static int AI_Insert(Board board, GameSymbol AI_Symbol)
        {
            int randomNum;
            while (true)
            {
                randomNum = random.Next(1, 10);
                if (board.InsertIntoCell(randomNum, AI_Symbol))
                {
                    return randomNum;
                }
            }

        }

        /// <summary>
        /// Iterates through List<Button> to change its text to AI symbol
        /// </summary>
        public static void AI_Move(List<Button> buttons, Board board, GameSymbol AI_Symbol)
        {
            
            int buttonNum = AI_Insert(board, AI_Symbol);
            foreach (var button in buttons)
            {
                if (button.AccessibleName == buttonNum.ToString())
                    button.Text = AI_Symbol.ToString();
            }


        }
    }
}
