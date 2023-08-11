namespace FizzleClicker.Core
{
    public static class Data
    {
        /// <summary>
        ///  Window 
        /// </summary>
        public static string Title = "Fizzle Clicker!";
        public static int ScreenW { get; set; } = 1600;
        public static int ScreenH { get; set; } = 900;
        public static bool Exit { get; set; } = false;
        /// <summary>
        ///  Menu
        /// </summary>
        public enum GameStates { Menu, Game, Settings }
        public static GameStates CurrentState { get; set; } = GameStates.Menu;
        public static double Dorlls { get; set; } = 0;

    }
}
