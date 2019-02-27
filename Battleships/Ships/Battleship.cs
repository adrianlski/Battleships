using Battleships.Enums;

namespace Battleships.Ships
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            ShipType = ShipType.Battleship;
            Length = 5;
        }
    }
}