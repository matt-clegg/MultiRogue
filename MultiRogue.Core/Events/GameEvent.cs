using System;
using System.Collections.Generic;
using System.Text;

namespace MultiRogue.Core.Events
{
    public abstract class GameEvent
    {
        public abstract bool Process();
    }
}
