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
        
        public string CaculatePrintReceipt()
        {
            StringBuilder printReceipt = new StringBuilder();

            // print headers
            printReceipt.Append("======Printing Orders======\n");

            // print date, bill no, customer name
//        output.Append("Date - " + order.getDate();
            printReceipt.Append(order.GetCustomerName());
            printReceipt.Append(order.GetCustomerAddress());
//        output.Append(order.getCustomerLoyaltyNumber());

            // prints lineItems
            double totSalesTx = 0d;
            double totalPrice = 0d;

            foreach (LineItem lineItem in order.GetLineItems())
            {
                printReceipt.Append(lineItem.GetDescription());
                printReceipt.Append('\t');
                printReceipt.Append(lineItem.GetPrice());
                printReceipt.Append('\t');
                printReceipt.Append(lineItem.GetQuantity());
                printReceipt.Append('\t');
                printReceipt.Append(lineItem.TotalPrice());
                printReceipt.Append('\n');

                // calculate sales tax @ rate of 10%
                double salesTax = lineItem.TotalPrice() * .10;
                totSalesTx += salesTax;

                // calculate total amount of lineItem = price * quantity + 10 % sales tax
                totalPrice += lineItem.TotalPrice() + salesTax;
            }

            // prints the state tax
            printReceipt.Append("Sales Tax").Append('\t').Append(totSalesTx);

            // print total amount
            printReceipt.Append("Total Amount").Append('\t').Append(totalPrice);
            return printReceipt.ToString();
        }
    }
}