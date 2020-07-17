using System;
using System.Text;

namespace refactor_gym_warmup_2020.cashier
{
    public class OrderReceipt
    {
        private Order order;
        private StringBuilder printReceipt;

        public OrderReceipt(Order order, StringBuilder printReceipt)
        {
            this.order = order;
            this.printReceipt = printReceipt;
        }
        
        public string PrintReceipt()
        {
            PrintHeads();

            PrintLineItems();

            PrintTotalInfo();

            return printReceipt.ToString();
        }

        private void PrintHeads()
        {
            string[] dayOfWeek = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            printReceipt.Append("=====老王超市，值得信赖======\n\n")
                .Append(order.Date.ToString("yyyy年M月d日"))
                .Append("，")
                .Append(dayOfWeek[int.Parse(order.Date.DayOfWeek.ToString("D"))])
                .Append("\n\n");
        }
        
        private void PrintLineItems()
        {
            order.LineItemList.ForEach(lineItem =>
            {
                printReceipt.Append(lineItem.Description).Append(',');
                printReceipt.Append(lineItem.Price).Append('*');
                printReceipt.Append(lineItem.Quantity).Append(',');
                printReceipt.Append(lineItem.TotalPrice()).Append('\n');

                order.TotalSalesTax += lineItem.TotalPrice() * .10;

                order.TotalPrice += lineItem.TotalPrice() * 1.10;
            });
        }

        private void PrintTotalInfo()
        {
            printReceipt.Append("-----------------------\n");

            printReceipt.Append("税额:").Append('\t').Append(order.TotalSalesTax).Append('\n');

            CalculateDiscount();

            printReceipt.Append("总价:").Append('\t').Append(order.TotalPrice);
        }

        private void CalculateDiscount()
        {
            if (order.Date.DayOfWeek == DayOfWeek.Wednesday)
            {
                order.Discount = order.TotalPrice * .02;
                printReceipt.Append("折扣:").Append('\t').Append(order.Discount).Append('\n');
                order.TotalPrice -= order.Discount;
            }
        }
    }
}