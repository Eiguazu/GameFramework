using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace GameFramework.Content.Engine
{
    public class GameObject
    {
        // A list of components or "modules". Modules contain basic functionality from past projects that are pretty common, so 
        // things like player movement etc just have to be attached as components. 
        private List<Component> components = new();

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

        // Boolean to determine whether the object changes across scenes, mainly used for things like player. 
        public bool Persistent { get; set; } = false;

        // Solid object. Solid objects have to collide and cannot pass through other solid objectsl. 
        public bool Solid { get; set; } = false;

        // Reference to deltaTime built into gameobject for ease of use.
        public float deltaTime = 0;

        // Transparent pixel to draw for the hitbox and debugging. 
        private static Texture2D pixel;

        // Toggle for collider on and off. 
        public bool CollisionEnabled = true;

        // Toggle for if the object is part of the UI or not.
        public bool IsUI { get; set; } = false;


        // Monogame calls Game1.Updtae as part of its loop, my framework will eventually pass that update down. 
        public virtual void Update(GameTime gameTime)
        {
            SpriteRenderer.Texture = Animation.Update(gameTime);
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Component component in components)
            {
                component.Update(gameTime);
            }
        }

        // Adds a module as a component. 
        public void AddComponent(Component component)
        {
            components.Add(component);
            component.Attach(this);
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
            if (!CollisionEnabled || !other.CollisionEnabled)
            {
                return false; 
            }
            return Collider.IsColliding(Transform, SpriteRenderer, other.Collider, other.Transform, other.SpriteRenderer);
        }

        // Checks whether the next movment is valid when the obhect is a solid object. This is used for wall collisions. 
        public bool validMove(Vector2 delta)
        {
            Vector2 previous = Transform.Position;
            Transform.Position += delta;

            List<GameObject> solids = Scene.GetSolidObjects();
            for (int i = 0; i < solids.Count; i++)
            {
                if (solids[i] != this && Intersects(solids[i]))
                {
                    Transform.Position = previous;
                    return false; 
                }

            }

            return true; 

        }

        // Plays a sound with instance.
        public void PlaySound(string name, float volume = 1f, float pitch = 0f, float pan = 0f, bool repeat = false)
        {
            SoundEffect sound = AssetManager.Instance.GetSound(name);

            SoundEffectInstance instance = sound.CreateInstance();
            instance.Volume = volume;
            instance.Pitch = pitch;
            instance.Pan = pan;
            instance.IsLooped = repeat;

            instance.Play();
        }

        // Toggles collision on and off. 
        public void ToggleCollision()
        {
            CollisionEnabled = !CollisionEnabled;
        }

    }
}

