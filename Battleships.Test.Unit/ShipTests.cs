using Battleships.Enums;
using Battleships.Ships;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Battleships.Test.Unit
{
    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void DestroyerTest()
        {
            // Arrange
            var destroyer = new Destroyer();

            // Assert
            Assert.AreEqual(destroyer.ShipType, ShipType.Destroyer);
            Assert.AreEqual(destroyer.Length, 4);
            Assert.AreEqual(destroyer.HitCount, 0);
            Assert.AreEqual(destroyer.DisplayName, 'D');
            Assert.AreEqual(destroyer.Name, "Destroyer");
        }

        [Test]
        public void BattleshipTest()
        {
            // Arrange
            var battleship = new Battleship();

            // Assert
            Assert.AreEqual(battleship.ShipType, ShipType.Battleship);
            Assert.AreEqual(battleship.Length, 5);
            Assert.AreEqual(battleship.HitCount, 0);
            Assert.AreEqual(battleship.DisplayName, 'B');
            Assert.AreEqual(battleship.Name, "Battleship");
        }

        [Test]
        public void IsSunkReturnsFalseWhenShipIsNotYetSunk()
        {
            // Arrange
            var ship = new Battleship();
            ship.HitCount = 4;

            // Act
            var result = ship.IsSunk;

            // Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        public void IsSunkReturnsTruWhenShipIsSunk()
        {
            // Arrange
            var ship = new Battleship();
            ship.HitCount = 5;

            // Act
            var result = ship.IsSunk;

            // Assert
            Assert.AreEqual(result, true);
        }
    }
}