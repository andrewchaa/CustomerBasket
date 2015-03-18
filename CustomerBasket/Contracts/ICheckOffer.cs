using System.Collections.Generic;

namespace CustomerBasket.Contracts
{
    public interface ICheckOffer
    {
        void AddOfferTo(IList<BasketItem> products);
    }
}