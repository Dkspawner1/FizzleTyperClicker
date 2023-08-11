using FizzleClicker.Core;
using FizzleClicker.Words;

namespace FizzleClicker.Scenes
{
    internal class GameScene : FizzleComponent
    {
        private Texture2D background;
        private Rectangle backgroundRect;
        private WordManager wordManager;
        public override void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("Textures/background1");
            backgroundRect = new(0, 0, Data.ScreenWidth, Data.ScreenHeight);

            Data.WordFont = Content.Load<SpriteFont>("Fonts/WordFont");

            wordManager = new WordManager();
            wordManager.LoadContent(Content);
            wordManager.PopulateList();
            
        }

        public override void Update(GameTime gameTime)
        {
            wordManager.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(background, backgroundRect, Color.White);
            wordManager.Draw(spriteBatch);
         
            spriteBatch.End();
        }
    }
}
