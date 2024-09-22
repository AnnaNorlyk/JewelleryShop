using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Application;
using Shop.Domain;

namespace Shop.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize repositories
            IItemRepository itemRepository = new FileItemRepository();
            IGiftWrappingRepository giftWrappingRepository = new FileGiftWrappingRepository();
            IShipmentRepository shipmentRepository = new FileShipmentRepository();

            // Use Case #1: Show All Items
            var items = itemRepository.GetAllItems();
            DisplayItems(items);

            // Use Case #2: Pick Item
            var selectedItem = GetUserSelectedItem(items);

            // Build the order
            IOrder order = new Order(selectedItem);

            // Use Case #3: Add/Ignore GiftWrapping
            var giftOption = giftWrappingRepository.GetGiftWrappingOption();
            if (UserWantsOption($"Do you want gift wrapping for an additional {giftOption.Price:C}? (y/n): "))
            {
                order = new GiftWrappingDecorator(order, giftOption);
            }

            // Use Case #4: Add/Ignore Shipment
            var shipmentOption = shipmentRepository.GetShipmentOption();
            if (UserWantsOption($"Do you want shipment for an additional {shipmentOption.Price:C}? (y/n): "))
            {
                order = new ShipmentDecorator(order, shipmentOption);
            }

            // Use Case #5: View Order with Total Price
            DisplayOrderSummary(order);

            Console.WriteLine("\nThank you for shopping with us!");
            Console.ReadLine();
        }

        static void DisplayItems(IEnumerable<Item> items)
        {
            Console.WriteLine("Available Items:");
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Description: {item.Description}, Price: {item.Price:C}");
            }
        }

        static Item GetUserSelectedItem(IEnumerable<Item> items)
        {
            Console.Write("\nEnter the ID of the item you want to purchase: ");
            int itemId;
            while (!int.TryParse(Console.ReadLine(), out itemId) || !items.Any(i => i.Id == itemId))
            {
                Console.Write("Invalid ID. Please enter a valid item ID: ");
            }

            return items.First(i => i.Id == itemId);
        }

        static bool UserWantsOption(string prompt)
        {
            Console.Write(prompt);
            var response = Console.ReadLine().Trim().ToLower();
            return response == "y" || response == "yes";
        }

        static void DisplayOrderSummary(IOrder order)
        {
            Console.WriteLine("\nYour Order:");
            Console.WriteLine($"Description: {order.Description}");
            Console.WriteLine($"Total Price: {order.Price:C}");
        }
    }
}

