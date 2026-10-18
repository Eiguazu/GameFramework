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

        // Use matrix for a screen as a matrix allows for simoutanious change of all objects. 
        public static Matrix GetMatrix(int screenWidth, int screenHeight)
        {
            return Matrix.CreateTranslation(-Position.X, -Position.Y, 0) * Matrix.CreateTranslation(screenWidth / 2f, screenHeight / 2f, 0);
        }
    }
}