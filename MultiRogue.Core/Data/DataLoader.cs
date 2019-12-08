using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MultiRogue.Core.World;
using System;
using System.Diagnostics;
using Toolbox.Assets;
using Toolbox.Graphics;

namespace MultiRogue.Core.Data
{
    public static class DataLoader
    {
        private static ContentManager Content { get; set; }
        private static AssetStore<string> Assets { get; set; }

        public static void Load(ContentManager content, AssetStore<string> assets)
        {
            Content = content;
            Assets = assets;

            Console.WriteLine("Loading content...");
            var watch = Stopwatch.StartNew();

            LoadSpritesheets();
            LoadSprites();
            LoadTiles();

            watch.Stop();
            Console.WriteLine($"Content loaded in {watch.Elapsed.TotalMilliseconds}ms");
        }

        private static void LoadSpritesheets()
        {
            LoadSpritesheet("tiny_dungeon_world");
            LoadSpritesheet("tiny_dungeon_monsters");
        }

        private static void LoadSprites()
        {
            Spritesheet monsters = Assets.GetAsset<Spritesheet>("tiny_dungeon_monsters");
            Spritesheet world = Assets.GetAsset<Spritesheet>("tiny_dungeon_world");

            LoadSprite(0, 0, "player", monsters);
            LoadSprite(0, 6, "monster", monsters);

            LoadSprite(0, 0, "wall", world);
            LoadSprite(7, 0, "floor", world);
        }

        private static void LoadTiles()
        {
            Sprite wall = Assets.GetAsset<Sprite>("wall");
            Sprite floor = Assets.GetAsset<Sprite>("floor");

            new Tile(0, wall, true);
            new Tile(1, floor, false);
        }

        private static Spritesheet LoadSpritesheet(string name)
        {
            Texture2D texture = Content.Load<Texture2D>(name);
            Spritesheet sheet = new Spritesheet(name, texture);
            Assets.AddAsset(name, sheet);
            return sheet;
        }

        private static Sprite LoadSprite(int x, int y, string name, Spritesheet sheet)
        {
            Sprite sprite = sheet.CutSprite(x, y, 16, 16, name);
            Assets.AddAsset(name, sprite);
            return sprite;
        }
    }
}
