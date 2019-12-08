using MultiRogue.Core.Entities.Creatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiRogue.Core.Events
{
    public class MoveEvent : GameEvent
    {
        private readonly Creature _creature;
        private int _dx;
        private int _dy;

        public MoveEvent(Creature creature, int dx, int dy)
        {
            _creature = creature;
            _dx = -(dx * 16);
            _dy = -(dy * 16);
        }

        public override bool Process()
        {
            if(_dx != 0)
            {
                _dx = _dx < 0 ? _dx + 2 : _dx - 2;
            }

            if(_dy != 0)
            {
                _dy = _dy < 0 ? _dy + 2 : _dy - 2;
            }

            _creature.RenderX = _dx;
            _creature.RenderY = _dy;

            return _dx == 0 && _dy == 0;
        }
    }
}

