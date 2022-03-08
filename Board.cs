using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        /// <summary>
        /// Inner class to represent a TicTacToe board cell
        /// </summary>
        private class Cell
        {
            public int element { get; private set;} = (int)GameSymbol.Empty;

            private bool isEmpty()
            {
                return element == (int)GameSymbol.Empty;
            }

            internal bool Insert(GameSymbol input)
            {
                if (isEmpty())
                {
                    element = (int)input;
                    return true;
                }
                return false;
            }

            
        }

        /// <summary>
        /// The TicTacToe board,
        /// 0 element is empty and never used for numbering convenience
        /// </summary>
        private Cell[] _board = new Cell[10];

        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                _board[i] = new Cell();
            }
        }

        public bool InsertIntoCell(int cellNumber, GameSymbol input)
        {
            // if insert is successful the Insert method return true
            if(cellNumber >= 1 && cellNumber <= 9)
                return _board[cellNumber].Insert(input);

            return false;
        }

        public bool isWinner(GameSymbol symbol)
        {
            int symbolInt = (int)symbol;

            // First Row
            if (_board[1].element == symbolInt && _board[2].element == symbolInt && _board[3].element == symbolInt)
                return true;

            // Second Row
            if (_board[4].element == symbolInt && _board[5].element == symbolInt && _board[6].element == symbolInt)
                return true;

            // Third Row
            if (_board[7].element == symbolInt && _board[8].element == symbolInt && _board[9].element == symbolInt)
                return true;

            // First Column
            if (_board[1].element == symbolInt && _board[4].element == symbolInt && _board[7].element == symbolInt)
                return true;

            // Second Column
            if (_board[2].element == symbolInt && _board[5].element == symbolInt && _board[8].element == symbolInt)
                return true;

            // Third Column
            if (_board[3].element == symbolInt && _board[6].element == symbolInt && _board[9].element == symbolInt)
                return true;

            // Main Diagonal 
            if (_board[1].element == symbolInt && _board[5].element == symbolInt && _board[9].element == symbolInt)
                return true;

            // Counter Diagonal
            if (_board[3].element == symbolInt && _board[5].element == symbolInt && _board[7].element == symbolInt)
                return true;

            return false;
        }

        public bool isFull()
        {
            if (_board.Count(x => x.element == (int)GameSymbol.Empty) == 1)
                return true;
            return false;
        }

    }
}
