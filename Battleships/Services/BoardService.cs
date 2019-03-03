using System;
using System.Collections.Generic;
using System.Linq;
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
                var coordinates = new Coordinate
                {
                    Column = _random.Next(0, 9),
                    Row = _random.Next(0, 9)
                };
               
                var orientation = _random.Next(0, 2);

                if (CanPlaceShipOnGrid(ship, coordinates, orientation))
                {
                    PlaceShipOnGrid(ship, coordinates, orientation);
                    break;
                }

            } while (true);
        }

        public string TakeAShot(Coordinate coordinates)
        {
            var cell = _gridService.GetCell(coordinates);

            if (cell.Ship.ShipType == ShipType.Empty)
            {
                if (cell.CellStatus == CellStatus.Untouched)
                {
                    ChangeCellStatus(coordinates, CellStatus.ShotAt);
                }

                return "You missed!";
            }

            if (cell.Ship.ShipStatus == CellStatus.ShotAt)
            {
                return "You already hit this target";
            }

            ChangeCellStatus(coordinates, CellStatus.Hit);
            IncreaseShipShotCounter(cell.Ship);

            if (cell.Ship.IsSunk)
            {
                return $"You sunk {cell.Ship.Name}";
            }

            return $"You hit a {cell.Ship.Name}!";
            
            

        }

        private void IncreaseShipShotCounter(Ship ship)
        {
            ship.HitCount = ++ship.HitCount;
        }

        private void ChangeCellStatus(Coordinate coordinates, CellStatus status)
        {
            _gridService.ChangeCellStatus(coordinates, status);
        }

        public bool AllShipsSunk()
        {
            return !_ships.Any(x => x.IsSunk == false);
        }

        public List<Cell> GetBoard()
        {
            return _gridService.GetAllCells();
        }

        private bool CanPlaceShipOnGrid(Ship ship, Coordinate coordinates, int orientation)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                Coordinate newCoordinates;
                if ((Orientation)orientation == Orientation.Horizontal)
                {
                    newCoordinates = new Coordinate
                    {
                        Column = coordinates.Column + i,
                        Row = coordinates.Row
                    };
                }
                else
                {
                    newCoordinates = new Coordinate
                    {
                        Column = coordinates.Column,
                        Row = coordinates.Row + i
                    };
                }

                if (!_gridService.CheckIfValidLocationForShip(newCoordinates))
                {
                    return false;
                }
            }

            return true;
        }

        private void PlaceShipOnGrid(Ship ship, Coordinate coordinates, int orientation)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                Coordinate newCoordinates;
                if ((Orientation)orientation == Orientation.Horizontal)
                {
                    newCoordinates = new Coordinate
                    {
                        Column = coordinates.Column + i,
                        Row = coordinates.Row
                    };
                }
                else
                {
                    newCoordinates = new Coordinate
                    {
                        Column = coordinates.Column,
                        Row = coordinates.Row + i
                    };
                }

                _gridService.PlaceShipOnGrid(ship, newCoordinates);
            }
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