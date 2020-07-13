using System.Collections.Generic;

namespace refactor_gym_warmup_2020.cashier
{
    public class Order
    {
        public string CustomerName { get; }
        public string CustomerAddress { get; }
        public List<LineItem> LineItemList { get; }

        public Order(string customerName, string customerAddress, List<LineItem> lineItemList)
        {
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            LineItemList = lineItemList;
        }
    }
}