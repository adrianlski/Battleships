using System;
using Battleships.Enums;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Battleships.Test.Unit
{
    [TestFixture]
    public class CellGridTests
    {
        private CellGrid _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CellGrid();
        }

        [Test]
        public void InitializeGridCreatesCellGrid()
        {
            // Assert
            Assert.AreEqual(_sut.Cells.Count, 100);
            foreach (var cell in _sut.Cells)
            {
                Assert.AreEqual(cell.CellStatus, CellStatus.Empty);
                Assert.AreEqual(cell.ShipType, ShipType.None);
            }
        }
    }
}

