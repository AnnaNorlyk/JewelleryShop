using System;
using Shop.Domain;

namespace Shop.Application
{
    public class Order : IOrder
    {
        public Item Item { get; }

        public Order(Item item)
        {
            Item = item;
        }

        public virtual string Description => Item.Description;
        public virtual decimal Price => Item.Price;
    }
}

