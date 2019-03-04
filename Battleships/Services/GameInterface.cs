using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Services
{
    class GameInterface : IGameInterface
    {
        private const string COLUMNS = "ABCDEFGHIJ";
        private const int MAX_COLUMNS = 10;
        private const int MAX_ROWS = 10;

        public string GetUserInput()
        {
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
                    var cell = board.Single(x => x.Coordinate.Column == j && x.Coordinate.Row == i - 1);
                    char status;

                    switch (cell.CellStatus)
                    {
                        case CellStatus.ShotAt:
                            status = 'x';
                            break;
                        case CellStatus.Hit:
                            status = cell.Ship.DisplayName;
                            break;
                        default:
                            // Cheat mode: uncomment here to see where the ships were placed
                            //if (cell.Ship.ShipType != ShipType.Empty)
                            //{
                            //    status = '.';
                            //}
                            //else 
                            //{
                            //    status = ' ';
                            //}

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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void OutputEndGame(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public void OutputInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}
