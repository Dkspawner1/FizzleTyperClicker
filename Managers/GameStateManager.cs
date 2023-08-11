
using FizzleClicker.Particle.ParticleCore;
using FizzleClicker.Scenes;

namespace FizzleClicker.Managers
{
    internal class GameStateManager
    {
        private MenuScene ms = new();
        private GameScene gs = new();

        public void Init()
        {
            ms.Init();
            gs.Init();
        }

        public void Update()
        {
            switch (Data.CurrentState)
            {
                case Data.GameStates.Menu:
                    ms.Update();
                    break;

                case Data.GameStates.Game:
                    gs.Update();

                    break;
                case Data.GameStates.Settings:
                    break;
            }
        }
        public void Draw()
        {
            switch (Data.CurrentState)
            {
                case Data.GameStates.Menu:
                    ms.Draw();

                    break;
                case Data.GameStates.Game:
                    gs.Draw();

                    break;
                case Data.GameStates.Settings:
                    break;
            }
        }
    }
}
