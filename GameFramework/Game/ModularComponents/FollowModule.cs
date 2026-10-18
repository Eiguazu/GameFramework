using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Content.Engine;
using Microsoft.Xna.Framework;

namespace GameFramework
{
    public class FollowModule : Component
    {
        public string TargetTag { get; set; } = "Player";
        public float Speed { get; set; } = 100f;

        public override void Update(GameTime gameTime)
        {
            if (Owner.Scene == null)
            {
                return;
            }

            GameObject target = Owner.Scene.Find(TargetTag);
            if (target == null)
            {
                return;
            }

            Vector2 direction = target.Transform.Position - Owner.Transform.Position;
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            float dt = Owner.deltaTime;
            Owner.validMove(new Vector2(direction.X * Speed * dt, 0));
            Owner.validMove(new Vector2(0, direction.Y * Speed * dt));
        }
    }
}