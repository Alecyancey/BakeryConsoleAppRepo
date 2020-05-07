using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository
    {
        protected List<Customer> _customers;
 
        public Customer CreateCustomer()
        {

            DateTime enrolled = new DateTime(2018, 1, 1);
            Customer johnSmith = new Customer(1, "smith", 20, enrolled);
            return johnSmith;
        }
        public List<Customer> AddCustomerToList(Customer customer)
        {

            List<Customer> customerList = new List<Customer>();
            _customers = customerList.Add(customer);
            return customerList;
        }
    }
}
