using Battleships.Enums;
using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface IBoard
    {
        void PlaceShips();
        CellStatus CheckCell();
        void ChangeCellStatus();
        object TakeAShot(Coordinate coordinates);
    }
}