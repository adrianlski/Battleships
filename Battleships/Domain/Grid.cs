﻿using System.Collections.Generic;
using System.Linq;
using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Ships;

namespace Battleships.Domain
{
    public class Grid : IGrid
    {
        private const int MAX_COLUMN_NUM = 10;
        private const int MAX_ROW_NUM = 10;

        private List<Cell> _cells;

        public void InitializeGrid()
        {
            _cells = new List<Cell>();
            for (var i = 0; i < MAX_COLUMN_NUM; i++)
            {
                for (var j = 0; j < MAX_ROW_NUM; j++)
                {
                    _cells.Add(new Cell
                    {
                        Coordinate = new Coordinate { Column = i, Row = j },
                    });
                }
            }
        }

        public List<Cell> GetAllCells()
        {
            return _cells;
        }

        public bool CheckIfValidLocationForShip(Coordinate coordinates)
        {
            if (IsOutOfBounds(coordinates))
            {
                return false;
            }

            var potentialCell = GetCellByCoordinate(coordinates);

            return potentialCell.Ship == null;
        }

        public void PlaceShipOnGrid(Ship ship, Coordinate coordinates)
        {
            GetCellByCoordinate(coordinates).Ship = ship;
        }

        public Cell GetCell(Coordinate coordinates)
        {
            return GetCellByCoordinate(coordinates);
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
            return _cells.Single(x => x.Coordinate.Column == coordinates.Column && x.Coordinate.Row == coordinates.Row);
        }

        public void ChangeCellStatus(Coordinate coordinates, CellStatus status)
        {
            GetCellByCoordinate(coordinates).CellStatus = status;
        }
    }
}