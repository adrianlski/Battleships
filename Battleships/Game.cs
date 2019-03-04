using Battleships.Interfaces;
using Battleships.Models;
using System;

namespace Battleships
{
    public class Game : IGame
    {
        private readonly IBoardService _board;
        private readonly IGameInterface _gameInterface;
        private readonly ICoordinateParser _coordinateParser;

        public Game(IBoardService board, IGameInterface gameInterface, ICoordinateParser coordinateParser)
        {
            _board = board;        
            _gameInterface = gameInterface;
            _coordinateParser = coordinateParser;
        }

        public void Start()
        {
            _board.InitializeBoard();
            _gameInterface.OutputBoard(_board.GetBoard());

            while (true)
            {
                _gameInterface.OutputInfo("Please enter the cell to attack");

                var coordinates = GetCoordinates();
                var result = _board.TakeAShot(coordinates);

                _gameInterface.OutputBoard(_board.GetBoard());
                _gameInterface.OutputInfo(result);

                if (GameFinished())
                {
                    EndGame();
                    return;
                }
            }
        }

        private Coordinate GetCoordinates()
        {
            while (true)
            {
                var input = _gameInterface.GetUserInput();

                try
                {
                    return _coordinateParser.ParseInput(input);
                }
                catch (ArgumentException)
                {
                    _gameInterface.OutputError("Please enter a valid cell, e.g A1");
                }
            }
        }
        private void EndGame()
        {
            _gameInterface.OutputEndGame("All ships sunk! Thanks for playing.");
        }

        private bool GameFinished()
        {
            if (_board.AllShipsSunk())
            {
                return true;
            }

            return false;
        }

    }
}
