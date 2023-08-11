namespace FizzleClicker.Managers
{
    public static class InputManager
    {
        public static MouseState MouseState, lastMouseState;
        public static Rectangle MouseRect;
        public static KeyboardState keyboardState, lastKeyboardState;

        public static bool MouseLeftClicked { get; private set; }
        public static bool MouseRightClicked { get; private set; }
        public static void UpdateMouse()
        {
            MouseLeftClicked = (MouseState.LeftButton == ButtonState.Pressed) && (lastMouseState.LeftButton == ButtonState.Released);
            MouseRightClicked = (MouseState.RightButton == ButtonState.Pressed) && (lastMouseState.RightButton == ButtonState.Released);

            lastMouseState = MouseState;
            MouseState = Mouse.GetState();
            MouseRect = new Rectangle(MouseState.X, MouseState.Y, 1, 1);
        }
        public static void UpdateKeyboard()
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
        }
        public static char GetLetter()
        {
            // First Row
            if (keyboardState.IsKeyDown(Keys.Q) && lastKeyboardState.IsKeyUp(Keys.Q))
                return 'q';
            else if (keyboardState.IsKeyDown(Keys.W) && lastKeyboardState.IsKeyUp(Keys.W))
                return 'w';
            else if (keyboardState.IsKeyDown(Keys.E) && lastKeyboardState.IsKeyUp(Keys.E))
                return 'e';
            else if (keyboardState.IsKeyDown(Keys.R) && lastKeyboardState.IsKeyUp(Keys.R))
                return 'r';
            else if (keyboardState.IsKeyDown(Keys.T) && lastKeyboardState.IsKeyUp(Keys.T))
                return 't';
            else if (keyboardState.IsKeyDown(Keys.Y) && lastKeyboardState.IsKeyUp(Keys.Y))
                return 'y';
            else if (keyboardState.IsKeyDown(Keys.U) && lastKeyboardState.IsKeyUp(Keys.U))
                return 'u';
            else if (keyboardState.IsKeyDown(Keys.I) && lastKeyboardState.IsKeyUp(Keys.I))
                return 'i';
            else if (keyboardState.IsKeyDown(Keys.O) && lastKeyboardState.IsKeyUp(Keys.O))
                return 'o';
            else if (keyboardState.IsKeyDown(Keys.P) && lastKeyboardState.IsKeyUp(Keys.P))
                return 'p';
            // Second Row
            else if (keyboardState.IsKeyDown(Keys.A) && lastKeyboardState.IsKeyUp(Keys.A))
                return 'a';
            else if (keyboardState.IsKeyDown(Keys.S) && lastKeyboardState.IsKeyUp(Keys.S))
                return 's';
            else if (keyboardState.IsKeyDown(Keys.D) && lastKeyboardState.IsKeyUp(Keys.D))
                return 'd';
            else if (keyboardState.IsKeyDown(Keys.F) && lastKeyboardState.IsKeyUp(Keys.F))
                return 'f';
            else if (keyboardState.IsKeyDown(Keys.G) && lastKeyboardState.IsKeyUp(Keys.G))
                return 'g';
            else if (keyboardState.IsKeyDown(Keys.H) && lastKeyboardState.IsKeyUp(Keys.H))
                return 'h';
            else if (keyboardState.IsKeyDown(Keys.J) && lastKeyboardState.IsKeyUp(Keys.J))
                return 'j';
            else if (keyboardState.IsKeyDown(Keys.K) && lastKeyboardState.IsKeyUp(Keys.K))
                return 'k';
            else if (keyboardState.IsKeyDown(Keys.L) && lastKeyboardState.IsKeyUp(Keys.L))
                return 'l';
            // Third Row
            else if (keyboardState.IsKeyDown(Keys.Z) && lastKeyboardState.IsKeyUp(Keys.Z))
                return 'z';
            else if (keyboardState.IsKeyDown(Keys.X) && lastKeyboardState.IsKeyUp(Keys.X))
                return 'x';
            else if (keyboardState.IsKeyDown(Keys.C) && lastKeyboardState.IsKeyUp(Keys.C))
                return 'c';
            else if (keyboardState.IsKeyDown(Keys.V) && lastKeyboardState.IsKeyUp(Keys.V))
                return 'v';
            else if (keyboardState.IsKeyDown(Keys.B) && lastKeyboardState.IsKeyUp(Keys.B))
                return 'b';
            else if (keyboardState.IsKeyDown(Keys.N) && lastKeyboardState.IsKeyUp(Keys.N))
                return 'n';
            else if (keyboardState.IsKeyDown(Keys.M) && lastKeyboardState.IsKeyUp(Keys.M))
                return 'm';

            return ' ';
        }
    
    }
}
