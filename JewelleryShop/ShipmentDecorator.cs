using System;

using Shop.Domain;

namespace Shop.Application
{
    public class ShipmentDecorator : OrderDecorator
    {
        private readonly ShipmentOption _shipmentOption;

        public ShipmentDecorator(IOrder order, ShipmentOption shipmentOption)
            : base(order)
        {
            _shipmentOption = shipmentOption;
        }

        public override string Description => $"{_order.Description} + {_shipmentOption.Description}";
        public override decimal Price => _order.Price + _shipmentOption.Price;
    }
}

