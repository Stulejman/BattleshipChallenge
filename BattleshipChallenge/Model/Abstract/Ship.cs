using BattleshipChallenge.Model.Interfaces;

namespace BattleshipChallenge.Model.Abstract
{
    public abstract class Ship : IShip
    {
        public bool IsSinking { get { return HitCount >= Size; } }
        internal ushort Size { get; init; }
        private ushort HitCount { get; set; }

        public Ship(ushort size)
        {
            Size = size;
        }

        public void ReceiveDamage()
        {
            HitCount++;
        }
    }
}
