using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameFramework.Content.Engine
{
    public static class Input
    {
        // Stores the current and previous states of the mouse.This is to detect individual clicks. 
        private static MouseState currentMouse;
        private static MouseState previousMouse;

        // Stores the current and previous states of the keyboard.This is to detect individual key presses. 

        private static KeyboardState currentKeys;
        private static KeyboardState previousKeys;

        // Call once per frame, at the top of Game1.Update, before anything else reads input.
        public static void Update()
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            previousKeys = currentKeys;
            currentKeys = Keyboard.GetState();
        }

        // Keeps track of the mouse position.
        public static Vector2 MousePosition()
        {
            return currentMouse.Position.ToVector2();
        }

        // True only on a key press
        public static bool LeftClicked()
        {
            return currentMouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released;
        }

        // True only on a click. 
        public static bool RightClicked()
        {
            return currentMouse.RightButton == ButtonState.Pressed && previousMouse.RightButton == ButtonState.Released;
        }

        // True every frame the mouse is down.
        public static bool LeftHeld()
        {
            return currentMouse.LeftButton == ButtonState.Pressed;
        }

        // True every frame the mouse is down.
        public static bool RightHeld()
        {
            return currentMouse.RightButton == ButtonState.Pressed;
        }

        // True only on the exact frame the key goes down.
        public static bool KeyPressed(Keys key)
        {
            return currentKeys.IsKeyDown(key) && previousKeys.IsKeyUp(key);
        }

        // True every frame the key is down.
        public static bool KeyHeld(Keys key)
        {
            return currentKeys.IsKeyDown(key);
        }
    }
}
