using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipChallenge.Model.Ships;

namespace BattleshipChallenge.Tests.Model.Ships
{
    public class BattleshipTests
    {
        [Test]
        public void Battleship_Size_Equals_Five()
        {
            var Battleship = new Battleship();
            Assert.That(Battleship.Size, Is.EqualTo(5));
        }

        [Test]
        public void Battleship_Sunk_After_Five_Shots()
        {
            var battleship = new Battleship();
            for (int i = 0; i < 5; i++)
            {
                battleship.ReceiveDamage();
            }
            Assert.That(battleship.IsSinking);
        }

        [Test]
        public void Battleship_Not_Sunk_After_Four_Shots()
        {
            var battleship = new Battleship();
            for (int i = 0; i < 4; i++)
            {
                battleship.ReceiveDamage();
            }
            Assert.That(!battleship.IsSinking);
        }
    }
}
