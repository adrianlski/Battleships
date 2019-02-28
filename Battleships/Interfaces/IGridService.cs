using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface ICellGrid
    {
        void InitializeGrid();
        bool AreCellNeighboursEmpty(int column, int row);
    }
}