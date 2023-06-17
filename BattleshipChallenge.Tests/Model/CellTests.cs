using BattleshipChallenge.Model.Abstract;
using BattleshipChallenge.Model;

namespace BattleshipChallenge.Tests.Model
{
    public class CellTests
    {
        private const ushort xCoord = 5, yCoord = 10;

        [Test]
        public void Cell_Is_Hit_When_Hit()
        {
            var cell = new Cell(xCoord, yCoord);

            cell.Hit();

            Assert.That(cell.IsHit);
        }

        [Test]
        public void Cell_Has_XYCoordinate_Valid()
        {
            var cell = new Cell(xCoord, yCoord);

            Assert.That(cell.XCoordinate, Is.EqualTo(xCoord));
            Assert.That(cell.YCoordinate, Is.EqualTo(yCoord));
        }

        [Test]
        public void Cell_Has_No_Ship_When_Empty()
        {
            var cell = new Cell(0, 0);

            Assert.That(!cell.HasShip);
        }

        [Test]
        public void Cell_Has_Ship_When_Not_Empty()
        {
            var cell = new Cell(0, 0);

            cell.AddShip(new TestShip());

            Assert.That(cell.HasShip);
        }

        [Test]
        public void Cell_Has_Valid_Identifier()
        {
            char startChar = 'A';
            for (ushort x = 0; x < 10; x++)
            {
                for (ushort y = 0; y < 10; y++)
                {
                    var cell = new Cell(x, y);
                    Assert.That(cell.Identifier, Is.EqualTo($"{(char)(startChar + y)}{x + 1}"));
                }
            }
        }

        private class TestShip : Ship
        {
            public TestShip() : base(1) { }
        }
    }
}
