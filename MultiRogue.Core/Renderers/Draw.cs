using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Toolbox.Graphics;

namespace MultiRogue.Core.Renderers
{
    public static class Draw
    {
        public static SpriteBatch Batch { get; set; }

        public static void Sprite(Sprite sprite, float x, float y, Color color)
        {
            Batch.Draw(sprite.Texture, new Vector2(x, y), sprite.Bounds, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        public static void Initialize(SpriteBatch batch)
        {
            Batch = batch;
        }
    }
}
