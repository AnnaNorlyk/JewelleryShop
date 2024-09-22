using System;
namespace Shop.Application
{
    public interface IOrder
    {
        string Description { get; }
        decimal Price { get; }
    }
}
