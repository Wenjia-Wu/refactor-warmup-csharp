namespace refactor_gym_warmup_2020.cashier
{
    public class LineItem
    {
        private string description;
        private double price;
        private int quantity;

        public LineItem(string description, double price, int quantity)
        {
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }

        public string GetDescription()
        {
            return description;
        }

        public double GetPrice()
        {
            return price;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public double TotalPrice()
        {
            return price * quantity;
        }
    }
}