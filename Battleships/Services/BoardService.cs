using System;
using System.Collections.Generic;
using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Ships;

namespace Battleships.Services
{
    public class BoardService : IBoardService
    {
        private IGridService _gridService;
        private readonly List<Ship> _ships;
        private readonly Random _random;

        public BoardService(IGridService gridService)
        {
            _gridService = gridService;
            _ships = GetShips();
            _random = new Random();
        }

        public void InitializeBoard()
        {
            _gridService.InitializeGrid();

            foreach (var ship in _ships)
            {
                PlaceShip(ship);
            }
        }

        private void PlaceShip(Ship ship)
        {
            do
            {
                var column = _random.Next(0, 9);
                var row = _random.Next(0, 9);
                var orientation = _random.Next(0, 1);

                if (CanPlaceShipOnGrid(ship, column, row, orientation))
                {
                    PlaceShipOnGrid(ship, column, row, orientation);
                    break;
                }

            } while (false);
        }

        private bool CanPlaceShipOnGrid(Ship ship, int column, int row, int orientation)
        {
            if (orientation == 0)
            {
                for (var i = 0; i < ship.Length; i++)
                {
                    
                    if (_gridService.AreCellNeighboursEmpty(column + i, row))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void PlaceShipOnGrid(Ship ship, int column, int row, int orientation)
        {
            _gridService.PlaceShipOnGrid();
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

        public bool AllShipsSunk()
        {
            throw new NotImplementedException();
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