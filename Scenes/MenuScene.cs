using FizzleClicker.Core;
using FizzleClicker.Managers;
using FizzleClicker.Particle.ParticleCore;
using FizzleClicker.Particle.ParticleEmitters;

namespace FizzleClicker.Scenes
{
    internal class MenuScene
    {
        private static Texture2D[] btns = new Texture2D[3];
        private Rectangle[] btnRects = new Rectangle[btns.Length];
        public void Init()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = Globals.Content.Load<Texture2D>($"textures/btn{i}");
                int START_X = 5, START_Y = Data.ScreenH / 2 - btns[i].Height / 2, INCREMENT_SIZE = 150, SCALE = 4;
                btnRects[i] = new Rectangle(START_X, START_Y + (INCREMENT_SIZE * i), btns[i].Width / SCALE, btns[i].Height / SCALE);
            }
        }
        public void Update()
        {
            InputManager.Update();
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (InputManager.HasClicked && InputManager.MouseRect.Intersects(btnRects[0]))
                Data.CurrentState = Data.GameStates.Game;
            else if (InputManager.HasClicked && InputManager.MouseRect.Intersects(btnRects[1]))
                Data.CurrentState = Data.GameStates.Settings;
            else if (InputManager.HasClicked && InputManager.MouseRect.Intersects(btnRects[2]))
                Data.Exit = true;

        }
        public void Draw()
        {
            DrawButtons();
        }
        private void DrawButtons()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                Globals.SpriteBatch.Draw(btns[i], btnRects[i], Color.White);
                if (InputManager.MouseRect.Intersects(btnRects[i]))
                {
                    Globals.SpriteBatch.Draw(btns[i], btnRects[i], Color.DarkGray);
                    if (InputManager.HasClicked)
                        Globals.SpriteBatch.Draw(btns[i], btnRects[i], Color.Gray);
                }
            }
        }
    }
}
