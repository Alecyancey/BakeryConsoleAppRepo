using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryChallenge
{
    //Each Order will need to have the associated Product, Customer Name, the ordered batch size, and the total order cost.
    public class Order
    {
        public string CustomerName { get; set; }
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }
        public double TotalCost
        {
            get
            {
                double totalCost = 100 + (Product.Price * ProductQuantity);
                return totalCost;
            }
        }

        public Order() { }
        public Order(Product product, int productQuantity, string customerName)
        {
            Product = product;
            ProductQuantity = productQuantity;
            CustomerName = customerName;
        }
    }

}
