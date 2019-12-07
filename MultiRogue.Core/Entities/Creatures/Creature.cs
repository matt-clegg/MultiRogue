using MultiRogue.Core.Actions;
using MultiRogue.Core.Ai;
using MultiRogue.Core.Turns;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiRogue.Core.Entities.Creatures
{
    public class Creature : Entity, ITurnable
    {
        private readonly Energy _energy = new Energy();

        public CreatureAi Ai { get; set; }

        public int Speed { get; set; }

        public bool CanTakeTurn()
        {
            return !ShouldRemove && _energy.CanTakeTurn;
        }

        public virtual bool IsWaitingForInput()
        {
            return false;
        }

        public bool GainEnergy()
        {
            return _energy.Gain(Speed);
        }

        public void FinishTurn()
        {
            if (ShouldRemove)
            {
                return;
            }

            _energy.Spend();
        }

        public BaseAction GetAction()
        {
            return OnGetAction();
        }

        protected virtual BaseAction OnGetAction()
        {
            return Ai.DecideNextAction();
        }
    }
}
