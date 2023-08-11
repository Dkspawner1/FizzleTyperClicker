namespace FizzleClicker.Core
{
    public abstract class FizzleComponent
    {
        public abstract void LoadContent(ContentManager Content);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
