using System.Collections.Generic;
using System.Linq;
using CustomerBasket.Contracts;

namespace CustomerBasket
{
    public class Basket
    {
        private readonly IEnumerable<ICheckOffer> _offerCheckers;
        private readonly IList<BasketItem> _products;

        public Basket(IEnumerable<ICheckOffer> offerCheckers)
        {
            _offerCheckers = offerCheckers;
            _products = new List<BasketItem>();
        }

        public void Add(BasketItem product)
        {
            _products.Add(product);
        }

        public decimal Total()
        {
            foreach (var checker in _offerCheckers)
            {
                checker.AddOfferTo(_products);
            }

            return _products.Sum(p => p.Cost);
        }
    }
}