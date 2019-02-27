using Battleships.Enums;

namespace Battleships.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            ShipType = ShipType.Destroyer;
            Length = 4;
        }
    }
}