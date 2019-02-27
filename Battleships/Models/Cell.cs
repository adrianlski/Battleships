using Battleships.Enums;

namespace Battleships.Models
{
    public class Cell
    {
        public Coordinate Coordinate { get; set; }
        public CellStatus CellStatus { get; set; }
        public ShipType ShipType { get; set; }
    }
}