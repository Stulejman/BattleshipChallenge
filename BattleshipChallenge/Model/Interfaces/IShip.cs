namespace BattleshipChallenge.Model.Interfaces
{
    internal interface IShip
    {
        public bool IsSinking { get;}
        public void ReceiveDamage();
    }
}
