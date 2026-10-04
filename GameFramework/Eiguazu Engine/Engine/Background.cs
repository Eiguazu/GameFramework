using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameFramework.Content.Engine
{
    public class Background : GameObject
    {
        // Draws a background with a given animation name and position.
        public Background(string animationName, Vector2 position)
        {
            Tag = "Background";
            Transform.Position = position;
            Animation.PlayLoop(animationName);
            Layer = 0;
        }
    }
}
