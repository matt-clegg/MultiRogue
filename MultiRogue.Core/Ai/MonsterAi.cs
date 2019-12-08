using System;
using System.Collections.Generic;
using System.Text;
using MultiRogue.Core.Actions;
using MultiRogue.Core.Entities.Creatures;
using Toolbox.Rng;

namespace MultiRogue.Core.Ai
{
    public class MonsterAi : CreatureAi
    {
        private readonly IRandom _random;

        public MonsterAi(Creature creature, IRandom random) : base(creature)
        {
            _random = random;
        }

        public override BaseAction DecideNextAction()
        {
            int dx = 0;
            int dy = 0;

            if (_random.NextDouble() < 0.5)
            {
                dx = _random.Next(3) - 1;
            }
            else
            {
                dy = _random.Next(3) - 1;
            }
            
            if(dx == 0 && dy == 0)
            {
                return new IdleAction();
            }

            return new MoveAction(dx, dy);
        }
    }
}
