using Battleships.Models;
using System.Collections.Generic;

namespace Battleships.Interfaces
{
    public interface IBoard
    {
        void InitializeBoard();
        List<Cell> GetBoard();
        string TakeAShot(Coordinate coordinates);
        bool AllShipsSunk();
    }
}