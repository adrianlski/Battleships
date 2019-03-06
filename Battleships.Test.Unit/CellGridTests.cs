using Battleships.Domain;
using Battleships.Enums;
using Battleships.Models;
using Battleships.Ships;
using NUnit.Framework;

namespace Battleships.Test.Unit
{
    [TestFixture]
    public class CellGridTests
    {
        private Grid _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Grid();
        }

        [Test]
        public void InitializeGridCreatesCellGrid()
        {
            //Act
            _sut.InitializeGrid();

            // Assert
            Assert.AreEqual(_sut.GetAllCells().Count, 100);

            foreach (var cell in _sut.GetAllCells())
            {
                Assert.AreEqual(cell.Ship, null);
            }
        }

        [TestCase(0,1)]
        [TestCase(5,8)]
        public void PlaceShipOnGridPlacesShipInCorrectCell(int column, int row)
        {
            // Arange
            var coordinate = new Coordinate { Column = column, Row = row };
            var ship = new Destroyer();
            _sut.InitializeGrid();

            // Act
            _sut.PlaceShipOnGrid(ship, coordinate);
            var shipCell = _sut.GetCell(coordinate);

            // Assert
            Assert.AreEqual(ShipType.Destroyer, shipCell.Ship.ShipType);
        }

        [Test]
        public void CheckIfValidLocationForShipReturnsFalseIfInvalidLocation()
        {
            // Arrange
            var coordinate = new Coordinate { Column = 11, Row = 20 };
            _sut.InitializeGrid();

            // Act
            var result = _sut.CheckIfValidLocationForShip(coordinate);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CheckIfValidLocationForShipReturnsTrueIfValidLocation()
        {
            // Arrange
            var coordinate = new Coordinate { Column = 0, Row = 0 };
            _sut.InitializeGrid();

            // Act
            var result = _sut.CheckIfValidLocationForShip(coordinate);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}

