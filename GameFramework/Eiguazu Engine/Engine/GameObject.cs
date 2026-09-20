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

        // Monogame calls Game1.Updtae as part of its loop, my framework will eventually pass that update down. 
        public virtual void Update(GameTime gameTime)
        {

        }

        // Monogame calls Game1.Draw as part of its loop, my framework will eventually pass that draw down. 
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            SpriteRenderer.Draw(spriteBatch, Transform);
        }


    }
}
