
using FizzleClicker.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace FizzleClicker.Core
{
    public class Game1 : Game
    {
        internal static GraphicsDeviceManager graphics;
        private GameStateManager gsm;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Data.ScreenW;
            graphics.PreferredBackBufferHeight = Data.ScreenH;
            graphics.ApplyChanges();

            Window.Title = Data.Title;
            Window.AllowAltF4 = true;
            Window.AllowUserResizing = false;
            gsm = new();
            
            Globals.Content = Content;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = spriteBatch;
            gsm.Init();
        }

        protected override void Update(GameTime gameTime)
        {
            gsm.Update();
            Globals.Update(gameTime);
            if (Data.Exit)
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            gsm.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}