using System;
using System.Text;

namespace refactor_gym_warmup_2020.cashier
{
    public class OrderReceipt
    {
        private Order order;

        public OrderReceipt(Order order)
        {
            this.order = order;
        }
        
        public string PrintReceipt()
        {
            StringBuilder printReceipt = new StringBuilder();

            PrintHeads(printReceipt);

            PrintLineItems(printReceipt);

            return printReceipt.ToString();
        }

        private void PrintHeads(StringBuilder printReceipt)
        {
            string[] dayOfWeek = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            printReceipt.Append("=====老王超市，值得信赖======\n\n")
                .Append(order.Date.ToString("yyyy年M月d日"))
                .Append("，")
                .Append(dayOfWeek[int.Parse(order.Date.DayOfWeek.ToString("D"))])
                .Append("\n\n");
        }
        
        private void PrintLineItems(StringBuilder printReceipt)
        {
            double totSalesTx = 0d;
            double totalPrice = 0d;
            
            order.LineItemList.ForEach(lineItem =>
            {
                printReceipt.Append(lineItem.Description).Append(',');
                printReceipt.Append(lineItem.Price).Append('*');
                printReceipt.Append(lineItem.Quantity).Append(',');
                printReceipt.Append(lineItem.TotalPrice()).Append('\n');

                double salesTax = lineItem.TotalPrice() * .10;
                totSalesTx += salesTax;

                totalPrice += lineItem.TotalPrice() + salesTax;
            });

            totalPrice = PrintTotalInfo(printReceipt, totSalesTx, totalPrice);
        }

        private double PrintTotalInfo(StringBuilder printReceipt, double totSalesTx, double totalPrice)
        {
            printReceipt.Append("-----------------------\n");

            printReceipt.Append("税额:").Append('\t').Append(totSalesTx).Append('\n');

            totalPrice = CaculateDiscount(printReceipt, totalPrice);

            printReceipt.Append("总价:").Append('\t').Append(totalPrice);
            return totalPrice;
        }

        private double CaculateDiscount(StringBuilder printReceipt, double totalPrice)
        {
            if (order.Date.DayOfWeek == DayOfWeek.Wednesday)
            {
                double discount = totalPrice * .02;
                printReceipt.Append("折扣:").Append('\t').Append(discount).Append('\n');
                totalPrice -= discount;
            }

            return totalPrice;
        }
    }
}