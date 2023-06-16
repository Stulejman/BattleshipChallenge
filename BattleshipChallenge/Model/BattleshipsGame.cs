using BattleshipChallenge.Model.Enums;
using BattleshipChallenge.Model.Interfaces;

namespace BattleshipChallenge.Model
{
    public class BattleshipsGame : ITurnGame
    {
        public BattleshipsGame(IBoardFactory boardFactory, IBoardPrinter boardPrinter)
        {
            Board = boardFactory.CreateBoard();
            BoardPrinter = boardPrinter;
        }

        public bool InProgress { get { return Board.Cells.Any(c => c.HasShip && !c.IsHit); } }
        private IBoardPrinter BoardPrinter { get; }
        private IBoard Board { get; init; }

        public AttackOutcome PlayTurn(string cellName)
        {
            if (cellName == null) throw new ArgumentNullException(nameof(cellName));
            if(string.IsNullOrWhiteSpace(cellName)) throw new ArgumentNullException(nameof(cellName));

            AttackOutcome result = Board.Attack(cellName);
            BoardPrinter.Print(Board);
            return result;
        }

        public void Start()
        {
            BoardPrinter.Print(Board);
        }
    }
}
