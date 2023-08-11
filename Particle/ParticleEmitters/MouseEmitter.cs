using FizzleClicker.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzleClicker.Particle.ParticleEmitters
{
    internal class MouseEmitter : IEmiiter
    {
        public Vector2 EmitPosition => InputManager.MousePosition;
    }
}
