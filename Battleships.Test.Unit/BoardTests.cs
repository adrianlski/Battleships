using Battleships.Interfaces;
using Battleships.Services;
using Battleships.Ships;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Battleships.Test.Unit
{
    [TestFixture]
    public class BoardTests
    {
        private IBoardService _sut;
        private Mock<IGridService> _cellGridMock;
        private Mock<List<Ship>> _ships;
            
        [SetUp]
        public void SetUp()
        {
            _cellGridMock = new Mock<IGridService>();
            _ships = new Mock<List<Ship>>();
            _sut = new BoardService(_cellGridMock.Object, _ships.Object);
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