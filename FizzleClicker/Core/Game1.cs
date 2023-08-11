using FizzleClicker.Managers;

namespace FizzleClicker.Core
{
    public class Game1 : Game
    {
        internal static GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private GameStateManager gsm;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.Title = Data.Title;
            graphics.IsFullScreen = Data.IsFullscreen;
            graphics.PreferredBackBufferWidth = Data.ScreenWidth;
            graphics.PreferredBackBufferHeight = Data.ScreenHeight;
            graphics.ApplyChanges();

            gsm = new GameStateManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gsm.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Data.Exit)
                Exit();
            gsm.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gsm.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}