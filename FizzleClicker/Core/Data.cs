namespace FizzleClicker.Core
{
    public static class Data
    {
        public static string Title { get; set; } = "Fizzle's 2D Clicker!";
        public static int ScreenWidth { get; set; } = 1600;
        public static int ScreenHeight { get; set; } = 900;
        public static bool IsFullscreen { get; set; } = false;
        public static bool Exit { get; set; } = false;
       
        public enum GameStates { Menu,Game,Settings}
        public static GameStates CurrentState { get; set; } = GameStates.Menu;
        
        public static SpriteFont WordFont { get; set; }
    }
}
