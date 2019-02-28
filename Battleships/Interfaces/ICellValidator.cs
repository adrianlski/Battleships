using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface ICellValidator
    {
        bool IsInputValid(string input);
        Coordinate ParseInput(string input);
    }
}