using Microsoft.Xna.Framework.Input;
using MultiRogue.Core.Ai;
using MultiRogue.Core.Entities.Creatures;
using MultiRogue.Core.Renderers;
using MultiRogue.Core.Turns;
using MultiRogue.Core.World;
using Toolbox.Graphics;
using Toolbox.Rng;

namespace MultiRogue.Core.Scenes
{
    public class TestScene : Scene
    {
        private readonly Level _level;
        private readonly Player _player;

        public TestScene(Game game) : base(game)
        {
            _level = game.Level;

            Sprite playerSprite = Engine.Assets.GetAsset<Sprite>("player");
            _player = new Player(playerSprite);
            new PlayerAi(_player);
            _level.Add(_player, 5, 5);

            IRandom random = new DotNetRandom();

            for (int i = 0; i < 10; i++)
            {
                Sprite monsterSprite = Engine.Assets.GetAsset<Sprite>("monster");
                Monster monster = new Monster(monsterSprite);
                new MonsterAi(monster, random);

                _level.Add(monster, random.Next(2, 10), random.Next(2, 10));
            }


            Add(new LevelRenderer(_level));
        }

        public override void Input(Keys key)
        {
            _player.Input(key);
        }

        public override void Update()
        {
            _level.Update();
        }
    }
}
