using BattleshipChallenge.Model.Abstract;
using BattleshipChallenge.Model.Enums;
using BattleshipChallenge.Model.Interfaces;

namespace BattleshipChallenge.Model
{
    public class Cell : ICell
    {
        private string? cellName;
        public string CellName
        {
            get
            {
                if (!string.IsNullOrEmpty(cellName)) return cellName;
                cellName = $"{CharNumber[YCoordinate + 1]}{XCoordinate + 1}";
                return cellName;
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

        public AttackOutcome GetHit()
        {
            IsHit = true;
            if (Ship != null)
            {
                Ship.GetHit();
                if (Ship.IsSinking) return AttackOutcome.Sink;
                return AttackOutcome.Hit;
            }
            return AttackOutcome.Miss;
        }
    }
}
