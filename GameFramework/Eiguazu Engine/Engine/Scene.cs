using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameFramework.Content.Engine
{
    public class Scene
    {
        // List of all gameobjects in a scene, once objects have been assigned to the list you cannot make those objects point 
        // to a different list. 
        private readonly List<GameObject> Objects = new List<GameObject>();

        // Stores the name of the next scene to load, if empty it will not change scenes.
        public string NextScene = "";

        // Stores the center of the screen, used for centering objects.
        public static Vector2 ScreenCenter;

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
            gameObject.Scene = null;
        }

        // Updates gametime for all objects in a scene. ToArray mkakes so the forech deos not throw a invalid operation exception. 
        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject gameObject in Objects.ToArray())
            {
                gameObject.Update(gameTime);
            }
        }

        // Draws all objects in a scene. ToArray mkakes so the forech deos not throw a invalid operation exception. Also sorts it now by layer.
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            GameObject[] snapshot = Objects.ToArray();
            Array.Sort(snapshot, CompareByLayer);

            foreach (GameObject gameObject in snapshot)
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

        // Adds a full-screen background image. Call in scene construction when inheriting. Set position to null to center the background.
        public void SetBackground(string animationName)
        {
            SetBackground(animationName, ScreenCenter);
        }

        // Adds a full-screen background image. Call in scene construction when inheriting.
        public void SetBackground(string animationName, Vector2 position)
        {
            Background background = new Background(animationName, position);
            Objects.Insert(0, background);
            background.Scene = this;
        }

        // Allows arroay to sort two gameobjects by layer with the lowest going first. 
        private static int CompareByLayer(GameObject a, GameObject b)
        {
            return a.Layer.CompareTo(b.Layer);
        }
    }
}
