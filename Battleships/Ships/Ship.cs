using Battleships.Enums;

namespace Battleships.Ships
{
    public abstract class Ship
    {
        public ShipType ShipType { get; protected set; }
        public int Length { get; protected set; }
        public int HitCount { get; set; }
        public string Name { get; protected set; }
        public char DisplayName { get; protected set; }
        public bool IsSunk => HitCount >= Length;
    }
}