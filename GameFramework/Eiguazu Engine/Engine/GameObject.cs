using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Content.Engine
{
    public class GameObject
    {
        // Gives every GameObject its own Transform. 
        public Transform Transform { get; } = new Transform();

        // Control for sprite rendering.
        public SpriteRenderer SpriteRenderer { get; } = new SpriteRenderer();

        // Collider uses GameObject's transform and scale to scale box properly to texture. 
        public Collider Collider { get; } = new Collider();

        // Gives every GameObject its own Animation component. 
        public Animation Animation { get; } = new Animation();

        // Monogame calls Game1.Updtae as part of its loop, my framework will eventually pass that update down. 
        public virtual void Update(GameTime gameTime)
        {
            SpriteRenderer.Texture = Animation.Update(gameTime);
        }

        // Monogame calls Game1.Draw as part of its loop, my framework will eventually pass that draw down. 
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            SpriteRenderer.Draw(spriteBatch, Transform);
        }

        // Returns true if this object's hitbox overlaps the other object's hitbox.
        public bool Intersects(GameObject other)
        {
            return Collider.IsColliding(Transform, SpriteRenderer, other.Collider, other.Transform, other.SpriteRenderer);
        }


    }
}
