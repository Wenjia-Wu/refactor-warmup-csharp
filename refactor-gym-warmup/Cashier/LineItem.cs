namespace refactor_gym_warmup_2020.cashier
{
    public class LineItem
    {
        public string Description { get; }
        public double Price { get; }
        public int Quantity { get; }

        public LineItem(string description, double price, int quantity)
        {
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public double TotalPrice()
        {
            return Price * Quantity;
        }
    }
}