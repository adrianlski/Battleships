using System.Collections.Generic;
using System.Linq;
using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Models;

namespace Battleships.Services
{
    public class GridService : IGridService
    {
        public List<Cell> Cells { get; private set; }

        public void InitializeGrid()
        {
            Cells = new List<Cell>();
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    Cells.Add(new Cell
                    {
                        Coordinate = new Coordinate { Column = i, Row = j },
                        CellStatus = CellStatus.Empty,
                        ShipType = ShipType.None
                    });
                }
            }
        }

        public bool AreCellNeighboursEmpty(int column, int row)
        {
            var neighbourCells = new List<Cell>
            {
                Cells.Where(x => x.Coordinate.Column == column + 1 && x.Coordinate.Row == row).Single(),
                Cells.Where(x => x.Coordinate.Column == column - 1 && x.Coordinate.Row == row).Single(),
                Cells.Where(x => x.Coordinate.Column == column && x.Coordinate.Row == row + 1).Single(),
                Cells.Where(x => x.Coordinate.Column == column && x.Coordinate.Row == row - 1).Single(),
            };

            return neighbourCells.Where(x => x.CellStatus != CellStatus.Empty).Any();
        }

        public void PlaceShipOnGrid()
        {
            throw new System.NotImplementedException();
        }
    }
}