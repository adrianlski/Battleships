using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface IGridService
    {
        void InitializeGrid();
        bool AreCellNeighboursEmpty(int column, int row);
        void PlaceShipOnGrid();
    }
}