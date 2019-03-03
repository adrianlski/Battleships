using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships.Services
{
    class GameInterface : IGameInterface
    {
        private const string COLUMNS = "ABCDEFGHIJ";
        private const int MAX_COLUMNS = 10;
        private const int MAX_ROWS = 10;

        public string GetUserInput()
        {
            Console.WriteLine("Please enter the cell to attack");
            var input = Console.ReadLine();
            return input;
        }

        public void OutputBoard(List<Cell> board)
        {
            PrintColumns();
            PrintRowSeparator();
            for (int i = 1; i <= MAX_ROWS; i++)
            {
                var rowNumber = i == MAX_ROWS ? $"{i}|" : $"{i} |";
                Console.Write(rowNumber);
                for (int j = 0; j < MAX_COLUMNS; j++)
                {
                    var cell = board.Where(x => x.Coordinate.Column == j && x.Coordinate.Row == i - 1).Single();
                    char status;

                    switch (cell.Ship.ShipType)
                    {
                        case ShipType.Empty:
                            status = ' ';
                            break;
                        case ShipType.Battleship:
                            status = 'B';
                            break;
                        case ShipType.Destroyer:
                            status = 'D';
                            break;
                        default:
                            status = ' ';
                            break;
                    }

                    Console.Write($" {status} |");
                }
                Console.Write("\n");
                PrintRowSeparator();
            }
        }

        private void PrintRowSeparator()
        {
            Console.WriteLine("   --- --- --- --- --- --- --- --- --- ---");
        }

        private void PrintColumns()
        {
            Console.Write("  |");
            foreach (var letter in COLUMNS)
            {
                Console.Write($" {letter} |");
            }
            Console.Write("\n");
        }

        public void OutputError(string message)
        {
            Console.WriteLine(message);
        }

        public void OutputInfo(string message)
        {
            Console.WriteLine(message);
        }

        public void OutputResult(object result)
        {
            throw new NotImplementedException();
        }
    }
}
