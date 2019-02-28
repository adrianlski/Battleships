using Battleships.Models;
using Battleships.Ships;
using System.Collections.Generic;

namespace Battleships.Interfaces
{
    public interface IGridService
    {
        void InitializeGrid();
        List<Cell> GetAllCells();
        bool CheckIfValidLocationForShip(int column, int row);
        void PlaceShipOnGrid(Ship ship, int column, int row);
    }
}