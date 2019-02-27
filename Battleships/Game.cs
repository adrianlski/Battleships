using System;
using Battleships.Interfaces;
using Battleships.Models;

namespace Battleships
{
    public class Game : IGame
    {
        private IBoard _board;
        private ICellValidator _cellValidator;

        public Game(IBoard board, ICellValidator cellValidator)
        {
            _board = board;
            _cellValidator = cellValidator;
        }

        public void Start()
        {
            while (true)
            {
                var coordinates = GetCoordinates();
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
            Console.WriteLine("Please enter the cell");
            while (true)
            {
                var input = Console.ReadLine();
                if (_cellValidator.IsInputValid(input))
                {
                    return _cellValidator.TransformToCoordinate(input);
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
            throw new NotImplementedException();
        }

        private bool GameFinished()
        {
            throw new NotImplementedException();
        }

    }
}
