using MultiRogue.Core.Entities.Creatures;
using MultiRogue.Core.Events;
using MultiRogue.Core.Turns;
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

        private List<GameEvent> _events = new List<GameEvent>();
        private readonly TurnManager<Creature> _turnManager;
        private TurnResult _turnResult;

        public int Width => _tiles.Width;
        public int Height => _tiles.Height;

        public Level(Array2D<byte> tiles)
        {
            _tiles = tiles;

            _turnManager = new TurnManager<Creature>(_creatures);
        }

        public void Update()
        {
            if (_events.Count == 0)
            {
                _turnResult = _turnManager.Process();
                _events.AddRange(_turnResult.Events);
            }

            if (_events.Count > 0)
            {
                List<GameEvent> toRemove = new List<GameEvent>();
                foreach (GameEvent gameEvent in _events)
                {
                    if (gameEvent.Process())
                    {
                        toRemove.Add(gameEvent);
                    }
                }
                
                foreach(GameEvent removeEvent in toRemove)
                {
                    _events.Remove(removeEvent);
                }
            }
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

        public Tile GetTile(int x, int y)
        {
            return Tile.GetTile(_tiles[x, y]);
        }
    }
}
