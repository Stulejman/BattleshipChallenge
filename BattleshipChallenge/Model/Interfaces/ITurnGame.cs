using BattleshipChallenge.Model.Enums;

namespace BattleshipChallenge.Model.Interfaces
{
    internal interface ITurnGame
    {
        public bool InProgress { get; }
        public void Start();
        public AttackOutcome PlayTurn(string cellName);
    }
}
