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
        public static bool Enabled = false;

        // Use matrix for a screen as a matrix allows for simoutanious change of all objects. 
        public static Matrix GetMatrix(int screenWidth, int screenHeight)
        {
            if (!Enabled)
            {
                return Matrix.Identity;
            }

            return Matrix.CreateTranslation(-Position.X, -Position.Y, 0) * Matrix.CreateTranslation(screenWidth / 2f, screenHeight / 2f, 0);
        }

        public static Vector2 GetScreenCenter()
        {
            return screenCenter;
        }
    }
}