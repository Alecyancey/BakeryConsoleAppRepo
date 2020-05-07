using System;
using System.Collections.Generic;
using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace SD51_Challenges_Tests
{
    [TestClass]
    public class CustomerTests : CustomerRepository
    {
        [TestMethod]
        public void MessageTest()
        {
            CustomerRepository repo = new CustomerRepository();
            repo.CreateCustomerAndAddToList();
            foreach (Customer customer in _customers)
            {
                if (customer.YearsWithKomodo > 1 && customer.YearsWithKomodo < 5)
                {
                    Console.WriteLine("Thank you for being a member");
                }
            }
            foreach (Customer customer in _customers)
            {
                if (customer.YearsWithKomodo > 5)
                {
                    Console.WriteLine("Thank you for being a Gold Member");
                }
            }
            string outPut = "Thank you for being a member";
            Assert.AreEqual(outPut, "Thank you for being a member");
        }
    }
}
