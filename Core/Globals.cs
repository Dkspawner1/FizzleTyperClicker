global using global::Microsoft.Xna.Framework;
global using global::Microsoft.Xna.Framework.Content;
global using global::Microsoft.Xna.Framework.Graphics;
global using global::FizzleClicker.Core;
global using System;

namespace FizzleClicker.Core
{
    public static class Globals
    {
        public static ContentManager Content { get; set; }
        public static float TotalSeconds { get; set; }
        public static Random Random { get; set; } = new();
        public static SpriteBatch SpriteBatch { get; set; }
        public static void Update(GameTime gameTime) => TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        public static float RandomFloat(float min, float max) => (float)(Random.NextDouble() * (min - max)) + min;

    }

}
