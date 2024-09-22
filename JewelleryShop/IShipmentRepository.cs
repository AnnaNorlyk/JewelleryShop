using System;

using Shop.Domain;

namespace Shop.Application
{
    public interface IShipmentRepository
    {
        ShipmentOption GetShipmentOption();
    }
}

