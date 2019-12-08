using System;
using System.Collections.Generic;
using System.Text;
using Toolbox.Graphics;

namespace MultiRogue.Core.Entities.Creatures
{
    public class Monster : Creature
    {
        public Monster(Sprite sprite) : base(sprite)
        {
            Speed = Energy.MinSpeed;
        }
    }
}
