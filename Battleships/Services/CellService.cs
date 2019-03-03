using Battleships.Interfaces;
using Battleships.Models;

namespace Battleships
{
    public class CellValidator : ICellValidator
    {
        // Inject to the board class
        private const string COLUMN_LETTERS = "ABCDEFGHIJ";

        public bool IsInputValid(string input)
        {
            if (!ValidateLength(input))
            {
                return false;
            }

            var validColumn = ValidateColumn(input[0]);
            var validRow = ValidateRow(input.Substring(1));

            return validColumn && validRow;
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

        public Coordinate ParseInput(string input)
        {
            var column = COLUMN_LETTERS.IndexOf(input[0]);
            int.TryParse(input.Substring(1), out int row);

            return new Coordinate{Column = column, Row = row - 1};
        }
    }
}