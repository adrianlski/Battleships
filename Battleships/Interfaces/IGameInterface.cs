using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Interfaces
{
    public interface IGameInterface
    {
        string GetUserInput();
        void OutputResult(string result);
        void OutputError(string message);
        void OutputEndGame(string message);
        void OutputBoard(List<Cell> board);
    }
}
