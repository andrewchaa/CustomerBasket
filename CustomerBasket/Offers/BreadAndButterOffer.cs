using System.Collections.Generic;
using System.Linq;
using CustomerBasket.Contracts;

namespace CustomerBasket.Offers
{
    public class BreadAndButterOffer : ICheckOffer
    {
        public void AddOfferTo(IList<BasketItem> products)
        {
            var butterCount = products.Count(p => p.Name == Product.Butter);
            var breadCount = products.Count(p => p.Name == Product.Bread);

            for (int i = 0; i < breadCount && i < (butterCount / 2); i++)
            {
                var breadPrice = products.First(p => p.Name == Product.Bread).Cost;
                var offer = new Offer(Offer.HalfPriceBread, breadPrice / 2 * -1);
                
                products.Add(offer);
            }
        }
    }
}