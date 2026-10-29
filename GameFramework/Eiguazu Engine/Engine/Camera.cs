using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public static class Camera
    {
        // Stores camera position. 
        public static Vector2 Position = Vector2.Zero;
        // Gets screen center. 
        private static Vector2 screenCenter = Vector2.Zero;

        // Toggle for if the camera is on or off. 
        public static bool Enabled = false;

        // Controls how much the camera is zoomed in. 
        public static float Zoom = 1f;

        // Use matrix for a screen as a matrix allows for simoutanious change of all objects. 
        public static Matrix GetMatrix(int screenWidth, int screenHeight)
        {
            if (!Enabled)
            {
                return Matrix.Identity;
            }

            return Matrix.CreateTranslation(-Position.X, -Position.Y, 0) * Matrix.CreateTranslation(screenWidth / 2f, screenHeight / 2f, 0);
        }

        // Sets the screen size. 
        public static void SetScreenSize(int width, int height)
        {
            screenCenter = new Vector2(width / 2f, height / 2f);
        }


        // Finds the screen center. 
        public static Vector2 GetScreenCenter()
        {
            return screenCenter;
        }
    }
}