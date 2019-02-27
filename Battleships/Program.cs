using System;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
           var game = new Game(new Board(new CellGrid()), new CellValidator());

            game.Start();
        }
    }
}
