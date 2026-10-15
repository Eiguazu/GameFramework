using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Content.Engine
{
    public class DialogueLibrary
    {
        // Dictionary for all of the dialouge. Singleton so globably accesible. 
        public static DialogueLibrary Instance { set; get; } = new DialogueLibrary();
        public static Dictionary<string, string> lines = new Dictionary<string, string>();

        // Sets a line in the dictionary. 
        public static void SetLine(string id, string text)
        {
            lines[id] = text; 
        }

        // Gets and finds a line in the dictionary for dialogue.
        public static string GetLine(string id)
        {
            if (lines.ContainsKey(id))
            {
                return lines[id];
            }
            return "..."; 
        }
    }
}
