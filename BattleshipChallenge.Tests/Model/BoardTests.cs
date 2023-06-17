using BattleshipChallenge.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BattleshipChallenge.Model;
using BattleshipChallenge.Model.Exceptions;
using BattleshipChallenge.Model.Enums;

namespace BattleshipChallenge.Tests.Model
{
    public class BoardTests
    {
        private const ushort xSize = 2, ySize = 1;

        Board board;

        [SetUp]
        public void Initialize()
        {
            board = new Board(xSize, ySize)
            {
                Cells = new List<Cell>()
                {
                    new Cell(0, 0),
                    new Cell(0, 1),
                }
            };
        }

        [Test]
        public void BoardPlane_Initialize_Dimensions_Valid()
        {
            Assert.That(board.xSize, Is.EqualTo(xSize));
            Assert.That(board.ySize, Is.EqualTo(ySize));
        }

        [Test]
        public void Board_Attack_Returns_Valid_AttackOutcome()
        {
            var testShip = new TestShip();
            board.Cells[0].AddShip(testShip);
            board.Cells[1].AddShip(testShip);
            var cellA1 = "A1";
            var cellB1 = "B1";

            var resultHit = board.Attack(cellA1);
            var resultSink = board.Attack(cellB1);
            var resultMiss = board.Attack(cellB1);

            Assert.That(resultHit, Is.EqualTo(AttackOutcome.Hit));
            Assert.That(resultSink, Is.EqualTo(AttackOutcome.Sink));
            Assert.That(resultMiss, Is.EqualTo(AttackOutcome.Miss));
        }

        [Test]
        public void Board_Attack_Wrong_Cell_Name_Throws_WrongCellNameException()
        {
            var wrongCellName = "F2";
            var ex = Assert.Throws<WrongCellNameException>(() => { board.Attack(wrongCellName); });
            Assert.That(ex.Message,Is.EqualTo(wrongCellName));
        }

        private class TestShip : Ship
        {
            public TestShip() : base(2) { }
        }
    }
}
