using System.ComponentModel;

namespace BattleshipChallenge.Model.Enums
{
    public enum AttackOutcome
    {
        [Description("Missed!")]
        Miss,
        [Description("Target Hit!")]
        Hit,
        [Description("Sinking.... Plop!")]
        Sink
    }
}
