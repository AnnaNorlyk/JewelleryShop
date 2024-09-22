using System;
using System.IO;
using Shop.Domain;

namespace Shop.Application
{
    public class FileShipmentRepository : IShipmentRepository
    {
        private readonly string _filePath = "shipment.txt";

        public ShipmentOption GetShipmentOption()
        {
            var line = File.ReadAllText(_filePath);
            var parts = line.Split(',');

            return new ShipmentOption
            {
                Description = parts[0],
                Price = decimal.Parse(parts[1])
            };
        }
    }
}

