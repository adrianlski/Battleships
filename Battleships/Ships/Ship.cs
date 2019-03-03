using Battleships.Enums;

namespace Battleships.Ships
{
    public abstract class Ship
    {
        public ShipType ShipType { get; protected set; }
        public CellStatus ShipStatus { get; set; }
        public int Length { get; protected set; }
        public int HitCount { get; set; }
        public string Name { get; set; }
        public char DisplayName { get; set; }
        public bool IsSunk => HitCount >= Length;
    }
}