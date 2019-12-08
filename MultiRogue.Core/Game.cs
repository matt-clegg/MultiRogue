using Microsoft.Xna.Framework.Input;
using MultiRogue.Core.Entities.Creatures;
using MultiRogue.Core.Scenes;
using MultiRogue.Core.World;
using MultiRogue.Core.World.Generation;
using System;
using System.Collections.Generic;
using System.Text;
using Toolbox.Graphics;
using Toolbox.Rng;

namespace MultiRogue.Core
{
    public class Game
    {
        public Scene Scene { get; set; }

        public Level Level { get; }

        public Game()
        {
            IRandom random = new DotNetRandom();
            Level = new LevelGenerator(32, 32, random).Generate().Build();
           
            Scene = new TestScene(this);
        }

        public void Input(Keys key)
        {
            Scene.Input(key);
        }

        public void Update()
        {
            Scene.Update();
        }

        public void Render()
        {
            Scene.Render();
        }
    }

}
