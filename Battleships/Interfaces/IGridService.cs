using Battleships.Enums;
using Battleships.Models;
using Battleships.Ships;
using System.Collections.Generic;

namespace Battleships.Interfaces
{
    public interface IGridService
    {
        void InitializeGrid();
        List<Cell> GetAllCells();
        bool CheckIfValidLocationForShip(Coordinate coordinate);
        void PlaceShipOnGrid(Ship ship, Coordinate coordinate);
        ShipStatus CheckCellStatus(Coordinate coordinate);
    }
}