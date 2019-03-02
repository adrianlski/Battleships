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
        private ICellValidator _cellValidator;
        private readonly List<Ship> _ships;
        private readonly Random _random;

        public BoardService(IGridService gridService, ICellValidator cellValidator)
        {
            _gridService = gridService;
            _cellValidator = cellValidator;
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
                var orientation = _random.Next(0, 2);

                if (CanPlaceShipOnGrid(ship, column, row, orientation))
                {
                    PlaceShipOnGrid(ship, column, row, orientation);
                    break;
                }

            } while (true);
        }

        private bool CanPlaceShipOnGrid(Ship ship, int column, int row, int orientation)
        {
            //for (int i = 0; i < UPPER; i++)
            //{
            //    if ((Orientation) orientation == Orientation.Horizontal)
            //    {
            //        var newCoord = new Coordinate();
            //    }
            //    else
            //    {
            //        var newCoord = new Coordinate();
            //    }

            //    !_gridService.CheckIfValidLocationForShip(column + i, row)
            //}
            

            // put comments to explain
            if (orientation == 0)
            {
                for (var i = 0; i < ship.Length; i++)
                {
                    if (!_gridService.CheckIfValidLocationForShip(column + i, row))
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (var i = 0; i < ship.Length; i++)
                {

                    if (!_gridService.CheckIfValidLocationForShip(column, row + i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void PlaceShipOnGrid(Ship ship, int column, int row, int orientation)
        {
            if (orientation == 0)
            {
                for (var i = 0; i < ship.Length; i++)
                {
                    _gridService.PlaceShipOnGrid(ship, column + i, row);
                }
            } else
            {
                for (var i = 0; i < ship.Length; i++)
                {
                    _gridService.PlaceShipOnGrid(ship, column, row + i);
                }
            }
            
        }

        public object TakeAShot(Coordinate coordinates)
        {
            var status = _gridService.CheckCellStatus(coordinates.Column, coordinates.Row);

            switch (status)
            {
                case ShipStatus.Empty:
                    break;
                case ShipStatus.Hit:
                    break;
                case ShipStatus.Sunk:
                    break;
                default:
                    break;
            }

            return null;
        }

        public bool AllShipsSunk()
        {
            throw new NotImplementedException();
        }

        public List<Cell> GetBoard()
        {
            return _gridService.GetAllCells();
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