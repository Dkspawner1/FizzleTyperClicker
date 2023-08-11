using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzleClicker.Particle.ParticleCore
{
    public struct ParticleData
    {
        private static Texture2D DefaultTexture;
        public Texture2D Texture = DefaultTexture ??= Globals.Content.Load<Texture2D>("Textures/particle");
        public float Lifespan = 2f;
        public Color ColorStart = Color.White;
        public Color ColorEnd = Color.White;
        public float OpacityStart = 1f;
        public float OpacityEnd = 0f;
        public float SizeStart = 32f;
        public float SizeEnd = 4f;
        public float Speed = 100f;
        public float Angle = 0f;

        public ParticleData() { }
    }
}
