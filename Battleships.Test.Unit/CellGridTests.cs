using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Services;
using NUnit.Framework;

namespace Battleships.Test.Unit
{
    [TestFixture]
    public class CellGridTests
    {
        private GridService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new GridService();
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
                Assert.AreEqual(cell.Ship.ShipType, ShipType.Empty);
            }
        }
    }
}

