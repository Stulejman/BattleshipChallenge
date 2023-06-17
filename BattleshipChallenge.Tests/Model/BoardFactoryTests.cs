using BattleshipChallenge.Model;
using BattleshipChallenge.Model.Interfaces;
using BattleshipChallenge.Model.Ships;

namespace BattleshipChallenge.Tests.Model
{
    public class BoardFactoryTests
    {
        private const ushort xSize = 10, ySize = 10;

        IBoard board;
        
        [SetUp]
        public void Initialize()
        {
            board = new BoardFactory().CreateBoard();
        }

        [Test]
        public void BoardFactory_CreateBoard_ValidDimensions()
        {
            Assert.That(board.xSize, Is.EqualTo(xSize));
            Assert.That(board.xSize, Is.EqualTo(ySize));
        }

        [Test]
        public void BoardFactory_CreateBoard_Valid_Cells_Amount()
        {
            Assert.That(board.Cells.Count, Is.EqualTo(xSize * ySize));
        }

        [Test]
        public void BoardFactory_CreateBoard_Valid_Ships_Count()
        {
            var destroyer = new Destroyer();
            var battleship = new Battleship();
            
            Assert.That(board.Cells.Count(x=>x.HasShip), Is.EqualTo(2* destroyer.Size + battleship.Size));
        }
    }
}
