using Battleships.Services;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
           var game = new Game(new BoardService(new GridService(), new CellValidator()), new CellValidator(), new GameInterface());

            game.Start();
        }
    }
}
