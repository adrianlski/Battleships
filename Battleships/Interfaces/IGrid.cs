using Battleships.Enums;
using Battleships.Models;
using Battleships.Ships;
using System.Collections.Generic;

namespace Battleships.Interfaces
{
    public interface IGrid
    {
        void InitializeGrid();
        List<Cell> GetAllCells();
        bool CheckIfValidLocationForShip(Coordinate coordinate);
        void PlaceShipOnGrid(Ship ship, Coordinate coordinate);
        Cell GetCell(Coordinate coordinate);
        void ChangeCellStatus(Coordinate coordinates, CellStatus status);
    }
}