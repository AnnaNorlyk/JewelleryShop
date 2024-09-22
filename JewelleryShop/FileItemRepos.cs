using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shop.Domain;

namespace Shop.Application
{
    public class FileItemRepository : IItemRepos
    {
        private readonly string _filePath = "items.txt";

        public IEnumerable<Item> GetAllItems()
        {
            var lines = File.ReadAllLines(_filePath);
            var items = new List<Item>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                items.Add(new Item
                {
                    Id = int.Parse(parts[0]),
                    Description = parts[1],
                    Price = decimal.Parse(parts[2])
                });
            }

            return items;
        }

        public Item GetItemById(int id)
        {
            return GetAllItems().FirstOrDefault(item => item.Id == id);
        }
    }
}
