using CustomerBasket.Contracts;

namespace CustomerBasket
{
    public class Product : BasketItem
    {
        public const string Milk = "Milk";
        public const string Bread = "Bread";
        public const string Butter = "Butter";

        public Product(string name, decimal cost) : base(name, cost) {}

        protected bool Equals(Product other)
        {
            return string.Equals(Name, other.Name) && Cost == other.Cost;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ Cost.GetHashCode();
            }
        }
    }
}