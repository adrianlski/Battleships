using System;
using System.Collections.Generic;
using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Ships;

namespace Battleships
{
    public class Board : IBoard
    {
        private ICellGrid _cellGrid;
        private readonly List<Ship> _ships;

        public Board(ICellGrid cellGrid)
        {
            _cellGrid = cellGrid;
            _ships = GetShips();
        }

        public void PlaceShips()
        {
            var random = new Random();
            foreach (var ship in _ships)
            {
                PlaceShip(ship, random);
            }
        }

        public CellStatus CheckCell()
        {
            throw new NotImplementedException();
        }

        public void ChangeCellStatus()
        {
            throw new NotImplementedException();
        }

        public object TakeAShot(Coordinate coordinates)
        {
            throw new NotImplementedException();
        }

        private void PlaceShip(Ship ship, Random random)
        {
            //do
            //{
            //    var column = random.Next(0, 9);
            //    var row = random.Next(0, 9);
            //    var orientation = random.Next(0, 1);

            //    if (CanPlaceShipOnGrid(ship, column, row, orientation))
            //    {
            //        PlaceShipOnGrid(ship, column, row, orientation);
            //        break;
            //    }

            //} while (false);
        }

        private void PlaceShipOnGrid(ShipType ship, int column, int row, int orientation)
        {
            throw new NotImplementedException();
        }

        private bool CanPlaceShipOnGrid(ShipType ship, int column, int row, int orientation)
        {
            return true;
        }

        private List<Ship> GetShips()
        {
            return new List<Ship>
            {
                new Battleship(),
                new Destroyer(),
                new Destroyer()
            };
        }
    }
}