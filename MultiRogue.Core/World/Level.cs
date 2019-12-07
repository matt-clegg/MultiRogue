using MultiRogue.Core.Entities.Creatures;
using System;
using System.Collections.Generic;
using System.Text;
using Toolbox;

namespace MultiRogue.Core.World
{
    public class Level 
    {
        private readonly Array2D<byte> _tiles;

        private readonly List<Creature> _creatures = new List<Creature>();

        public IReadOnlyCollection<Creature> Creatures => _creatures;

        public int Width => _tiles.Width;
        public int Height => _tiles.Height;

        public Level(Array2D<byte> tiles)
        {
            _tiles = tiles;
        }

        public void Update()
        {
            foreach (Creature creature in Creatures)
            {
                if (!creature.ShouldRemove)
                {
                    creature.Update();
                }
            }

            _creatures.RemoveAll(c => c.ShouldRemove);
        }

        public void Add(Creature creature, int x, int y)
        {
            creature.X = x;
            creature.Y = y;
            creature.Init(this);
            _creatures.Add(creature);
        }

        public Creature GetCreature(int x, int y)
        {
            if(!_tiles.InBounds(x, y))
            {
                return null;
            }

            foreach (Creature creature in Creatures)
            {
                if(creature.X == x && creature.Y == y)
                {
                    return creature;
                }
            }

            return null;
        }
    }
}
