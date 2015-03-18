using Machine.Specifications;

namespace CustomerBasket.Tests
{
    public class ProductTests
    {
        [Subject(typeof(Product))]
        public class Given_a_product
        {
            private static Product _milk;
            private const string Name = "Milk";
            private const decimal Cost = 0.8m;

            Because of = () => _milk = new Product(Name, Cost);

            It should_have_name = () => _milk.Name.ShouldEqual(Name);
            It should_have_cost = () => _milk.Cost.ShouldEqual(Cost);
        }
    }
}
