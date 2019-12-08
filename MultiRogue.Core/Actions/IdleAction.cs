using MultiRogue.Core.Turns;

namespace MultiRogue.Core.Actions
{
    public class IdleAction : BaseAction
    {

        public override ActionResult Perform(ITurnable turnable, TurnResult result)
        {
            return ActionResult.Success;
        }
    }
}
