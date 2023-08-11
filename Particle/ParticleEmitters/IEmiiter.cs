using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzleClicker.Particle.ParticleEmitters
{
    public interface IEmiiter
    {
        Vector2 EmitPosition { get; }
    }
}
