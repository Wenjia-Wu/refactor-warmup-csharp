using System;
using System.Collections.Generic;
using refactor_gym_warmup_2020.cashier;
using Xunit;

namespace refactor_gym_warmup_test.cashier
{
    public class OrderReceiptTest
    {
        [Fact]
        public void ShouldPrintCustomerInformationOnOrder()
        {
            Order order = new Order(new List<LineItem>(), Convert.ToDateTime("2020-7-16"));
            OrderReceipt receipt = new OrderReceipt(order);

            String output = receipt.PrintReceipt();
            
            Assert.Contains("=====老王超市，值得信赖======\n\n", output);
            Assert.Contains("2020年7月16日，星期四\n\n", output);
        }

        [Fact]
        public void ShouldPrintLineItemAndSalesTaxInformation()
        {
            List<LineItem> lineItems = new List<LineItem>()
            {
                new LineItem("milk", 10.0, 2),
                new LineItem("biscuits", 5.0, 5),
                new LineItem("chocolate", 20.0, 1),
            };
            OrderReceipt receipt = new OrderReceipt(new Order(lineItems, DateTime.UtcNow.Date));

            String output = receipt.PrintReceipt();

            Assert.Contains("milk\t10\t2\t20\n", output);
            Assert.Contains("biscuits\t5\t5\t25\n", output);
            Assert.Contains("chocolate\t20\t1\t20\n", output);
            Assert.Contains("Sales Tax\t6.5", output);
            Assert.Contains("Total Amount\t71.5", output);
        }
    }
}