using Battleships.Ships;

namespace Battleships.Models
{
    public class Cell
    {
        public Coordinate Coordinate { get; set; }
        public Ship Ship { get; set; }
    }
}