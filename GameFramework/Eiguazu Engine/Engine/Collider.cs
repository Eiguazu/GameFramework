using Microsoft.Xna.Framework;

namespace GameFramework.Content.Engine
{
    public class Collider
    {
        public Vector2 Size { get; set; } = Vector2.One;

        // Collision box is 20% smaller than the sprite by default. 
        public float sizeMultiplier { get; set; } = 0.8f;
        public Rectangle GetBounds(Transform transform, SpriteRenderer spriteRenderer)
        {
            if (spriteRenderer.Texture == null)
            {
                return Rectangle.Empty;
            }

            float width = spriteRenderer.Texture.Width * transform.Scale.X * sizeMultiplier;
            float height = spriteRenderer.Texture.Height * transform.Scale.Y * sizeMultiplier;

            return new Rectangle((int)(transform.Position.X - (Size.X * transform.Scale.X) / 2f), (int)(transform.Position.Y - (Size.Y * transform.Scale.Y) / 2f), (int)width, (int)height);
        }

        public bool IsColliding(Transform transform, SpriteRenderer spriteRenderer, Collider other, Transform otherTransform, SpriteRenderer otherSpriteRender)
        {
            Rectangle bounds = GetBounds(transform, spriteRenderer);
            Rectangle otherBounds = other.GetBounds(otherTransform, otherSpriteRender);

            return bounds.Intersects(otherBounds);

        }
    }
}
