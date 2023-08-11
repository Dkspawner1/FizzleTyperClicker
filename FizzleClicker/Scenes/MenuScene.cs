using FizzleClicker.Core;
using FizzleClicker.Managers;


namespace FizzleClicker.Scenes
{
    internal class MenuScene : FizzleComponent
    {
        private const int NUM_BTNS = 3;
        private static Texture2D[] buttons = new Texture2D[NUM_BTNS];
        private Rectangle[] buttonRects = new Rectangle[buttons.Length];
        public override void LoadContent(ContentManager Content)
        {
            const int START_X = 5, START_Y = 75, INCREMENT_Y = 125;
            for (int i = 0; i < NUM_BTNS; i++)
            {
                buttons[i] = Content.Load<Texture2D>($"sprites/button{i + 1}");
                buttonRects[i] = new Rectangle(START_X, START_Y + (INCREMENT_Y * i), buttons[i].Width, buttons[i].Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.MouseLeftClicked && InputManager.MouseRect.Intersects(buttonRects[0]))
            {
                Data.CurrentState = Data.GameStates.Game;
            }
            else if (InputManager.MouseLeftClicked && InputManager.MouseRect.Intersects(buttonRects[1]))
            {
                Data.CurrentState = Data.GameStates.Settings;

            }
            else if (InputManager.MouseLeftClicked && InputManager.MouseRect.Intersects(buttonRects[2]))
            {
                Data.Exit = true;
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            for (int i = 0; i < buttons.Length; i++)
            {
                spriteBatch.Draw(buttons[i], buttonRects[i], Color.White);
                if (InputManager.MouseRect.Intersects(buttonRects[i]))
                    spriteBatch.Draw(buttons[i], buttonRects[i], Color.Gray);

            }
            spriteBatch.End();
        }
    }
}
