using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day4.Models
{
    public class Board
    {
        public int Id { get; set; }
        public List<BoardRow> BoardRows { get; set; } = new List<BoardRow>();

        /// <summary>
        /// Calculates the score of a board
        /// </summary>
        /// <param name="number">The number that was just called</param>        
        public int CalculateScore(int number)
        {
            var unmarked = new List<int>();

            foreach (var row in BoardRows)
            {
                foreach (var num in row.BoardNumbers)
                {
                    if (!num.IsMarked)
                    {
                        unmarked.Add(int.Parse(num.Number));
                    }
                }
            }

            return unmarked.Sum() * number;
        }

        /// <summary>
        /// Checks this board to see if it's a winner
        /// </summary>
        public bool IsWinner()
        {

            // Check if any row has all its numbers marked
            foreach (var boardRow in BoardRows)
            {

                if (
                    boardRow.BoardNumbers[0].IsMarked &&
                    boardRow.BoardNumbers[1].IsMarked &&
                    boardRow.BoardNumbers[2].IsMarked &&
                    boardRow.BoardNumbers[3].IsMarked &&
                    boardRow.BoardNumbers[4].IsMarked)
                {
                    // Row winner!
                    return true;
                }
            }

            // Check if any column has all its numbers marked
            for (int i = 0; i < 5; i++)
            {
                if (
                    BoardRows[0].BoardNumbers[i].IsMarked &&
                    BoardRows[1].BoardNumbers[i].IsMarked &&
                    BoardRows[2].BoardNumbers[i].IsMarked &&
                    BoardRows[3].BoardNumbers[i].IsMarked &&
                    BoardRows[4].BoardNumbers[i].IsMarked)
                {
                    // Column winner!
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Prints the board in a (somewhat) pretty way
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var retVal = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                retVal += string.Concat
                (
                    BoardRows[i].BoardNumbers[0].IsMarked ? $"{BoardRows[i].BoardNumbers[0].Number}*" : BoardRows[i].BoardNumbers[0].Number, " ",
                    BoardRows[i].BoardNumbers[1].IsMarked ? $"{BoardRows[i].BoardNumbers[1].Number}*" : BoardRows[i].BoardNumbers[1].Number, " ",
                    BoardRows[i].BoardNumbers[2].IsMarked ? $"{BoardRows[i].BoardNumbers[2].Number}*" : BoardRows[i].BoardNumbers[2].Number, " ",
                    BoardRows[i].BoardNumbers[3].IsMarked ? $"{BoardRows[i].BoardNumbers[3].Number}*" : BoardRows[i].BoardNumbers[3].Number, " ",
                    BoardRows[i].BoardNumbers[4].IsMarked ? $"{BoardRows[i].BoardNumbers[4].Number}*" : BoardRows[i].BoardNumbers[4].Number, " ", "\n"
                );
            }

            return retVal;
        }
    }
}