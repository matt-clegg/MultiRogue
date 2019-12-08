using Microsoft.Xna.Framework.Input;
using MultiRogue.Core.Actions;
using MultiRogue.Core.Input;
using Toolbox.Graphics;

namespace MultiRogue.Core.Entities.Creatures
{
    public class Player : Creature
    {
        private BaseAction _nextAction;

        public Player(Sprite sprite) : base(sprite)
        {
            Speed = Energy.NormalSpeed;
        }

        public override bool IsWaitingForInput() => _nextAction == null;

        public void Input(Keys key)
        {
            if (Controls.North.IsPressed(key)) SetNextAction(new MoveAction(0, -1));
            else if (Controls.South.IsPressed(key)) SetNextAction(new MoveAction(0, 1));
            else if (Controls.East.IsPressed(key)) SetNextAction(new MoveAction(1, 0));
            else if (Controls.West.IsPressed(key)) SetNextAction(new MoveAction(-1, 0));
        }

        protected override BaseAction OnGetAction()
        {
            BaseAction action = _nextAction;
            _nextAction = null;
            return action;
        }

        private void SetNextAction(BaseAction action)
        {
            _nextAction = action;
        }
    }
}
