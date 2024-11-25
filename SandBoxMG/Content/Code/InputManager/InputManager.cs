using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.InputManager
{
    public static class InputManager
    {
        public static MouseState MouseState { get; set; }
        public static MouseState LastMouseState { get; set; }

        public static bool Clicked { get; set; }

        public static Rectangle mouseCursor { get; set; }


        public static void Update()
        {
            LastMouseState = MouseState;
            MouseState = Mouse.GetState();
            if ((MouseState.LeftButton == ButtonState.Pressed) && (LastMouseState.LeftButton == ButtonState.Released))
            {
                Clicked = true;
            }
            else
            {
                Clicked = false;
            }
            mouseCursor = new(MouseState.Position,new(1, 1));

        }

    }
}
