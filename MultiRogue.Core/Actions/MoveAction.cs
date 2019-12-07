using System;
using System.Collections.Generic;
using System.Text;
using MultiRogue.Core.Turns;

namespace MultiRogue.Core.Actions
{
    public class MoveAction : BaseAction
    {
        private readonly int _x;
        private readonly int _y;

        public MoveAction(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override ActionResult Perform(ITurnable creature)
        {
            return ActionResult.Success;
        }
    }
}
