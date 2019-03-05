using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Enums;
using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Ships;

namespace Battleships.Domain
{
    public class Board : IBoard
    {
        private readonly IGrid _grid;
        private readonly IRandomiser _randomiser;
        private readonly List<Ship> _ships;

        public Board(IGrid grid, IRandomiser randomsier, List<Ship> ships)
        {
            _grid = grid;
            _ships = ships;
            _randomiser = randomsier;
        }

        public void InitializeBoard()
        {
            _grid.InitializeGrid();

            foreach (var ship in _ships)
            {
                PlaceShip(ship);
            }
        }

        public string TakeAShot(Coordinate coordinates)
        {
            var cell = _grid.GetCell(coordinates);

            if (cell.Ship == null)
            {
                if (cell.CellStatus == CellStatus.Untouched)
                {
                    ChangeCellStatus(coordinates, CellStatus.ShotAt);
                }

                return "You missed!";
            }

            if (cell.CellStatus == CellStatus.ShotAt || cell.CellStatus == CellStatus.Hit)
            {
                return "You already hit this target";
            }

            ChangeCellStatus(coordinates, CellStatus.Hit);
            IncreaseShipShotCounter(cell.Ship);

            if (cell.Ship.IsSunk)
            {
                return $"You sunk a {cell.Ship.Name}!";
            }

            return $"You hit a {cell.Ship.Name}!";
        }

        public List<Cell> GetBoard()
        {
            return _grid.GetAllCells();
        }

        public bool AllShipsSunk()
        {
            return _ships.All(x => x.IsSunk);
        }

        private void PlaceShip(Ship ship)
        {
            do
            {
                var coordinates = new Coordinate
                {
                    Column = _randomiser.GetRandomValue(0, 9),
                    Row = _randomiser.GetRandomValue(0, 9)
                };
               
                var orientation = _randomiser.GetRandomValue(0, 2);

                if (CanPlaceShipOnGrid(ship, coordinates, orientation))
                {
                    PlaceShipOnGrid(ship, coordinates, orientation);
                    break;
                }

            } while (true);
        }

        private void IncreaseShipShotCounter(Ship ship)
        {
            ship.HitCount = ++ship.HitCount;
        }

        private void ChangeCellStatus(Coordinate coordinates, CellStatus status)
        {
            _grid.ChangeCellStatus(coordinates, status);
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

                if (!_grid.CheckIfValidLocationForShip(newCoordinates))
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

                _grid.PlaceShipOnGrid(ship, newCoordinates);
            }
        }
    }
}