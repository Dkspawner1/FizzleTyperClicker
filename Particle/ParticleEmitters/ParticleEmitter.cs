using FizzleClicker.Particle.ParticleCore;

namespace FizzleClicker.Particle.ParticleEmitters
{
    public class ParticleEmitter
    {
        private readonly ParticleEmitterData data;
        private float intervalLeft;
        private readonly IEmiiter emitter;
        public ParticleEmitter(IEmiiter emitter, ParticleEmitterData data)
        {
            this.emitter = emitter;
            this.data = data;
            intervalLeft = data.Interval;
        }
        private void Emit(Vector2 position)
        {
                ParticleData d = data.ParticleData;
                d.Lifespan = Globals.RandomFloat(data.LifeSpanMin, data.LifeSpanMax);
                d.Speed = Globals.RandomFloat(data.SpeedMin, data.SpeedMax);
                float r = (float)(Globals.Random.NextDouble() * 2) - 1;
                d.Angle += data.AngleVariance * r;
                ParticleCore.Particle p = new ParticleCore.Particle(position, d);
            
                ParticleManager.AddParticle(p);
        }
        public void Update()
        {
            intervalLeft -= Globals.TotalSeconds;

            while (intervalLeft <= 0f)
            {
                intervalLeft += data.Interval;
                var position = emitter.EmitPosition;

                for (int i = 0; i < data.EmitCount; i++)
                {
                    
                    Emit(position);
                }
            }

        }

    }
}
