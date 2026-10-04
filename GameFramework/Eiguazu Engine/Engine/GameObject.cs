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

        // A label used to find this object. Objects can share a tag (all raindrops are "Raindrop").
        public string Tag { get; set; } = "";

        // The scene this object is in, or null if it isn't in one. Set by Scene.Add and Scene.Remove.
        public Scene Scene { get; set; }

        // Collider uses GameObject's transform and scale to scale box properly to texture. 
        public Collider Collider { get; } = new Collider();

        // Gives every GameObject its own Animation component. 
        public Animation Animation { get; } = new Animation();

        // Draw this object's hitbox as a red rectangle. Handy for tuning Collider.sizeMultiplier.
        public bool DebugDraw { get; set; } = false;

        // Flip this to true once to show every object's hitbox.
        public static bool ShowHitboxes = false;

        // Sets the layer of the object, lower layers are drawn first.
        public int Layer { get; set; } = 1;

        private static Texture2D pixel;

        // Monogame calls Game1.Updtae as part of its loop, my framework will eventually pass that update down. 
        public virtual void Update(GameTime gameTime)
        {
            SpriteRenderer.Texture = Animation.Update(gameTime);
        }

        // Monogame calls Game1.Draw as part of its loop, my framework will eventually pass that draw down. 
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            SpriteRenderer.Draw(spriteBatch, Transform);

            if (DebugDraw || ShowHitboxes)
            {
                DrawHitbox(spriteBatch);
            }
        }

        // Create the 1x1 white pixel the first time it's needed.
        private void DrawHitbox(SpriteBatch spriteBatch)
        {
            pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            Rectangle bounds = Collider.GetBounds(Transform, SpriteRenderer);
            spriteBatch.Draw(pixel, bounds, Color.Red * 0.35f);  
        }

        // Returns true if this object's hitbox overlaps the other object's hitbox.
        public bool Intersects(GameObject other)
        {
            return Collider.IsColliding(Transform, SpriteRenderer, other.Collider, other.Transform, other.SpriteRenderer);
        }


    }
}
