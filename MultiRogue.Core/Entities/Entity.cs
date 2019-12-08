using MultiRogue.Core.World;
using System;
using System.Collections.Generic;
using System.Text;
using Toolbox.Graphics;

namespace MultiRogue.Core.Entities
{
    public abstract class Entity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public float RenderX { get; set; }
        public float RenderY { get; set; }

        public Level Level { get; private set; }

        public virtual Sprite Sprite { get; }

        public bool ShouldRemove { get; set; }

        public Entity(Sprite sprite)
        {
            Sprite = sprite;
        }

        public void Init(Level level)
        {
            Level = level;
        }

        public virtual void Update()
        {

        }
    }
}
