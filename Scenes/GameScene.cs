using FizzleClicker.Managers;
using FizzleClicker.Particle.ParticleCore;
using FizzleClicker.Particle.ParticleEmitters;


namespace FizzleClicker.Scenes
{


    internal class GameScene
    {
        /// <summary>
        ///  Texture stuff
        /// </summary>
        private SpriteFont wordFont;
        private Texture2D clickerTexture;
        private Rectangle clickerRect;
        /// <summary>
        /// Particle 
        /// </summary>
        private double blockHealth = 5;

        private readonly MouseEmitter mouseEmitter = new MouseEmitter();
        private StaticEmitter staticEmitter;
        private ParticleEmitter pe3;
        private float emitterInterval = 1f;
        private ParticleEmitterData destroy;
        private ParticleData particleData;
        public void Init()
        {
            wordFont = Globals.Content.Load<SpriteFont>("Fonts/wordfont");
            clickerTexture = Globals.Content.Load<Texture2D>("Textures/tile0");
            clickerRect = new(500, 500, clickerTexture.Width, clickerTexture.Height);
            particleData = new ParticleData()
            {
                ColorStart = Color.Yellow,
                ColorEnd = Color.Red,
                SizeStart = 16,
                SizeEnd = 64,
                Lifespan = 10f,

            };

            destroy = new ParticleEmitterData()
            {
                Interval = emitterInterval,
                EmitCount = 500,
                AngleVariance = 180f,
                LifeSpanMin = 1f,
                LifeSpanMax = 1f,
                SpeedMin = 25f,
                SpeedMax = 75f,
                ParticleData = particleData
            };

            staticEmitter = new StaticEmitter(clickerTexture, clickerRect);

            pe3 = new(staticEmitter, destroy);
            ParticleManager.AddParticleEmitter(pe3);
        }
        public void Update()
        {
            InputManager.Update();
            if(blockHealth <= 0)
            ParticleManager.Update();

            if (InputManager.HasClicked && clickerRect.Intersects(InputManager.MouseRect))
            {
                Data.Dorlls++;
                blockHealth--;
            }
            if (blockHealth <= 0)
            {
                /// Todo: Add Components to blocks such as randomly picked texture, health and stats
                blockHealth = 5;
            }
        }

        public void Draw()
        {
            DrawBlock();
            DrawText();
            ParticleManager.Draw();
        }

        private void DrawBlock()
        {
            Globals.SpriteBatch.Draw(clickerTexture, clickerRect, Color.White);
            if (clickerRect.Intersects(InputManager.MouseRect))
                Globals.SpriteBatch.Draw(clickerTexture, clickerRect, Color.DarkGray);
            if (InputManager.HasClicked && clickerRect.Intersects(InputManager.MouseRect))
                Globals.SpriteBatch.Draw(clickerTexture, clickerRect, Color.Gray);

        }
        private void DrawText()
        {
            Globals.SpriteBatch.DrawString(wordFont, Data.Dorlls.ToString(), new Vector2(50, 50), Color.Black);

            var blockHealthSize = wordFont.MeasureString(blockHealth.ToString());
            var yOffset = 75;
            var textCentered = new Vector2(clickerRect.X + (clickerTexture.Width / 2) - blockHealthSize.X / 2, clickerRect.Y + (clickerTexture.Height / 2) - (blockHealthSize.Y / 2) - yOffset);
            Globals.SpriteBatch.DrawString(wordFont, blockHealth.ToString(), textCentered, Color.White);

        }
    }
}
