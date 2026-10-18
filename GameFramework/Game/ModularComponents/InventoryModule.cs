using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    // Temp adition, not fully stackable functions and etc. 
    public class InventoryModule : Component
    {
        // Inventory addon. 
        private HashSet<string> items = new HashSet<string>();

        public void AddItem(string itemName)
        {
            items.Add(itemName);
        }

        public bool HasItem(string itemName)
        {
            return items.Contains(itemName);
        }

        public void RemoveItem(string itemName)
        {
            items.Remove(itemName);
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
