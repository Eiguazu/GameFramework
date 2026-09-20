using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Content.Engine
{
    public class Scene
    {
        // List of all gameobjects in a scene, once objects have been assigned to the list you cannot make those objects point 
        // to a different list. 
        private readonly List<GameObject> Objects = new List<GameObject>();

        // Adds a object to the scene.
        public void Add(GameObject gameObject)
        {
            Objects.Add(gameObject);
        }


        // Removes a object to the scene.
        public void Remove(GameObject gameObject)
        {
            Objects.Remove(gameObject);
        }

        // Updates gametime for all objects in a scene. 
        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject gameObject in Objects)
            {
                gameObject.Update(gameTime);
            }
        }

        // Draws all objects in a scene. 
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in Objects)
            {
                gameObject.Draw(spriteBatch);
            }
        }

    }
}
