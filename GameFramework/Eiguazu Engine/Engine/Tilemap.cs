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
        //
        private string fileName;

        //
        private Dictionary<char, string[]> legend = new Dictionary<char, string[]>();
        //
        private Dictionary<string, Func<Vector2, string, GameObject>> factories = new Dictionary<string, Func<Vector2, string, GameObject>>();

        //
        private int tileSize;


        //
        public Tilemap(string fileName, int tileSize = 40)
        {
            this.fileName = fileName;
            this.tileSize = tileSize;
        }

        //
        public void RegisterFactory(string type, Func<Vector2, string, GameObject> factory)
        {
            factories[type] = factory;
        }

        //
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

        //
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
