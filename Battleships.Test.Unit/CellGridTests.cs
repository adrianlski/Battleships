using Battleships.Domain;
using Battleships.Enums;
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
    }
}

