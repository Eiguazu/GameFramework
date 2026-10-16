using Microsoft.Xna.Framework;
using GameFramework.Content.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class DefaultGameObject : GameObject
    {
        public DefaultGameObject(Vector2 position)
        {
            // 1. Identify the object (required for Scene.Find/FindAll to work)
            Tag = "Example";

            // 2. Set initial position
            Transform.Position = position;

            // 3. Set draw order (optional, default is 1 - lower draws first/behind)
            // Layer = 1;

            // 4. Mark as solid if it should block movement (optional)
            // Solid = true;

            // 5. Mark as persistent if it should survive scene changes (optional)
            // Persistent = true;

            // 6. Start an animation (required to be visible - must be registered in Game1 first)
            // Animation.PlayLoop("ExampleIdle");

            // 7. Tune the hitbox if the default 80% doesn't fit (optional)
            // Collider.sizeMultiplier = 1f;

            // 8. Add components (if needed)
            // AddComponent(new ExampleComponent());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Object-specific logic goes here
        }
    }
}
