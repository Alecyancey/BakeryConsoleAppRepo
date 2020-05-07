using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryChallenge.UI
{
    public class ProgramUI
    {
        private readonly OrderRepo _orderRepo = new OrderRepo();
        private readonly List<Product> _products = new List<Product>();
        public void Run()
        {
            SeedProducts();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select an option number:\n" +
                    "1. Add An Order\n" +
                    "2. Get All Orders\n" +
                    "3. Update An Order\n" +
                    "4. Delete An Order\n" +
                    "5. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        AddAnOrder();
                        break;
                    case "2":
                        DisplayAllOrders();
                        break;
                    case "3":
                        UpdateAnOrder();
                        break;
                    case "4":
                        DeleteAnOrder();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddAnOrder()
        {
            Order newOrder = new Order();
            Console.WriteLine("Please enter the customer's name");
            newOrder.CustomerName = Console.ReadLine().Trim();

            Console.WriteLine("Please enter product type number:\n" +
                "1. Bread\n" +
                "2. Cake\n" +
                "3. Pastry\n" +
                "4. Pie");
            string userInput = Console.ReadLine();
            userInput = userInput.Replace(" ", "");
            userInput = userInput.Trim();

            switch (userInput)
            {
                case "1":
                    newOrder.Product = _products[0];
                    break;
                case "2":
                    newOrder.Product = _products[1];
                    break;
                case "3":
                    newOrder.Product = _products[2];
                    break;
                case "4":
                    newOrder.Product = _products[3];
                    break;
            }

            Console.WriteLine("Please enter the quantity of the product you'd like to order");
            string quantityString = Console.ReadLine();
            newOrder.ProductQuantity = Convert.ToInt32(quantityString);

            _orderRepo.AddOrder(newOrder);
        }
        public void DisplayAllOrders()
        {
            Console.Clear();

            List<Order> orders = _orderRepo.GetAllOrders();

            foreach (Order order in orders)
            {
                Console.WriteLine($"Customer Name: {order.CustomerName}\n" +
                    $"Product: {order.Product.ProductType}\n" +
                    $"Quantity: {order.ProductQuantity}\n" +
                    $"Total Cost: {order.TotalCost}");
            }

            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        public void UpdateAnOrder()
        {
            Console.WriteLine("Enter name of customer whose order you'd like to update:");
            string customerName = Console.ReadLine();
            Order existingOrder = _orderRepo.GetOrderByCustomerName(customerName);

            if (existingOrder == null)
            {
                Console.WriteLine("There is no order under that name");
                Console.ReadKey();
            }
            else
            {
                Order order = new Order();
                Console.WriteLine($"The customer name is {existingOrder.CustomerName}, please enter a new name or retype the current name");
                order.CustomerName = Console.ReadLine();

                Console.WriteLine($"The Product Type is {existingOrder.Product.ProductType}, please enter the number for a new product type or re-enter the current product type number\n" +
                    $"1.Bread\n" +
                    $"2. Cake\n" +
                    $"3. Pastry\n" +
                    $"4. Pie");
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        order.Product = _products[0];
                        break;
                    case "2":
                        order.Product = _products[1];
                        break;
                    case "3":
                        order.Product = _products[2];
                        break;
                    case "4":
                        order.Product = _products[3];
                        break;
                }

                Console.WriteLine($"The product quantity is {existingOrder.ProductQuantity}, please enter a new quantity or re-enter the current quantity");
                string quantityString = Console.ReadLine().Trim();
                order.ProductQuantity = Convert.ToInt32(quantityString);

                _orderRepo.UpdateOrder(existingOrder.CustomerName, order);
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public void DeleteAnOrder()
        {
            Console.WriteLine("Please enter the name of the customer who's order you'd like to delete");
            string customerName = Console.ReadLine().Trim();
            bool deletedResult = _orderRepo.DeleteOrder(customerName);
            if (deletedResult == true)
            {
                Console.WriteLine("Order deleted. Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Order deletion failed. Press and key to continue....");
                Console.ReadKey();
            }
        }
        public void SeedProducts()
        {
            Product bread = new Product(ProductType.Bread, 500.01);
            _products.Add(bread);
            Product cake = new Product(ProductType.Cake, 2000);
            _products.Add(cake);
            Product pastry = new Product(ProductType.Pastry, 200.10);
            _products.Add(pastry);
            Product pie = new Product(ProductType.Pastry, 851.5);
            _products.Add(pie);
        }
    }
}
