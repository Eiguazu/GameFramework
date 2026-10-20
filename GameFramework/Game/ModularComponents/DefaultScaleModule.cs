using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Content.Engine;
using Microsoft.Xna.Framework;

namespace GameFramework
{
    public class DefaultScaleModule : Component
    {
        public float TargetSize { get; set; } = 40f;
        private bool scaled = false;

        public override void Update(GameTime gameTime)
        {
            if (!scaled && Owner.SpriteRenderer.Texture != null)
            {
                Owner.Transform.Scale = new Vector2(TargetSize / Owner.SpriteRenderer.Texture.Width, TargetSize / Owner.SpriteRenderer.Texture.Height);
                scaled = true;
            }
        }
    }
}
