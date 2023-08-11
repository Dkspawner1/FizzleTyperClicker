using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzleClicker.Particle.ParticleEmitters
{
    internal class ScreenEmitter : IEmiiter
    {
        public Rectangle EmitRect { get; set; }
        public Vector2 EmitPosition { get; }
        public ScreenEmitter(Rectangle emitRect) : base ()
        {
            EmitRect = emitRect;
            EmitPosition = new Vector2(emitRect.X,emitRect.Y);
        }
    }
}
