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

        public bool CheckIfValidLocationForShip(int column, int row)
        {
            if (IsOutOfBounds(column, row))
            {
                return false;
            }

            var potentialCell = Cells.Where(x => x.Coordinate.Column == column && x.Coordinate.Row == row).Single();

            if (potentialCell.Ship.ShipType == ShipType.Empty)
            {
                return true;
            }

            return false;
        }

        private bool IsOutOfBounds(int column, int row)
        {
            return (column >= MAX_COLUMN_NUM || column < 0) || (row >= MAX_ROW_NUM || row < 0);
        }

        public void PlaceShipOnGrid(Ship ship, int column, int row)
        {
            Cells.Where(x => x.Coordinate.Column == column && x.Coordinate.Row == row).Single().Ship = ship;
        }

        public ShipStatus CheckCellStatus(int column, int row)
        {
            return Cells.Where(x => x.Coordinate.Column == column && x.Coordinate.Row == row).Single().Ship.ShipStatus;
        }
    }
}