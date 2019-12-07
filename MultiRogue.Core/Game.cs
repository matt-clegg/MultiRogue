using MultiRogue.Core.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiRogue.Core
{
    public class Game
    {
        public Scene Scene { get; set; }

        public Game()
        {
            Scene = new TestScene(this);
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
