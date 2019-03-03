using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface ICoordinateParser
    {
        Coordinate ParseInput(string input);
    }
}