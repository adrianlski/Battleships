using Battleships.Interfaces;
using Moq;
using NUnit.Framework;

namespace Battleships.Test.Unit
{
    [TestFixture]
    public class BoardTests
    {
        private Board _sut;
        private Mock<ICellGrid> _cellGridMock;
            
        [SetUp]
        public void SetUp()
        {
            _cellGridMock = new Mock<ICellGrid>();
            _sut = new Board(_cellGridMock.Object);
        }

        [Test]
        public void PlaceShipsCallsInitializeGrid()
        {
            //Act
            _sut.PlaceShips();

            //Assert
            _cellGridMock.Verify(x => x.InitializeGrid(), Times.Once);
        }
    }
}