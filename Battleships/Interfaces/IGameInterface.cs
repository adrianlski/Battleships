using Battleships.Models;
using System.Collections.Generic;

namespace Battleships.Interfaces
{
    public interface IGameInterface
    {
        string GetUserInput();
        void OutputInfo(string message);
        void OutputError(string message);
        void OutputEndGame(string message);
        void OutputBoard(List<Cell> board);
    }
}
