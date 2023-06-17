using BattleshipChallenge.Model.Abstract;
using BattleshipChallenge.Model.Enums;

namespace BattleshipChallenge.Model.Interfaces
{
    internal interface ICell
    {
        public string Identifier { get; }
        public bool IsHit { get; set; }
        public bool HasShip { get;}
        internal void AddShip(Ship ship);
        internal AttackOutcome Hit();
    }
}
