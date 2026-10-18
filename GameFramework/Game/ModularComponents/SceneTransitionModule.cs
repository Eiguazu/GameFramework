using GameFramework.Content.Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class SceneTransitionModule : Component
    {
        public string TargetScene { get; set; }
        public string TriggerTag { get; set; }

        // Theres this really annoying problem i have with persistant objects and doors. see when a object is persistant, it doesnt get created again, which should be fine
        // However because its not getting created it doestnt get that new position after the door, and its really hard to set up a link in different scenes with doors 
        // because they dont talk like that. and also the issue of the hitbox hitting the door and teleporting the player back. So setting th eposition is the most annoying
        // thing to do here, but its the easiest option. 
        public Vector2 TargetPosition { get; set; }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GameObject target = Owner.Scene.Find(TriggerTag);

            if (Owner.Intersects(target))
            {
                target.Transform.Position = TargetPosition;
                Owner.Scene.NextScene = TargetScene;
            }
        }
    }
}
