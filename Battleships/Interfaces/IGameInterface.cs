using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Interfaces
{
    public interface IGameInterface
    {
        string GetUserInput();
        void OutputResult(object result);
        void OutputError(string message);
        void OutputInfo(string message);
        void OutputBoard(List<Cell> board);
    }
}
