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
            printReceipt.Append("=====老王超市，值得信赖======\n\n");
            printReceipt.Append(order.Date.ToString("yyyy年M月d日"))
                .Append("，")
                .Append(dayOfWeek[int.Parse(order.Date.DayOfWeek.ToString("D"))])
                .Append("\n\n");
        }
        
        private void PrintLineItems(StringBuilder printReceipt)
        {
            double totSalesTx = 0d;
            double totalPrice = 0d;

            foreach (LineItem lineItem in order.LineItemList)
            {
                printReceipt.Append(lineItem.Description);
                printReceipt.Append(',');
                printReceipt.Append(lineItem.Price);
                printReceipt.Append('*');
                printReceipt.Append(lineItem.Quantity);
                printReceipt.Append(',');
                printReceipt.Append(lineItem.TotalPrice());
                printReceipt.Append('\n');

                double salesTax = lineItem.TotalPrice() * .10;
                totSalesTx += salesTax;

                totalPrice += lineItem.TotalPrice() + salesTax;
            }

            
            printReceipt.Append("-----------------------\n");
            
            printReceipt.Append("税额:").Append('\t').Append(totSalesTx).Append('\n');

            printReceipt.Append("总价:").Append('\t').Append(totalPrice);
        }
    }
}