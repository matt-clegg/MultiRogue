namespace MultiRogue.Core.Actions
{
    public enum ActionResultState
    {
        Running,
        Success,
        Failure,
    }

    public class ActionResult
    {
        public static readonly ActionResult Success = new ActionResult(ActionResultState.Success);
        public static readonly ActionResult Failure = new ActionResult(ActionResultState.Failure);

        public ActionResultState State { get; }
        public BaseAction Alternative { get; }

        public ActionResult(ActionResultState state, BaseAction alternative = null)
        {
            State = state;
            Alternative = alternative;
        }
    }
}
