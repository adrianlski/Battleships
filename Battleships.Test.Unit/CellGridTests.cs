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
            // Assert
            Assert.AreEqual(_sut.Cells.Count, 100);
            foreach (var cell in _sut.Cells)
            {
                Assert.AreEqual(cell.Ship, ShipType.Empty);
            }
        }
    }
}

