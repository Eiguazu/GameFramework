using GameFramework.Content.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class DefaultScene : Scene
    {
        public DefaultScene()
        {
            // 1. Background, if this scene has one (must be added first so it draws behind everything)
            // SetBackground("ExampleBackground");

            // 2. Tilemap, if this scene is grid-based
            // Tilemap tilemap = new Tilemap("example.txt", 40);
            // tilemap.RegisterFactory("Wall", (pos, param) => new Tile("Wall", pos, true, 40));
            // tilemap.Load(this);

            // 3. One-off objects not covered by the tilemap
            // Add(new DefaultGameObject(new Vector2(100, 100)));

            // 4. Managers / invisible logic objects (spawners, input handlers, etc.)
            // Add(new ExampleManager());

            // 5. UI, added LAST so it draws on top of everything else (text, HUD counters)
            // Add(new DrawText(new Vector2(20, 10), "Score: 0"));

            // 6. Scene-specific dialogue lines, if this scene uses DialogueLibrary
            // DialogueLibrary.SetLine("npc_example", "Hello there.");
        }
    }
}
