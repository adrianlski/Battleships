using Battleships.Enums;
using Battleships.Models;
using System.Collections.Generic;

namespace Battleships.Interfaces
{
    public interface IBoardService
    {
        void InitializeBoard();
        string TakeAShot(Coordinate coordinates);
        List<Cell> GetBoard();
        bool AllShipsSunk();
    }
}