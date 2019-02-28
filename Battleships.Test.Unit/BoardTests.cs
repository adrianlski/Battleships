using Battleships.Interfaces;
using Battleships.Services;
using Moq;
using NUnit.Framework;

namespace Battleships.Test.Unit
{
    [TestFixture]
    public class BoardTests
    {
        private IBoardService _sut;
        private Mock<IGridService> _cellGridMock;
            
        [SetUp]
        public void SetUp()
        {
            _cellGridMock = new Mock<IGridService>();
            _sut = new BoardService(_cellGridMock.Object);
        }

        [Test]
        public void PlaceShipsCallsInitializeGrid()
        {
            //Act
            _sut.InitializeBoard();

            //Assert
            _cellGridMock.Verify(x => x.InitializeGrid(), Times.Once);
        }
    }
}