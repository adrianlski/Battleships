using Battleships.Enums;
using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface IBoardService
    {
        void InitializeBoard();
        ShipStatus CheckCell();
        void ChangeCellStatus();
        object TakeAShot(Coordinate coordinates);
        bool AllShipsSunk();
    }
}