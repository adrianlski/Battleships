using System.Collections.Generic;
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
            var gridService = new GridService();
            var coordinateParser = new CoordinateParser();
            var gameInterface = new GameInterface();
            var boardService = new BoardService(gridService, ships);

            var game = new Game(boardService, gameInterface, coordinateParser);
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
