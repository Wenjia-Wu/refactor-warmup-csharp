using System;
using System.Collections.Generic;
using System.Text;
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
            OrderReceipt receipt = new OrderReceipt(order, new StringBuilder());

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
            OrderReceipt receipt = new OrderReceipt(new Order(lineItems, Convert.ToDateTime("2020-7-16")), new StringBuilder());

            String output = receipt.PrintReceipt();

            Assert.Contains("milk,10*2,20\n", output);
            Assert.Contains("biscuits,5*5,25\n", output);
            Assert.Contains("chocolate,20*1,20\n", output);
            Assert.Contains("-----------------------\n", output);
            Assert.Contains("税额:\t6.5\n", output);
            Assert.Contains("总价:\t71.5", output);
        }
        
        [Fact]
        public void ShouldDiscountAndPrintDiscountInfoWhenWednesday()
        {
            List<LineItem> lineItems = new List<LineItem>()
            {
                new LineItem("milk", 10.0, 2),
                new LineItem("biscuits", 5.0, 5),
                new LineItem("chocolate", 20.0, 1),
            };
            OrderReceipt receipt = new OrderReceipt(new Order(lineItems, Convert.ToDateTime("2020-7-15")), new StringBuilder());

            String output = receipt.PrintReceipt();

            Assert.Contains("折扣:\t1.43", output);
            Assert.Contains("总价:\t70.07", output);
        }
    }
}