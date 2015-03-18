using System.Collections.Generic;
using System.Linq;
using CustomerBasket.Contracts;
using CustomerBasket.Offers;
using Machine.Specifications;

namespace CustomerBasket.Tests
{
    public class OfferCheckerTests
    {
        public class Context
        {
            protected static IList<BasketItem> _products;
            protected static BreadAndButterOffer _breadAndButterOffer;
            protected static MilkOffer _milkOffer;
        }

        public class When_buying_two_butter_and_a_butter : Context
        {
            Establish context = () =>
            {
                _products = new List<BasketItem>
                {
                    new Product(Product.Butter, 0.80m),
                    new Product(Product.Butter, 0.80m),
                    new Product(Product.Bread, 1.00m)
                };

                _breadAndButterOffer = new BreadAndButterOffer();
            };

            Because of = () => _breadAndButterOffer.AddOfferTo(_products);

            It should_have_an_offer = () => _products.ShouldContain(new Offer(Offer.HalfPriceBread, -1*(1.00m/2)));
            It should_have_2_offers = () => _products.Count(p => p.Name == Offer.HalfPriceBread).ShouldEqual(1);
        }

        public class When_buying_4_butter_and_two_bread : Context
        {
            Establish context = () =>
            {
                _products = new List<BasketItem>
                {
                    new Product(Product.Butter, 0.80m),
                    new Product(Product.Butter, 0.80m),
                    new Product(Product.Butter, 0.80m),
                    new Product(Product.Butter, 0.80m),
                    new Product(Product.Bread, 1.00m),
                    new Product(Product.Bread, 1.00m)
                };

                _breadAndButterOffer = new BreadAndButterOffer();
            };
            
            Because of = () => _breadAndButterOffer.AddOfferTo(_products);

            It should_have_2_bread_offers = () => _products.Count(p => p.Name == Offer.HalfPriceBread).ShouldEqual(2);
        }

        public class When_buying_4_milk : Context
        {
            Establish context = () =>
            {
                _products = new List<BasketItem>
                {
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m)
                };

                _milkOffer = new MilkOffer();
            };
            
            Because of = () => _milkOffer.AddOfferTo(_products);

            It should_have_the_4th_free = () => _products.Count(p => p.Name == Offer.FreeMilk).ShouldEqual(1);
        }

        public class When_buying_7_milk : Context
        {
            Establish context = () =>
            {
                _products = new List<BasketItem>
                {
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m)
                };

                _milkOffer = new MilkOffer();
            };
            
            Because of = () => _milkOffer.AddOfferTo(_products);

            It should_have_the_4th_free = () => _products.Count(p => p.Name == Offer.FreeMilk).ShouldEqual(1);
        }

        public class When_buying_8_milk : Context
        {
            Establish context = () =>
            {
                _products = new List<BasketItem>
                {
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m),
                    new Product(Product.Milk, 1.150m)
                };

                _milkOffer = new MilkOffer();
            };
            
            Because of = () => _milkOffer.AddOfferTo(_products);

            It should_have_the_4th_and_8th_free = () => _products.Count(p => p.Name == Offer.FreeMilk).ShouldEqual(2);
        }


    }
}
