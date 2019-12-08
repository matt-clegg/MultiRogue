using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MultiRogue.Core.Input
{
    public static class Controls
    {
        public static readonly Control North = new Control().Bind(Keys.Up).Bind(Keys.NumPad8).Bind(Keys.W);
        public static readonly Control South = new Control().Bind(Keys.Down).Bind(Keys.NumPad2).Bind(Keys.S);
        public static readonly Control East = new Control().Bind(Keys.Right).Bind(Keys.NumPad6).Bind(Keys.D);
        public static readonly Control West = new Control().Bind(Keys.Left).Bind(Keys.NumPad4).Bind(Keys.A);
    }

    public class Control
    {
        private readonly HashSet<Keys> _keys = new HashSet<Keys>();

        public bool IsPressed(Keys key) => _keys.Contains(key);

        public Control() { }

        public Control Bind(Keys key)
        {
            _keys.Add(key);
            return this;
        }
    }


}
