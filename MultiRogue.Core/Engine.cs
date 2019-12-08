using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MultiRogue.Core.Data;
using MultiRogue.Core.Renderers;
using Toolbox.Assets;
using Toolbox.Input;

namespace MultiRogue.Core
{
    public class Engine : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Engine Instance { get; private set; }

        public Color ClearColor { get; set; }

        public static AssetStore<string> Assets { get; private set; }

        public static int WindowWidth { get; private set; }
        public static int WindowHeight { get; private set; }
        public static int GameWidth { get; private set; }
        public static int GameHeight { get; private set; }
        public static string Title { get; private set; }

        private RenderTarget2D _renderTarget;
        private Rectangle _renderTargetDestination;

        private readonly DelayedInputHandler _input = new DelayedInputHandler(20);
        private Game _game;

        public Engine(int windowWidth, int windowHeight, int gameWidth, int gameHeight, string title)
        {
            Instance = this;
            Assets = new AssetStore<string>();
            ClearColor = Color.Black;

            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
            GameWidth = gameWidth;
            GameHeight = gameHeight;
            Title = title;

            _graphics = new GraphicsDeviceManager(this)
            {
                SynchronizeWithVerticalRetrace = true,
                PreferMultiSampling = false,
                GraphicsProfile = GraphicsProfile.Reach,
                PreferredBackBufferWidth = WindowWidth,
                PreferredBackBufferHeight = WindowHeight,
                PreferredBackBufferFormat = SurfaceFormat.Color,
                PreferredDepthStencilFormat = DepthFormat.None
            };

            Content.RootDirectory = "Content";

            _input.InputFireEvent += OnInputEvent;

            Window.Title = Title;
            Window.AllowUserResizing = false;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            UpdateView();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Renderers.Draw.Initialize(_spriteBatch);

            DataLoader.Load(Content, Assets);

            _game = new Game();
        }

        private void OnInputEvent(object sender, KeyEventArgs e)
        {
            _game.Input(e.Key);
        }

        protected override void Update(GameTime gameTime)
        {
            _input.Update(Keyboard.GetState());
            _game.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RenderCore();

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_renderTarget, _renderTargetDestination, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }


        private void RenderCore()
        {
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(ClearColor);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _game.Render();
            //Util.Draw.DoRender();
            //Util.Draw.Clear();
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
        }

        private void UpdateView()
        {
            _renderTargetDestination = new Rectangle()
            {
                Width = WindowWidth,
                Height = WindowHeight
            };

            _renderTarget = new RenderTarget2D(GraphicsDevice, GameWidth, GameHeight);
        }
    }
}
