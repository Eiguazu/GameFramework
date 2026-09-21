using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

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
            gameObject.Scene = this;
        }


        // Removes a object to the scene.
        public void Remove(GameObject gameObject)
        {
            Objects.Remove(gameObject);
            gameObject.Scene = this;
        }

        // Updates gametime for all objects in a scene. ToArray mkakes so the forech deos not throw a invalid operation exception. 
        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject gameObject in Objects.ToArray())
            {
                gameObject.Update(gameTime);
            }
        }

        // Draws all objects in a scene. ToArray mkakes so the forech deos not throw a invalid operation exception. 
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in Objects.ToArray())
            {
                gameObject.Draw(spriteBatch);
            }
        }

        // Returns the first object with this tag, or null if none has it.
        public GameObject Find(string tag)
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].Tag == tag)
                {
                    return Objects[i];
                }
            }
            return null;
        }

        // Returns a new list holding every object with this tag.
        // It's a copy, so you can Add or Remove objects while looping over it.
        public List<GameObject> FindAll(string tag)
        {
            List<GameObject> matches = new List<GameObject>();

            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].Tag == tag)
                {
                    matches.Add(Objects[i]);
                }
            }
            return matches;
        }

    }
}
