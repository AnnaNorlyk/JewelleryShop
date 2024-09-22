using System;

using Shop.Domain;

namespace Shop.Application
{
    public class GiftWrappingDecorator : OrderDecorator
    {
        private readonly GiftWrappingOption _giftWrappingOption;

        public GiftWrappingDecorator(IOrder order, GiftWrappingOption giftWrappingOption)
            : base(order)
        {
            _giftWrappingOption = giftWrappingOption;
        }

        public override string Description => $"{_order.Description} + {_giftWrappingOption.Description}";
        public override decimal Price => _order.Price + _giftWrappingOption.Price;
    }
}
