using Microsoft.Xna.Framework;
using System;

namespace GameFramework.Content.Engine
{
    public class Collider
    {
        // Collision box is 20% smaller than the sprite by default. 
        public float sizeMultiplier { get; set; } = 0.8f;

        // Method that calculates and returns the collider's rectangle. 
        public Rectangle GetBounds(Transform transform, SpriteRenderer spriteRenderer)
        {
            if (spriteRenderer.Texture == null)
            {
                return Rectangle.Empty;
            }

            float width = spriteRenderer.Texture.Width * Math.Abs(transform.Scale.X) * sizeMultiplier;
            float height = spriteRenderer.Texture.Height * Math.Abs(transform.Scale.Y) * sizeMultiplier;

            return new Rectangle((int)(transform.Position.X - width / 2f), (int)(transform.Position.Y - height / 2f), (int)width, (int)height);
        }

        // Checks for collision between objects returns true if correct. 
        public bool IsColliding(Transform transform, SpriteRenderer spriteRenderer, Collider other, Transform otherTransform, SpriteRenderer otherSpriteRender)
        {
            Rectangle bounds = GetBounds(transform, spriteRenderer);
            Rectangle otherBounds = other.GetBounds(otherTransform, otherSpriteRender);

            return bounds.Intersects(otherBounds);

        }
    }
}
