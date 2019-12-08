using Microsoft.Xna.Framework;
using MultiRogue.Core.Entities.Creatures;
using MultiRogue.Core.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiRogue.Core.Renderers
{
    public class LevelRenderer : Renderer
    {
        private readonly Level _level;

        public LevelRenderer(Level level)
        {
            _level = level;
        }

        protected override void DoRender()
        {
            for(int y = 0; y < _level.Height; y++)
            {
                for(int x = 0; x < _level.Width; x++)
                {
                    Tile tile = _level.GetTile(x, y);
                    Draw.Sprite(tile.Sprite, x * 16, y * 16, Color.White);
                }
            }

            foreach (Creature creature in _level.Creatures)
            {
                Draw.Sprite(creature.Sprite, (creature.X * 16) + creature.RenderX, (creature.Y * 16) + creature.RenderY, Color.White);
            }
        }
    }
}
