using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Toolbox.Graphics
{
    public class Sprite : GameTexture
    {
        public Rectangle Bounds { get; }

        public Sprite(string name, Texture2D texture, Rectangle bounds) : base(name, texture)
        {
            Bounds = bounds;
        }

        public override int Width => Bounds.Width;
        public override int Height => Bounds.Height;
    }
}
