using System;
using Battleships.Interfaces;
using Battleships.Models;

namespace Battleships
{
    public class Game : IGame
    {
        private IBoardService _board;
        private ICellValidator _cellValidator;
        private IGameInterface _gameInterface;

        public Game(IBoardService board, ICellValidator cellValidator, IGameInterface gameInterface)
        {
            _board = board;
            _cellValidator = cellValidator;
            _gameInterface = gameInterface;
        }

        public void Start()
        {
            _board.InitializeBoard();
            _gameInterface.OutputBoard(_board.GetBoard());

            while (true)
            {
                var coordinates = GetCoordinates();
                var result = _board.TakeAShot(coordinates);
                _gameInterface.OutputResult(result);
                _gameInterface.OutputBoard(_board.GetBoard());

                if (GameFinished())
                {
                    EndGame();
                }
            }
        }

        private Coordinate GetCoordinates()
        {
            var input = _gameInterface.GetUserInput();

            while (true)
            {
                if (_cellValidator.IsInputValid(input))
                {
                    return _cellValidator.ParseInput(input);
                }

                _gameInterface.OutputError("Please enter a valid cell, e.g A1");
            }
        }
        private void EndGame()
        {
            _gameInterface.OutputInfo("All ships sunk! Thanks for playing.");
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
