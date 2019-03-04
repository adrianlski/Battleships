using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Services;
using Battleships.Ships;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Test.Integration
{
    [TestFixture]
    public class BoardIntegrationTests
    {
        private IGridService _gridService;
        private List<Ship> _ships;
        private IBoardService _sut;

        [SetUp]
        public void SetUp()
        {
            _gridService = new GridService();
            _ships = new List<Ship>
            {
                new Battleship(),
                new Destroyer(),
                new Destroyer()
            };

            _sut = new BoardService(_gridService, _ships);
        }

        [Test]
        public void InitializeBoardPlacesAllShipsOnBoard()
        {
            // Act
            _sut.InitializeBoard();
            var grid = _gridService.GetAllCells();

            // Assert
            var destroyersOnGridLength = grid.Count(x => x.Ship.ShipType == ShipType.Destroyer);
            var destroyersInListLength = _ships.FirstOrDefault(x => x.ShipType == ShipType.Destroyer).Length * 2; // two destroyers so need to multiply length by two
            Assert.AreEqual(destroyersOnGridLength, destroyersInListLength);

            var battleshipsOnGridLength = grid.Count(x => x.Ship.ShipType == ShipType.Battleship);
            var battleshipsInListLength = _ships.FirstOrDefault(x => x.ShipType == ShipType.Battleship).Length;
            Assert.AreEqual(battleshipsOnGridLength, battleshipsInListLength);
        }
    }
}
