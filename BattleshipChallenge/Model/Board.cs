using BattleshipChallenge.Model.Enums;
using BattleshipChallenge.Model.Exceptions;
using BattleshipChallenge.Model.Interfaces;

namespace BattleshipChallenge.Model
{
    public class Board : IBoard
    {
        public List<Cell> Cells { get; init; }

        public ushort xSize { get; init; }
        public ushort ySize { get; init; }

        public Board(ushort xSize, ushort ySize)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            Cells = new List<Cell>();
        }

        public AttackOutcome Attack(string cellName)
        {
            var cellToAttack = Cells.Where(x => x.Identifier == cellName).FirstOrDefault();
            if (cellToAttack != null)
            {
                return cellToAttack.Hit();
            }
            else
            {
                throw new WrongCellNameException(cellName);
            }
        }
    }
}
