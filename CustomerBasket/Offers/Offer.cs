using CustomerBasket.Contracts;

namespace CustomerBasket.Offers
{
    public class Offer : BasketItem
    {
        public const string HalfPriceBread = "HalfPriceBread";
        public const string FreeMilk = "FreeMilk";

        public Offer(string name, decimal cost) : base(name, cost) {}

        protected bool Equals(Offer other)
        {
            return string.Equals(Name, other.Name) && Cost == other.Cost;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Offer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ Cost.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Name + ", " + Cost;
        }
    }
}