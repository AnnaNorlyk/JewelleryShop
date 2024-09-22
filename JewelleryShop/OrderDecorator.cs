using System;

namespace Shop.Application
{
    public abstract class OrderDecorator : IOrder
    {
        protected IOrder _order;

        protected OrderDecorator(IOrder order)
        {
            _order = order;
        }

        public virtual string Description => _order.Description;
        public virtual decimal Price => _order.Price;
    }
}

