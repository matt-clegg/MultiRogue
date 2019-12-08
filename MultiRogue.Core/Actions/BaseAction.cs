using MultiRogue.Core.Turns;

namespace MultiRogue.Core.Actions
{
    public abstract class BaseAction
    {
        public abstract ActionResult Perform(ITurnable turnable, TurnResult result);

        protected virtual ActionResult Fail()
        {
            return ActionResult.Failure;
        }

        protected virtual ActionResult Succeed()
        {
            return ActionResult.Success;
        }

        protected virtual ActionResult Alternative(BaseAction action)
        {
            return new ActionResult(ActionResultState.Running, action);
        }
    }
}
