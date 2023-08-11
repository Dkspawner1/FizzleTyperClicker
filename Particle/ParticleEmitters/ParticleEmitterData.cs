using FizzleClicker.Particle.ParticleCore;

namespace FizzleClicker.Particle.ParticleEmitters
{
    public struct ParticleEmitterData
    {

        public ParticleData ParticleData = new ParticleData();
        public float Angle = 0f;
        public float AngleVariance = 45f;
        public float LifeSpanMin = 2f;
        public float LifeSpanMax = 2f;
        public float SpeedMin = 10f;
        public float SpeedMax = 100f;
        public float Interval = 1f;
        public int EmitCount = 1;

        public ParticleEmitterData() {}
    }
}
