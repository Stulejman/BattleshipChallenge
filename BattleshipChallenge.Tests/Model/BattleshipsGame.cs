using BattleshipChallenge.Model.Interfaces;
using BattleshipChallenge.Model;
using Moq;
using BattleshipChallenge.Model.Enums;

namespace BattleshipChallenge.Tests.Model
{
    public class BattleshipsGameTests
    {

        private const AttackOutcome boardAttackOutcome = AttackOutcome.Hit;

        private BattleshipsGame battleshipsGame;

        [SetUp]
        public void Initialize()
        {
            var boardPrinterMock = new Mock<IBoardPrinter>();
            boardPrinterMock.Setup(m => m.Print(It.IsAny<IBoard>()));

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(m=>m.Attack(It.IsAny<string>())).Returns(boardAttackOutcome);

            var boardFactoryMock = new Mock<IBoardFactory>();
            boardFactoryMock.Setup(m => m.CreateBoard()).Returns(boardMock.Object);

            battleshipsGame = new BattleshipsGame(boardFactoryMock.Object, boardPrinterMock.Object);
        }

        [Test]
        public void BattleshipGame_PlayTurn_Returns_Valid_AttackOutcome()
        {
            var result = battleshipsGame.PlayTurn("A1");

            Assert.That(result, Is.EqualTo(boardAttackOutcome));
        }

        [Test]
        public void BattleshipGame_PlayTurn_NullArgument_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { battleshipsGame.PlayTurn(null); });
        }

        [Test]
        public void BattleshipGame_PlayTurn_EmptyString_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => { battleshipsGame.PlayTurn(string.Empty); });
        }
    }
}
