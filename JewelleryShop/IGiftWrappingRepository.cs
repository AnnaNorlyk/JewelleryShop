using System;

using Shop.Domain;

namespace Shop.Application
{
    public interface IGiftWrappingRepository
    {
        GiftWrappingOption GetGiftWrappingOption();
    }
}

