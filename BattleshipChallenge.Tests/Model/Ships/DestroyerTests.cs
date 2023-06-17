using BattleshipChallenge.Model.Ships;

namespace BattleshipChallenge.Tests.Model.Ships
{
    public class DestroyerTests
    {
        [Test]
        public void Destroyer_Size_Equals_Four()
        {
            var destroyer = new Destroyer();
            Assert.That(destroyer.Size, Is.EqualTo(4));
        }

        [Test]
        public void Destroyer_Sunk_After_Four_Shots()
        {
            var destroyer = new Destroyer();
            for (int i = 0; i < 4; i++)
            {
                destroyer.ReceiveDamage();
            }
            Assert.That(destroyer.IsSinking);
        }

        [Test]
        public void Destroyer_Not_Sunk_After_Three_Shots()
        {
            var destroyer = new Destroyer();
            for (int i = 0; i < 3; i++)
            {
                destroyer.ReceiveDamage();
            }
            Assert.That(!destroyer.IsSinking);
        }
    }
}
