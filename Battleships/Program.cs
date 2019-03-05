using System.Collections.Generic;
using Battleships.Domain;
using Battleships.Services;
using Battleships.Ships;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = InitializeGame();
            game.Start();
        }

        private static Game InitializeGame()
        {
            var ships = GetShips();
            var grid = new Grid();
            var coordinateParser = new CoordinateParser();
            var gameInterface = new GameInterface();
            var randomiser = new Randomiser();
            var board = new Board(grid, randomiser, ships);

            var game = new Game(board, gameInterface, coordinateParser);
            return game;
        }

        private static List<Ship> GetShips()
        {
            return new List<Ship>
            {
                new Battleship(),
                new Destroyer(),
                new Destroyer()
            };
        }
    }
}
