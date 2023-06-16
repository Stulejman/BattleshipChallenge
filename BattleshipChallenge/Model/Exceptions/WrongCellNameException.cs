namespace BattleshipChallenge.Model.Exceptions
{
    public class WrongCellNameException : Exception
    {
        public WrongCellNameException()
        {
        }

        public WrongCellNameException(string? message) : base(message)
        {
        }
    }
}