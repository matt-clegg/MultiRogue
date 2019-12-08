using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Toolbox.Graphics
{
    public class Spritesheet : GameTexture
    {
        public Spritesheet(string name, Texture2D texture) : base(name, texture)
        {
        }

        public Sprite CutSprite(int x, int y, int width, int height, string name)
        {
            // TODO: INDEX TILES ON 8x8 GRID!!!
            var bounds = new Rectangle(x * width, y * height, width, height);
            return new Sprite(name, Texture, bounds);
        }
    }
}
