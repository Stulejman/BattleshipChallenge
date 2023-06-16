using BattleshipChallenge.Model.Enums;

namespace BattleshipChallenge.Model.Interfaces
{
    public interface IBoard
    {
        public ushort XSize { get; init; }
        public ushort YSize { get; init; } 

        List<Cell> Cells { get; init; }
        AttackOutcome Attack(string cellName);
    }
}
