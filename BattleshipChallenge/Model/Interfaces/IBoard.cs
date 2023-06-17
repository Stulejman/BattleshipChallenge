using BattleshipChallenge.Model.Enums;

namespace BattleshipChallenge.Model.Interfaces
{
    public interface IBoard
    {
        public ushort xSize { get; init; }
        public ushort ySize { get; init; } 

        List<Cell> Cells { get; init; }
        AttackOutcome Attack(string cellName);
    }
}
