using System.Text;

namespace refactor_gym_warmup_2020.cashier
{
    /**
 * OrderReceipt prints the details of order including customer name, address, description, quantity,
 * price and amount. It also calculates the sales tax @ 10% and prints as part
 * of order. It computes the total order amount (amount of individual lineItems +
 * total sales tax) and prints it.
 *
 */
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
                printReceipt.Append('\t');
                printReceipt.Append(lineItem.Price);
                printReceipt.Append('\t');
                printReceipt.Append(lineItem.Quantity);
                printReceipt.Append('\t');
                printReceipt.Append(lineItem.TotalPrice());
                printReceipt.Append('\n');

                double salesTax = lineItem.TotalPrice() * .10;
                totSalesTx += salesTax;

                totalPrice += lineItem.TotalPrice() + salesTax;
            }

            printReceipt.Append("Sales Tax").Append('\t').Append(totSalesTx);

            printReceipt.Append("Total Amount").Append('\t').Append(totalPrice);
        }
    }
}