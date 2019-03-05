using Battleships.Interfaces;
using Battleships.Services;
using Battleships.Ships;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Battleships.Domain;

namespace Battleships.Test.Unit
{
    [TestFixture]
    public class BoardTests
    {
        private IBoard _sut;
        private Mock<IGrid> _cellGridMock;
        private Mock<IRandomiser> _randomiserMock;
        private Mock<List<Ship>> _ships;
            
        [SetUp]
        public void SetUp()
        {
            _cellGridMock = new Mock<IGrid>();
            _randomiserMock = new Mock<IRandomiser>();
            _ships = new Mock<List<Ship>>();
            _sut = new Board(_cellGridMock.Object, _randomiserMock.Object,_ships.Object);
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