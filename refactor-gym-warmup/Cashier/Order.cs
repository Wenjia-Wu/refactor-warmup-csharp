using System.Collections.Generic;

namespace refactor_gym_warmup_2020.cashier
{
    public class Order
    {
        string customerName;
        string customerAddress;
        List<LineItem> lineItemList;

        public Order(string customerName, string customerAddress, List<LineItem> lineItemList)
        {
            this.customerName = customerName;
            this.customerAddress = customerAddress;
            this.lineItemList = lineItemList;
        }

        public string GetCustomerName()
        {
            return customerName;
        }

        public string GetCustomerAddress()
        {
            return customerAddress;
        }

        public List<LineItem> GetLineItems()
        {
            return lineItemList;
        }
    }
}