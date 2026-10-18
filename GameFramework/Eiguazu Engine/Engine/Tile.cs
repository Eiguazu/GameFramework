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
        // Size of the tile. Defualt is 40 at 1280, 720. 
        private int tileSize;

        // Toggle for scaling the image texture to the tile. 
        private bool scaled = false;

        // Shows Tile and declares it as a solid object. Tile is used for basic wall textures and background textures. 
        public Tile(string animationName, Vector2 position, bool solid, int tileSize, string tag)
        {
            Tag = tag;
            Transform.Position = position;
            Animation.PlayLoop(animationName);
            Solid = solid;
            this.tileSize = tileSize;
        }
        public Tile(string animationName, Vector2 position, bool solid, int tileSize)
        {
            Tag = "Tile";
            Transform.Position = position;
            Animation.PlayLoop(animationName);
            Solid = solid;
            this.tileSize = tileSize;
        }

        public Tile(string animationName, Vector2 position, bool solid, string tag)
        {
            Tag = tag;
            Transform.Position = position;
            Animation.PlayLoop(animationName);
            Solid = solid;
        }

        public Tile(string animationName, Vector2 position, bool solid)
        {
            Tag = "Tile";
            Transform.Position = position;
            Animation.PlayLoop(animationName);
            Solid = solid;
            this.tileSize = 40;
        }

        public Tile(string animationName, Vector2 position)
        {
            Tag = "Tile";
            Transform.Position = position;
            Animation.PlayLoop(animationName);
            Solid = false;
            this.tileSize = 40;
        }

        // Scales the texture to the tile size. 
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!scaled && SpriteRenderer.Texture != null)
            {
                Transform.Scale = new Vector2((float)tileSize / SpriteRenderer.Texture.Width, (float)tileSize / SpriteRenderer.Texture.Height);
                scaled = true;
            }

        }
    }
}
