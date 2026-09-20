using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GameFramework.Content.Engine
{
    public class SpriteRenderer
    {
        // Stores the image.
        public Texture2D Texture { get; set; }

        // Flips the sprite. 
        public SpriteEffects Effects { get; set; } = SpriteEffects.None;

        // Tint the sprite.
        public Color Color { get; set; } = Color.White;

        // Rendered on top of transform. 
        public void Draw(SpriteBatch spriteBatch, Transform transform)
        {
            if (Texture == null)
            {
                return;
            }

            spriteBatch.Draw(Texture, transform.Position, null, Color, transform.Rotation, new Vector2(Texture.Width / 2f, Texture.Height / 2f), transform.Scale, Effects, 0f);
        }

        // Allows for sprite flipping.
        public void FlipHorizontally()
        {
            Effects = SpriteEffects.FlipHorizontally;
        }

        // Allows for sprite flipping.
        public void FlipVertically()
        {
            Effects = SpriteEffects.FlipVertically;
        }
    }
}
