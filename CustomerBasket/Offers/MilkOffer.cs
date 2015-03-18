using System.Collections.Generic;
using System.Linq;
using CustomerBasket.Contracts;

namespace CustomerBasket.Offers
{
    public class MilkOffer : ICheckOffer
    {
        public void AddOfferTo(IList<BasketItem> products)
        {
            var milkCount = products.Count(p => p.Name == Product.Milk);

            for (int i = 0; i < milkCount/4; i++)
            {                
                var milkCost = products.First(p => p.Name == Product.Milk).Cost;
                var offer = new Offer(Offer.FreeMilk, milkCost * -1);

                products.Add(offer);
            }
        }
    }
}