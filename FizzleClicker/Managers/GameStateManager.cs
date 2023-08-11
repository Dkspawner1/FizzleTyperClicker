using FizzleClicker.Core;
using FizzleClicker.Scenes;

namespace FizzleClicker.Managers
{
    internal class GameStateManager : FizzleComponent
    {
        private GameScene gs;
        private MenuScene ms;
        public override void LoadContent(ContentManager Content)
        {
            ms = new MenuScene();
            ms.LoadContent(Content);    

            gs = new GameScene();
            gs.LoadContent(Content);
        }

        public override void Update(GameTime gameTime)
        {
            InputManager.UpdateMouse();
            InputManager.UpdateKeyboard();

            switch (Data.CurrentState)
            {
                case Data.GameStates.Menu:
                    ms.Update(gameTime);
                    break;
                case Data.GameStates.Game:
                    gs.Update(gameTime);
                    break;
                case Data.GameStates.Settings:
                    break;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.GameStates.Menu:
                    ms.Draw(spriteBatch);
                    break;
                case Data.GameStates.Game:
                    gs.Draw(spriteBatch);   
                    break;
                case Data.GameStates.Settings:
                    break;
            }
        }

    }
}
