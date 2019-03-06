using Battleships.Interfaces;
using Battleships.Services;
using Battleships.Ships;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Battleships.Domain;
using System.Linq;
using System.Linq.Expressions;
using System;
using Battleships.Models;
using Battleships.Enums;

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
            // Act
            _sut.InitializeBoard();

            // Assert
            _cellGridMock.Verify(x => x.InitializeGrid(), Times.Once);
        }

        [Test]
        public void GetBoardCallsGetAllCells()
        {
            // Act
            _sut.InitializeBoard();
            _sut.GetBoard();

            // Assert
            _cellGridMock.Verify(x => x.GetAllCells(), Times.Once);

        }

        [Test]
        public void TakeAShotCallsGetCell()
        {
            // Arrange
            var coordinate = new Coordinate { Column = 0, Row = 0 };
            var cell = GetCell(coordinate, CellStatus.Untouched);
            _cellGridMock.Setup(x => x.GetCell(coordinate)).Returns(cell);


            // Act
            _sut.InitializeBoard();
            _sut.TakeAShot(coordinate);

            // Assert
            _cellGridMock.Verify(x => x.GetCell(coordinate), Times.Once);
        }

        [Test]
        public void TakeAShotReturnsYouMissedWhenCellIsEmpty()
        {
            // Arrange
            var coordinate = new Coordinate { Column = 0, Row = 0 };
            var cell = GetCell(coordinate, CellStatus.Untouched);
            _cellGridMock.Setup(x => x.GetCell(coordinate)).Returns(cell);


            // Act
            _sut.InitializeBoard();
            var result = _sut.TakeAShot(coordinate);

            // Assert
            Assert.AreEqual("You missed!", result);
        }

        [Test]
        public void TakeAShotReturnsYouAlreadyHitTheTargetWhenCellAlreadyHit()
        {
            // Arrange
            var coordinate = new Coordinate { Column = 0, Row = 0 };
            var cell = GetCell(coordinate, CellStatus.ShotAt);
            _cellGridMock.Setup(x => x.GetCell(coordinate)).Returns(cell);


            // Act
            _sut.InitializeBoard();
            var result = _sut.TakeAShot(coordinate);

            // Assert
            Assert.AreEqual("You already hit this target", result);
        }

        [Test]
        public void TakeAShotReturnsYouHitADestroyerWhenDestroyerHit()
        {
            // Arrange
            var coordinate = new Coordinate { Column = 0, Row = 0 };
            var cell = GetCell(coordinate, CellStatus.Untouched, new Destroyer());
            _cellGridMock.Setup(x => x.GetCell(coordinate)).Returns(cell);

            // Act
            _sut.InitializeBoard();
            var result = _sut.TakeAShot(coordinate);

            // Assert
            Assert.AreEqual("You hit a Destroyer!", result);
        }

        [Test]
        public void TakeAShotReturnsYouSunkADestroyerWhenDestroyerHit()
        {
            // Arrange
            var coordinate = new Coordinate { Column = 0, Row = 0 };
            var cell = GetCell(coordinate, CellStatus.Untouched, new Destroyer());
            cell.Ship.HitCount = cell.Ship.Length;
            _cellGridMock.Setup(x => x.GetCell(coordinate)).Returns(cell);

            // Act
            _sut.InitializeBoard();
            var result = _sut.TakeAShot(coordinate);

            // Assert
            Assert.AreEqual("You sunk a Destroyer!", result);
        }

        private Cell GetCell(Coordinate coordinate, CellStatus cellStatus, Ship ship = null)
        {
            return new Cell
            {
                CellStatus = cellStatus,
                Coordinate = coordinate,
                Ship = ship
            }; 
        }
    }
}