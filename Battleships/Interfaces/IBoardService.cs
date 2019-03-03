using Battleships.Models;
using System.Collections.Generic;

namespace Battleships.Interfaces
{
    public interface IBoardService
    {
        void InitializeBoard();
        List<Cell> GetBoard();
        string TakeAShot(Coordinate coordinates);
        bool AllShipsSunk();
    }
}