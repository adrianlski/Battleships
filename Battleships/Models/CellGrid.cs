using System.Collections.Generic;
using Battleships.Enums;
using Battleships.Models;
using Battleships.Interfaces;

namespace Battleships
{
    public class CellGrid : ICellGrid
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

        public bool AreCellNeighboursEmpty(Cell cell)
        {
            throw new System.NotImplementedException();
        }
    }
}