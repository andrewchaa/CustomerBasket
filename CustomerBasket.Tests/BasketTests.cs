using System.Collections.Generic;
using CustomerBasket.Contracts;
using CustomerBasket.Offers;
using Machine.Specifications;

namespace CustomerBasket.Tests
{
    public class BasketTests
    {
        public class Context
        {
            protected static Basket _basket;

            Establish context = () =>
            {
                _basket = new Basket(new List<ICheckOffer>
                {
                    new BreadAndButterOffer(),
                    new MilkOffer()
                });
            };
        }

        [Subject(typeof(Basket))]
        public class When_the_basket_has_1_milk : Context
        {
            Because of = () => _basket.Add(new Product(Product.Milk, 1.15m));

            It should_have_a_total_of_the_cost_of_a_product = () => _basket.Total().ShouldEqual(1.15m);
        }

        [Subject(typeof (Basket))]
        public class When_the_basket_has_1_butter_1_bread_and_1_milk : Context
        {
            Because of = () =>
            {
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Bread, 1.00m));
                _basket.Add(new Product(Product.Butter, 0.80m));
            };

            It should_total_all_the_costs_of_the_products = () => _basket.Total().ShouldEqual(1.00m + 0.80m + 1.15m);
        }

        public class When_the_basket_has_2_butter_and_1_bread : Context
        {
            private static decimal _total;

            Establish context = () =>
            {
                _basket.Add(new Product(Product.Butter, 0.80m));
                _basket.Add(new Product(Product.Butter, 0.80m));
                _basket.Add(new Product(Product.Bread, 1.00m));
            };

            Because of = () => _total = _basket.Total();

            It should_have_1_bread_and_butter_discount = () => _total.ShouldEqual(0.80m + 0.80m + 1.00m / 2);
        }

        public class When_the_basket_has_2_butter_and_2_bread : Context
        {
            private static decimal _total;

            Establish context = () =>
            {
                _basket.Add(new Product(Product.Butter, 0.80m));
                _basket.Add(new Product(Product.Butter, 0.80m));
                _basket.Add(new Product(Product.Bread, 1.00m));
                _basket.Add(new Product(Product.Bread, 1.00m));
            };

            Because of = () => _total = _basket.Total();

            It should_have_only_have_1_bread_and_butter_discount = () => _total.ShouldEqual(0.80m + 0.80m + 1.00m + 1.00m / 2);
        }

        public class When_the_basket_has_4_milk : Context
        {
            private static decimal _total;

            Establish context = () =>
            {
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
            };

            Because of = () => _total = _basket.Total();

            It should_have_the_4th_free = () => _total.ShouldEqual(1.15m + 1.15m + 1.15m);
        }

        public class When_the_basket_has_2_butter_1_bread_and_8_milk : Context
        {
            private static decimal _total;

            Establish context = () =>
            {

                _basket.Add(new Product(Product.Butter, 0.80m));
                _basket.Add(new Product(Product.Butter, 0.80m));
                _basket.Add(new Product(Product.Bread, 1.00m));
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
                _basket.Add(new Product(Product.Milk, 1.15m));
            };

            Because of = () => _total = _basket.Total();

            It should_have_the_4th_free = () => _total.ShouldEqual(0.80m * 2 + 1.00m / 2 + 1.15m * 6);
        }


    }
}
