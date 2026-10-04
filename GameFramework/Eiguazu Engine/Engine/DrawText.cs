using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Content.Engine
{
    public class DrawText : GameObject
    {
        // Sets the font for text. 
        private SpriteFont font;

        // Sets the text for the text. 
        private string text;

        // Contructor for the text. Text is alwyas drawn on top. 
        public DrawText(Vector2 position, string text)
        {
            Tag = "DrawText";
            font = AssetManager.Instance.GetFont("file");
            this.text = text;
            Transform.Position = position;
            Layer = 999;
        }

        // Changes text. 
        public void SetText(string newText)
        {
            text = newText;
        }

        // Has no animation playing, so it draws nothing exept for the text. 
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(font, text, Transform.Position, Color.White);
        }

    }
}
