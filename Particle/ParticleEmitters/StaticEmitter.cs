using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzleClicker.Particle.ParticleEmitters
{
    public class StaticEmitter : IEmiiter
    {
        public Vector2 EmitPosition { get; }
        public StaticEmitter(Vector2 position)
        {
            EmitPosition = position;
        }
        public StaticEmitter(Texture2D texture,Rectangle rectangle)
        {
            EmitPosition = new Vector2(rectangle.X + (rectangle.Width / 2), rectangle.Y + (rectangle.Height / 2));
        }
        
    }
}
