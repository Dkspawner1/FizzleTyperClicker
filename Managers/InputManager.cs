using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzleClicker.Managers
{
    public static class InputManager
    {
        private static MouseState oldMs;
        public static bool HasClicked { get; private set; }
        public static Vector2 MousePosition { get; private set; }
        public static Rectangle MouseRect { get; private set; }
        public static void Update()
        {
            var mouseState = Mouse.GetState();

            HasClicked = mouseState.LeftButton == ButtonState.Pressed && oldMs.LeftButton == ButtonState.Released;
            MousePosition = mouseState.Position.ToVector2();
            MouseRect = new Rectangle((int)MousePosition.X, (int)MousePosition.Y, 1, 1);
            oldMs = mouseState;
        }
    }
}
