using FizzleClicker.Core;

namespace FizzleClicker.Words
{
    internal class WordGenerator
    {
        private Random random;

        internal string Word;
        internal Vector2 Position;
        public Vector2 WordLength => Data.WordFont.MeasureString(Word);
        public Color @Color { get; protected set; } = Color.White;

        internal bool Visible;
        internal int Speed { get; set; } = 5;

        public WordGenerator(string word)
        {
            Word = word;
            random = new Random();
            Position = RandomPosition();
            Color = PickRandomColor();
        }

        private Color PickRandomColor()
        {
            const int START_POINT = 15, END_POINT = 256, MAX_ALPHA = 256;
            int[] RGB = new int[]
           {
                random.Next(START_POINT, END_POINT),
                random.Next(START_POINT, END_POINT),
                random.Next(START_POINT, END_POINT)
           };

            return new Color(RGB[0], RGB[1], RGB[2], MAX_ALPHA);
        }

        private Vector2 RandomPosition() => new Vector2(random.Next(0, (int)(Data.ScreenWidth - WordLength.X)), -WordLength.Y);
        public void Update() => Position.Y += Speed;

        public void Draw(SpriteBatch spriteBatch) => spriteBatch.DrawString(Data.WordFont, Word, Position, Color);
    }
}
