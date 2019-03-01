using System;
using Battleships.Interfaces;
using Battleships.Models;

namespace Battleships
{
    public class Game : IGame
    {
        private IBoardService _board;
        private ICellValidator _cellValidator;
        //private IGameInterface _gameInterface;

        public Game(IBoardService board, ICellValidator cellValidator)
        {
            _board = board;
            _cellValidator = cellValidator;
        }

        public void Start()
        {
            _board.InitializeBoard();

            while (true)
            {
                var coordinates = GetCoordinates();
                //if not valid return false^^;
                var result = _board.TakeAShot(coordinates);
                OutputResult(result);

                if (GameFinished())
                {
                    EndGame();
                }
            }
        }

        private Coordinate GetCoordinates()
        {
            //_gameInterface.AskForInput();
            Console.WriteLine("Please enter the cell to attack");

            while (true)
            {
                var input = Console.ReadLine();
                if (_cellValidator.IsInputValid(input))
                    //_gameInterface.ReadInput();
                {
                    return _cellValidator.ParseInput(input);
                }

                Console.WriteLine("Please enter a valid cell, e.g A1");
            }
        }

        private void OutputResult(object result)
        {
            throw new NotImplementedException();
        }

        private void EndGame()
        {
            Console.WriteLine("All ships sunks! Thanks for playing.");
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
