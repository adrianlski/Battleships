using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface ICellValidator
    {
        bool IsInputValid(string input);
        Coordinate TransformToCoordinate(string input);
    }
}