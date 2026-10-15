using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Content.Engine
{
    public class Tile : GameObject
    {
        //
        private int tileSize;
        //
        private bool scaled = false; 

        //
        public Tile(string animationName, Vector2 position, bool solid)
        {
            Tag = "Tile";
            Transform.Position = position;
            Animation.PlayLoop(animationName);
            Solid = solid; 
        }

        //
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(!scaled && SpriteRenderer.Texture != null)
            {
                Transform.Scale = new Vector2((float)tileSize / SpriteRenderer.Texture.Width, (float)tileSize / SpriteRenderer.Texture.Height);
                scaled = true; 
            }

        }
    }
}
