using System;
using System.Collections.Generic;

namespace refactor_gym_warmup_2020.cashier
{
    public class Order
    {
        public DateTime Date { get; }
        public List<LineItem> LineItemList { get; }
        public double TotalSalesTax { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }

        public Order(List<LineItem> lineItemList, DateTime date)
        {
            LineItemList = lineItemList;
            Date = date;
        }
    }
}