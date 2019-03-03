using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Ships;

namespace Battleships.Services
{
    public class GridService : IGridService
    {
        private const int MAX_COLUMN_NUM = 10;
        private const int MAX_ROW_NUM = 10;

        public List<Cell> Cells { get; private set; }

        public void InitializeGrid()
        {
            Cells = new List<Cell>();
            for (var i = 0; i < MAX_COLUMN_NUM; i++)
            {
                for (var j = 0; j < MAX_ROW_NUM; j++)
                {
                    Cells.Add(new Cell
                    {
                        Coordinate = new Coordinate { Column = i, Row = j },
                        Ship = new EmptyShip()
                    });
                }
            }
        }

        public List<Cell> GetAllCells()
        {
            return Cells;
        }

        public bool CheckIfValidLocationForShip(Coordinate coordinates)
        {
            if (IsOutOfBounds(coordinates))
            {
                return false;
            }

            var potentialCell = GetCellByCoordinate(coordinates);

            if (potentialCell.Ship.ShipType == ShipType.Empty)
            {
                return true;
            }

            return false;
        }

        public void PlaceShipOnGrid(Ship ship, Coordinate coordinates)
        {
            GetCellByCoordinate(coordinates).Ship = ship;
        }

        public ShipStatus CheckCellStatus(Coordinate coordinates)
        {
            return GetCellByCoordinate(coordinates).Ship.ShipStatus;
        }

        private bool IsOutOfBounds(Coordinate coordinates)
        {
            return (coordinates.Column >= MAX_COLUMN_NUM 
                || coordinates.Column < 0)
                || (coordinates.Row >= MAX_ROW_NUM 
                || coordinates.Row < 0);
        }

        private Cell GetCellByCoordinate(Coordinate coordinates)
        {
            return Cells.Where(x => x.Coordinate.Column == coordinates.Column && x.Coordinate.Row == coordinates.Row).Single();
        }

        
    }
}