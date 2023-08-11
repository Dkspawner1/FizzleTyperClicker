namespace FizzleClicker.Particle.ParticleCore
{
    public class Particle
    {
        private readonly ParticleData data;
        private Vector2 position;
        private float lifespanLeft;
        private float lifespanAmount;
        private Color color;
        private float opacity;
        public bool IsFinished = false;
        private float scale;
        private Vector2 origin;
        private Vector2 direction;
        public Particle(Vector2 pos, ParticleData data)
        {
            this.data = data;
            lifespanLeft = data.Lifespan;
            lifespanAmount = 1f;
            position = pos;
            color = data.ColorStart;
            opacity = data.OpacityStart;
            origin = new(data.Texture.Width / 2, data.Texture.Height / 2);
            if (data.Speed != 0)
            {
                data.Angle = MathHelper.ToRadians(data.Angle);
                direction = new Vector2((float)Math.Sin(data.Angle), -(float)Math.Cos(data.Angle));
            }
            else
                direction = Vector2.Zero;

        }

        public void Update()
        {
            lifespanLeft -= Globals.TotalSeconds;
            if (lifespanLeft <= 0f)
            {
                IsFinished = true;
                return;
            }

            lifespanAmount = MathHelper.Clamp(lifespanLeft / data.Lifespan, 0, 1);
            color = Color.Lerp(data.ColorEnd, data.ColorStart, lifespanAmount);
            opacity = MathHelper.Clamp(MathHelper.Lerp(data.OpacityEnd, data.OpacityStart, lifespanAmount), 0, 1);
            scale = MathHelper.Lerp(data.SizeEnd, data.SizeStart, lifespanAmount) / data.Texture.Width;
            position += direction * data.Speed * Globals.TotalSeconds;

        }

        public void Draw() => Globals.SpriteBatch.Draw(data.Texture, position, null, color * opacity, 0f, origin, scale, SpriteEffects.None, 1f);
    }
}
