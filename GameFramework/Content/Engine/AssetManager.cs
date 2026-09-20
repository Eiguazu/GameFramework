using GameFramework.Content.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Content.Engine
{
    public class AssetManager
    {
        // Content Manager is MonoGame's system for loading assets that went through the content pipeline. 
        private ContentManager content;

        // AssetNabager gas a dictionary called textures that associates a Sprites value with a Texture2D.
        private Dictionary<Sprites, Texture2D> textures;

        // One private shared variable called instance that can hold AssetManager objects. Singleton making Instance 
        // globally accessible. 
        private static AssetManager instance;

        // Animation Logic
        private Dictionary<string, List<Sprites>> animations; 

        // When someone creates an AssetManager they must give a ContentManager to inialize content. 
        public AssetManager(ContentManager content)
        {
            instance = this;
            this.content = content;

            textures = new Dictionary<Sprites, Texture2D>();
            animations = new Dictionary<string, List<Sprites>>();

            foreach (Sprites sprite in Enum.GetValues(typeof(Sprites)))
            {
                string name = sprite.ToString();
                Texture2D texture = content.Load<Texture2D>(name);
                textures.Add(sprite, texture); 
            }
        }

        // Gets the Texture2D from the enum list when given a sprites ID. 
        public Texture2D GetTexture(Sprites sprites)
        {
            return textures[sprites]; 
        }

        //Allows other classes to acess the AssetManager Instance. 
        public static AssetManager Instance
        {
            get
            {
                return instance;
            }
        }

        // Loads animations.
        public void LoadAnimation(string animationName, params Sprites[] frames)
        {
            animations.Add(animationName, new List<Sprites>(frames));
        }

        // Gets the number of frames in an animation
        public int GetAnimationLength(string animationName)
        {
            return animations[animationName].Count;
        }

        // Retrieves the Texture2D for the current frame. 
        public Texture2D GetAnimationFrame(string animationName, int frame)
        {
            Sprites sprite = animations[animationName][frame];
            return textures[sprite];
        }
    }
}
