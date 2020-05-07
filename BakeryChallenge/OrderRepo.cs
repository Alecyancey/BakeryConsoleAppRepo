using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryChallenge
{
    public class OrderRepo
    {
        private readonly List<Order> _orders = new List<Order>();

        public bool AddOrder(Order order)
        {
            int directoryLength = _orders.Count();
            _orders.Add(order);
            bool wasAdded = directoryLength + 1 == _orders.Count();
            return wasAdded;
        }
        public List<Order> GetAllOrders()
        {
            return _orders;
        }
        public Order GetOrderByCustomerName(string customerName)
        {
            foreach (Order order in _orders)
            {
                if (order.CustomerName.ToLower() == customerName.ToLower())
                {
                    return order;
                }
            }
            return null;
        }
        public bool UpdateOrder(string originalCustomerName, Order updatedOrder)
        {
            Order oldOrder = GetOrderByCustomerName(originalCustomerName);
            if(oldOrder != null)
            {
                oldOrder.CustomerName = updatedOrder.CustomerName;
                oldOrder.Product = updatedOrder.Product;
                oldOrder.ProductQuantity = updatedOrder.ProductQuantity;
                return true;
            }
            return false;
        }
        public bool DeleteOrder(string customerName)
        {
            Order order = GetOrderByCustomerName(customerName);
            bool orderDeleted = _orders.Remove(order);
            return orderDeleted;
        }
    }
}
//$500.01 for bread, $2000 for cake, $200.10 for pasteries, and $851.5 for pies. 