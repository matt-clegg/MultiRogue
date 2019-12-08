using MultiRogue.Core.Entities.Creatures;
using MultiRogue.Core.Events;
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

        public override ActionResult Perform(ITurnable turnable, TurnResult result)
        {
            Creature creature = turnable as Creature;

            int newX = creature.X + _x;
            int newY = creature.Y + _y;

            Creature other = creature.Level.GetCreature(newX, newY);

            if(other != null)
            {
                return ActionResult.Failure;
            }

            if (creature.Level.GetTile(newX, newY).IsSolid)
            {
                return ActionResult.Failure;
            }

            creature.X += _x;
            creature.Y += _y;
            result.AddEvent(new MoveEvent(creature, _x, _y));

            return ActionResult.Success;
        }

    }
}
