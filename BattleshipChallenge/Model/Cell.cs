using BattleshipChallenge.Model.Abstract;
using BattleshipChallenge.Model.Enums;
using BattleshipChallenge.Model.Interfaces;

namespace BattleshipChallenge.Model
{
    public class Cell : ICell
    {
        private string? identifier;
        public string Identifier
        {
            get
            {
                if (!string.IsNullOrEmpty(identifier)) return identifier;
                identifier = $"{CharNumber[YCoordinate + 1]}{XCoordinate + 1}";
                return identifier;
            }
        }
        public bool IsHit { get; set; }
        public bool HasShip { get => Ship != null; }
        internal ushort XCoordinate { get; set; }
        internal ushort YCoordinate { get; set; }
        private Ship? Ship { get; set; }

        private static readonly Dictionary<int, char> CharNumber;

        static Cell()
        {
            CharNumber = new Dictionary<int, char>();
            ushort counter = 1;
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                CharNumber.Add(counter++, letter);
            }
        }

        public Cell(ushort xCoordinate, ushort yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public void AddShip(Ship ship)
        {
            Ship = ship;
        }

        public AttackOutcome Hit()
        {
            IsHit = true;
            if (Ship != null)
            {
                Ship.ReceiveDamage();
                if (Ship.IsSinking) return AttackOutcome.Sink;
                return AttackOutcome.Hit;
            }
            return AttackOutcome.Miss;
        }
    }
}
