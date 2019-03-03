using Battleships.Interfaces;
using Battleships.Models;
using System;

namespace Battleships
{
    public class CoordinateParser : ICoordinateParser
    {
        private const string COLUMN_LETTERS = "abcdefghij";

        public Coordinate ParseInput(string input)
        {
            var lowerCaseInput = input.ToLower();
            if (!IsInputValid(lowerCaseInput))
            {
                throw new ArgumentException("The input is invalid");
            }

            var column = COLUMN_LETTERS.IndexOf(lowerCaseInput[0]);
            int.TryParse(lowerCaseInput.Substring(1), out int row);

            return new Coordinate { Column = column, Row = row - 1 };
        }

        private bool ValidateLength(string input)
        {
            return input.Length >= 1 && input.Length <= 3;
        }

        private bool ValidateRow(string input)
        {
            var validNumber = int.TryParse(input, out int number);
            if (!validNumber)
            {
                return false;
            }

            return number >= 1 && number <= 10;
        }

        private bool ValidateColumn(char c)
        {
            return COLUMN_LETTERS.IndexOf(c) != -1;
        }

        private bool IsInputValid(string input)
        {
            if (!ValidateLength(input))
            {
                return false;
            }

            var validColumn = ValidateColumn(input[0]);
            var validRow = ValidateRow(input.Substring(1));

            return validColumn && validRow;
        }
    }
}