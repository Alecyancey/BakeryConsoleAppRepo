using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryChallenge
{
    public enum ProductType { Bread, Cake, Pastry, Pie }
    public class Product
    {
        public ProductType ProductType { get; set; }
        public double Price { get; set; }
        public Product(ProductType productType, double price)
        {
            ProductType = productType;
            Price = price;
        }
    }
}
