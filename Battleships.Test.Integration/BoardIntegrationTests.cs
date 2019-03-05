using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Services;
using Battleships.Ships;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Battleships.Domain;
using Battleships.Models;
using NUnit.Framework.Interfaces;

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

            var grid = _grid.GetAllCells();

            // Assert
            var destroyersOnGridLength = GetShipCount(grid, ShipType.Destroyer);
            var destroyersInListLength = GetShipLength(ShipType.Destroyer) * NUMBER_OF_DESTROYERS_ON_BOARD;
            Assert.AreEqual(destroyersInListLength, destroyersOnGridLength);
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
