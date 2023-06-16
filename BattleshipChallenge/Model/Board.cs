using BattleshipChallenge.Model.Enums;
using BattleshipChallenge.Model.Exceptions;
using BattleshipChallenge.Model.Interfaces;

namespace BattleshipChallenge.Model
{
    public class Board : IBoard
    {
        public List<Cell> Cells { get; init; }

        public ushort XSize { get; init; }
        public ushort YSize { get; init; }

        public Board(ushort xSize, ushort ySize)
        {
            XSize = xSize;
            YSize = ySize;
            Cells = new List<Cell>();
        }

        public AttackOutcome Attack(string cellName)
        {
            var cellToAttack = Cells.Where(x => x.CellName == cellName).FirstOrDefault();
            if (cellToAttack != null)
            {
                return cellToAttack.GetHit();
            }
            else
            {
                throw new WrongCellNameException(cellName);
            }
        }
    }
}
