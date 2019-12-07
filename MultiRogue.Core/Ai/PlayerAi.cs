using MultiRogue.Core.Actions;
using MultiRogue.Core.Entities.Creatures;
using System;

namespace MultiRogue.Core.Ai
{
    public class PlayerAi : CreatureAi
    {
        public PlayerAi(Player player) : base(player)
        {
        }

        public override BaseAction DecideNextAction()
        {
            throw new NotImplementedException();
        }
    }
}
