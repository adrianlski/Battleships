using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Ships;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Battleships.Domain;
using Battleships.Models;

namespace Battleships.Test.Integration
{
    [TestFixture]
    public class BoardIntegrationTests
    {
        private IGrid _grid;
        private List<Ship> _ships;
        private IRandomiser _randomiser;
        private IBoard _sut;
        private const int NUMBER_OF_DESTROYERS_ON_BOARD  = 2;
        private const int GRID_SIZE = 10;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid();
            _randomiser = new Randomiser();
            _ships = new List<Ship>
            {
                new Battleship(),
                new Destroyer(),
                new Destroyer()
            };

            _sut = new Board(_grid, _randomiser, _ships);
        }

        [Test]
        public void InitializeBoardPlacesAllBattleshipsOnBoard()
        {
            // Arrange
            _sut.InitializeBoard();

            // Act
            var grid = _grid.GetAllCells();

            // Assert
            var battleshipsOnGridLength = GetShipCount(grid, ShipType.Battleship);
            var battleshipsInListLength = GetShipLength(ShipType.Battleship);

            Assert.AreEqual(battleshipsInListLength, battleshipsOnGridLength);
        }

        [Test]
        public void InitializeBoardPlacesAllDestroyersOnBoard()
        {
            // Arrange
            _sut.InitializeBoard();

            // Act
            var grid = _grid.GetAllCells();

            // Assert
            var destroyersOnGridLength = GetShipCount(grid, ShipType.Destroyer);
            var destroyersInListLength = GetShipLength(ShipType.Destroyer) * NUMBER_OF_DESTROYERS_ON_BOARD;
            Assert.AreEqual(destroyersInListLength, destroyersOnGridLength);
        }

        [Test]
        public void TakeAShotChangesEmptyCellStatusToShotAt()
        {
            // Arrange
            _sut.InitializeBoard();
            var emptyCell = _sut.GetBoard().FirstOrDefault(x => x.Ship == null);

            // Act
            _sut.TakeAShot(new Coordinate{Column = emptyCell.Coordinate.Column, Row = emptyCell.Coordinate.Row});
            var cell = _sut.GetBoard().FirstOrDefault(x => x.Coordinate.Column == emptyCell.Coordinate.Column && x.Coordinate.Row == emptyCell.Coordinate.Row);

            // Assert
            Assert.AreEqual(CellStatus.ShotAt, cell.CellStatus);
        }

        [Test]
        public void TakeAShotChangesShipCellStatusToHit()
        {
            // Arrange
            _sut.InitializeBoard();
            var shipCell = _sut.GetBoard().FirstOrDefault(x => x.Ship != null && x.Ship.ShipType == ShipType.Battleship);

            // Act
            _sut.TakeAShot(new Coordinate { Column = shipCell.Coordinate.Column, Row = shipCell.Coordinate.Row });
            var cell = _sut.GetBoard().FirstOrDefault(x => x.Coordinate.Column == shipCell.Coordinate.Column && x.Coordinate.Row == shipCell.Coordinate.Row);

            // Assert
            Assert.AreEqual(CellStatus.Hit, cell.CellStatus);
        }

        [Test]
        public void TakeAShotShootingAllShipCellsDestoryShip()
        {
            // Arrange
            _sut.InitializeBoard();
            var shipCells = _sut.GetBoard().Where(x => x.Ship != null && x.Ship.ShipType == ShipType.Battleship);

            // Act
            foreach (var shipCell in shipCells)
            {
                _sut.TakeAShot(new Coordinate { Column = shipCell.Coordinate.Column, Row = shipCell.Coordinate.Row });
            }

            // Assert
            foreach (var shipCell in shipCells)
            {
                Assert.AreEqual(true, shipCell.Ship.IsSunk);
            }
            
        }

        [Test]
        public void AllShipsSunkReturnsTrueWhenAllShipsDestroyed()
        {
            // Arrange
            _sut.InitializeBoard();

            // Act
            for (var column  = 0; column < GRID_SIZE; column++)
            {
                for (var row = 0; row < GRID_SIZE; row++)
                {
                    _sut.TakeAShot(new Coordinate{Column = column, Row = row});
                }
            }

            // Assert
            Assert.AreEqual(true, _sut.AllShipsSunk());

        }

        private static int GetShipCount(List<Cell> grid, ShipType shipType)
        {
            return grid.Count(x => x.Ship != null && x.Ship.ShipType == shipType);
        }

        private int GetShipLength(ShipType shipType)
        {
            return _ships.FirstOrDefault(x => x.ShipType == shipType).Length;
        }
    }
}
