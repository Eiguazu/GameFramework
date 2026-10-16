using GameFramework.Content.Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameFramework.Content.Engine
{
    public class Tilemap
    {
        // File name of the map assets. 
        private string fileName;

        // Legend for storing all the charecter definitions for the tile map. 
        private Dictionary<char, string[]> legend = new Dictionary<char, string[]>();

        // A factory of functions that contain the necessary information to create new instances of classes. 
        private Dictionary<string, Func<Vector2, string, GameObject>> factories = new Dictionary<string, Func<Vector2, string, GameObject>>();

        // Size of the tile. 
        private int tileSize;

        // Initalizes the filename and the tileSize. 
        public Tilemap(string fileName, int tileSize = 40)
        {
            this.fileName = fileName;
            this.tileSize = tileSize;
        }

        // Registers a factory to a type. 
        public void RegisterFactory(string type, Func<Vector2, string, GameObject> factory)
        {
            factories[type] = factory;
        }

        // Seperates a legend into different parts and into a array of strings for reading.
        private void LoadLegend(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(',');

                char symbol = parts[0].Trim()[0];
                string type = parts[1].Trim();

                string parameter = "";

                if (parts.Length > 2)
                {
                    parameter = parts[2].Trim();
                }

                legend[symbol] = new string[] { type, parameter };

            }
        }

        // Processes and loads the level tiles. Does this by parsing through a list of factories functions which are added to the scene. 
        public void Load(Scene scene)
        {
            string mapPath = Path.Combine(AppContext.BaseDirectory, "Levels", fileName);
            string legendPath = Path.Combine(AppContext.BaseDirectory, "Levels", "legend.txt");

            LoadLegend(legendPath);

            string[] mapLines = File.ReadAllLines(mapPath);

            for (int row = 0; row < mapLines.Length; row++)
            {
                for (int col = 0; col < mapLines[row].Length; col++)
                {
                    char symbol = mapLines[row][col];

                    if (!legend.ContainsKey(symbol))
                    {
                        continue;
                    }

                    string type = legend[symbol][0];
                    string parameter = legend[symbol][1];

                    if (!factories.ContainsKey(type))
                    {
                        continue;
                    }

                    Vector2 position = new Vector2(col * tileSize + tileSize / 2f, row * tileSize + tileSize / 2f);

                    GameObject obj = factories[type](position, parameter);


                    scene.Add(obj);
                }
            }
        }
    }
}

// --Learning Opertunity--

// Becuase factories are a new concept to me, I thought it would be useful for things like this to explain below how they work. I will do this 
// for all future new concepts. A factory is esintailly a class or method that creates objects for you, instead of having you manually construct
// them everywhere. In my framework, i use factories to creat eplayers, enemies, walls without needign to know h=details for how they are built. 
// I use factories for a bit of a different way but this is how they are mostly used. 


// For example normally you would have to create a new object like this. 

//  Player player = new Player(new Vector2(100, 100));


// But with factory, you have direct access into the classes constructor. A factory can directly call a class's constructor using new, and it allows
// you to edit all the normal variables you would be able to edit otherwise. 

//  public static class GameObjectFactory
//  {
//        public static Player CreatePlayer(Vector2 position)
//        {
//          Player player = new Player(position);

//          // Additional setup
//          player.Tag = "Player";
//          // Add components, configure animations, etc.

//           return player;
//        }
//  }

// By using a factory call, you would not have to decalre the originaial parameters of a contstructor in the original class. You can just declare
// those directly in the factory, which improves readability. 

// Player player = GameObjectFactory.CreatePlayer(new Vector2(100, 100));

// It would look somethign like this. Idk how this is useful in most situations, maybe if something has like a billion parameters, or if you want
// to keep all of your object creation in a single place. In the case of this project, the Tilemap calss is using a factory system to turn charecters
// in a text file into GameObject instances. A factory is only useful in my case, as I don't know which objects I would be adding into the tilemap
// from the legend. I have a list of factory functions that I can add to in the scene class, so whenever I need a new object I would just register
// it to the current scene using a factory function. The registering gives the factory list the necessary information to create the object 
// whenever I want it made, reading that from the legend and level files respectively. So because of the factory, if I request "P" for player
// to be added, it looks for the factory funciton for creating "P" in the dictionary and creates it at the designated position. Again to reiterate,
// registering a factory doesn't create the object. It stores the funciton that will create the object later, when load() encouters the corresponding 
// symbol in the map. Idk I did all of this rounabout stuff becuase I just don't want to be editing the engine files in any capacity when im working
// on a project, its a strict rule. 
