using System;
using System.IO;
using Shop.Domain;

namespace Shop.Application
{
    public class FileGiftWrappingRepository : IGiftWrappingRepository
    {
        private readonly string _filePath = "giftwrapping.txt";

        public GiftWrappingOption GetGiftWrappingOption()
        {
            var line = File.ReadAllText(_filePath);
            var parts = line.Split(',');

            return new GiftWrappingOption
            {
                Description = parts[0],
                Price = decimal.Parse(parts[1])
            };
        }
    }
}
