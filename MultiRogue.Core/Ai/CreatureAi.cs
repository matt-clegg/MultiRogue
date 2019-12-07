using MultiRogue.Core.Actions;
using MultiRogue.Core.Entities.Creatures;

namespace MultiRogue.Core.Ai
{
    public abstract class CreatureAi
    {
        protected Creature Creature { get; }

        protected CreatureAi(Creature creature)
        {
            Creature = creature;
            Creature.Ai = this;
        }

        public abstract BaseAction DecideNextAction();
    }
}
