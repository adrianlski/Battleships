using Battleships.Enums;
using Battleships.Models;
using System.Collections.Generic;

namespace Battleships.Interfaces
{
    public interface IBoardService
    {
        void InitializeBoard();
        object TakeAShot(Coordinate coordinates);
        ShipStatus CheckCell();
        void ChangeCellStatus();
        List<Cell> GetBoard();
        bool AllShipsSunk();
    }
}