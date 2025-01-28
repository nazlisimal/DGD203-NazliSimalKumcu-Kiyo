using System.Collections.Generic;

namespace Kiyo
{
    class Inventory
    {
        private List<string> items;

        public Inventory()
        {
            items = new List<string>();
        }

        public void Add(string item)
        {
            items.Add(item);
        }

        public void Remove(string item)
        {
            items.Remove(item);
        }

        public bool Contains(string item)
        {
            return items.Contains(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public List<string> GetInventory()
        {
            return new List<string>(items);
        }

        public void SetInventory(List<string> newItems)
        {
            items = newItems;
        }
    }
}
