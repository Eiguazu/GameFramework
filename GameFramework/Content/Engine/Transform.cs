using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Content.Engine
{
    public class Transform
    {
        // Position of an object in 2D space, represented as a Vector2 (X, Y).
        public Vector2 Position { get; set; } = Vector2.Zero;

        // Rotation of an object in radians. A value of 0 means no rotation.
        public float Rotation { get; set; } = 0f;

        // Scale of an object in 2D space, represented as a Vector2 (X, Y). 
        public Vector2 Scale { get; set; } = Vector2.One;
    }
}
