namespace CustomerBasket.Contracts
{
    public abstract class BasketItem
    {
        public string Name { get; private set; }
        public decimal Cost { get; private set; }

        protected BasketItem(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}