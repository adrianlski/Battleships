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
            var destroyersOnGridLength = grid.Where(x => x.Ship.ShipType == ShipType.Destroyer).Count();
            var destroyersInListLength = _ships.Where(x => x.ShipType == ShipType.Destroyer).FirstOrDefault().Length * 2; // two destroyers so need to multiply length by two
            Assert.AreEqual(destroyersOnGridLength, destroyersInListLength);

            var battleshipsOnGridLength = grid.Where(x => x.Ship.ShipType == ShipType.Battleship).Count();
            var battleshipsInListLength = _ships.Where(x => x.ShipType == ShipType.Battleship).FirstOrDefault().Length;
            Assert.AreEqual(battleshipsOnGridLength, battleshipsInListLength);
        }
    }
}
