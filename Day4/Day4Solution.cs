using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.Day4.Models;

namespace AdventOfCode2021.Day4
{
    public class Day4Solution : SolutionBase
    {
        public override string Part1()
        {
            var data = Read();
            var numbers = data[0].Split(",").ToList();
            var boards = MakeBoards(data).ToList();

            // Check boards and mark numbers
            // Loop each number
            foreach (var number in numbers)
            {
                // Loop each board
                foreach (var board in boards)
                {
                    // Loop each board row
                    foreach (var boardRow in board.BoardRows)
                    {
                        // Loop each number in the boardRow
                        foreach (var boardNumber in boardRow.BoardNumbers)
                        {
                            if (boardNumber.Number == number.ToString())
                            {
                                // Number matches, mark the board
                                boardNumber.IsMarked = true;

                                // Check if that makes the board win
                                if (board.IsWinner())
                                {
                                    // Winner! Return the score of this board
                                    return board.CalculateScore(int.Parse(number)).ToString();
                                }
                            }
                        }
                    }
                }
            }

            return "null";
        }

        public override string Part2()
        {
            var data = Read();
            var numbers = data[0].Split(",").ToList();
            var boards = MakeBoards(data).ToList();

            var winningBoards = new List<Board>();

            // Check boards and mark numbers
            // Loop each number
            foreach (var number in numbers)
            {
                // Loop each board
                foreach (var board in boards)
                {
                    // Only carry on if this board hasn't already won in a previous loop of "number"
                    if ((winningBoards.Where(b => b.Id == board.Id).Count() == 0))
                    {
                        // Loop each board row
                        foreach (var boardRow in board.BoardRows)
                        {
                            // Loop each number in the boardRow
                            foreach (var boardNumber in boardRow.BoardNumbers)
                            {
                                if (boardNumber.Number == number.ToString())
                                {
                                    // Number matches, mark the board
                                    boardNumber.IsMarked = true;

                                    // Check if that makes the board win
                                    if (board.IsWinner())
                                    {
                                        // Winner! Add the board to the list
                                        winningBoards.Add(board);
                                    }
                                }
                            }
                        }
                    }

                }

            }

            return "null";
        }

        /// <summary>
        /// Makes the boards from the data array
        /// </summary>
        private IEnumerable<Board> MakeBoards(string[] data)
        {
            int boardId = 0;

            // Make boards
            for (int i = 2; i < data.Length; i += 6)
            {

                var board = new Board();
                board.Id = boardId;

                // Go down the rows of the board
                for (int j = 0; j < 5; j++)
                {
                    var boardRow = new BoardRow();

                    // Go across the row and add each number to the row
                    var rowData = data[i + j].Replace("  ", " ").Trim().Split(" ");

                    boardRow.BoardNumbers.Add(new BoardNumber { Number = rowData[0] });
                    boardRow.BoardNumbers.Add(new BoardNumber { Number = rowData[1] });
                    boardRow.BoardNumbers.Add(new BoardNumber { Number = rowData[2] });
                    boardRow.BoardNumbers.Add(new BoardNumber { Number = rowData[3] });
                    boardRow.BoardNumbers.Add(new BoardNumber { Number = rowData[4] });

                    board.BoardRows.Add(boardRow);
                }

                boardId++;
                yield return board;
            }
        }
    }
}