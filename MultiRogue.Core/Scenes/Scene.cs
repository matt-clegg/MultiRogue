using MultiRogue.Core.Renderers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiRogue.Core.Scenes
{
    public abstract class Scene
    {
        private readonly List<Renderer> _renderers = new List<Renderer>();

        protected Game Game { get; }

        public Scene(Game game)
        {
            Game = game;
        }

        public abstract void Update();

        public virtual void Render()
        {
            if (_renderers.Count == 0)
            {
                throw new InvalidOperationException("Scene has no renderers.");
            }

            foreach (Renderer renderer in _renderers)
            {
                renderer.Render();
            }
        }

        public void Add(Renderer renderer)
        {
            _renderers.Add(renderer);
        }

    }
}
