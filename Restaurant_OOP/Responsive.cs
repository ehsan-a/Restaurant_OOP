using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class Responsive
    {
        public static void ErrorFormat(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void Login(Restaurant restaurant)
        {
            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                if (restaurant.Login(username, password))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Welcome {restaurant.user.FirstName} {restaurant.user.LastName} to {restaurant.Name}");
                    Console.ResetColor();
                    break;
                }
                ErrorFormat("Password or Username is not valid!");
            }
        }
        public static void ChargeBalance(Restaurant restaurant)
        {
            do
            {
                Console.Write("Enter Amount ([c]Cancel): ");
                string input = Console.ReadLine();
                if (input == "c") break;
                if (decimal.TryParse(input, out decimal amount) && amount > 0)
                {
                    restaurant.AddBalance(new Balance(restaurant.user.Id, amount, DateTime.Now));
                    Console.WriteLine("Charge is Successfull! Balance: " + restaurant.GetBalance(restaurant.user));
                    break;
                }
                else
                {
                    ErrorFormat("The input value is incorrect");
                }
            } while (true);
        }
        public static void GetMenu(Restaurant restaurant)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"#".PadRight(4)}{"FOOD NAME".PadRight(27)}{"DESCRIPTION".PadRight(35)}{"PRICE".PadRight(10)}{"QTY".PadLeft(5)}");
            Console.ResetColor();
            int counter = 1;
            foreach (var item in restaurant.GetMenu())
            {
                Console.WriteLine($"{counter.ToString().PadRight(4)}{item}");
                counter++;
            }
            Console.WriteLine();
        }
        public static void GetOrderDetail(Restaurant restaurant, Order order)
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"#".PadRight(4)}{"FOOD NAME".PadRight(30)}{"PRICE".PadRight(17)}{"QTY".PadRight(15)}{"SUM".PadLeft(15)}");
            Console.ResetColor();
            foreach (var item in restaurant.GetOrderDetail(order))
            {
                Console.WriteLine($"{counter.ToString().PadRight(4)}{item}");
                counter++;
            }
            Console.WriteLine();
        }
        public static void AddOrder(Restaurant restaurant)
        {
            int id;
            if (restaurant.Orders.Count == 0)
                id = 1;
            else
                id = restaurant.Orders[restaurant.Orders.Count - 1].Id + 1;
            Order or = new Order(id, restaurant.user.Id, DateTime.Now);
            GetMenu(restaurant);
            int counter = 1;
            bool isFinish = false;
            do
            {
                while (true)
                {
                    Console.Write($"Enter Number of Food ({counter}) - ([f]Finish): ");
                    string input = Console.ReadLine();
                    if (input == "f" && restaurant.Items.Count(x => x.OrderId == or.Id) != 0)
                    {
                        isFinish = true;
                        break;
                    }
                    else if (input == "f" && restaurant.Items.Count(x => x.OrderId == or.Id) == 0)
                    {
                        ErrorFormat($"Your Order list is Empty!");
                        continue;
                    }
                    if (int.TryParse(input, out int number) && number <= restaurant.Menus.Count)
                    {
                        Menu menu = restaurant.Menus[number - 1];
                        if (restaurant.Items.FirstOrDefault(x => x.OrderId == or.Id && x.FoodId == menu.Id) != null)
                        {
                            ErrorFormat($"This food is on the list!");
                            continue;
                        }
                        Console.Write("Enter Qty of Food: ");
                        if (int.TryParse(Console.ReadLine(), out int qty) && qty <= restaurant.GetFoodQty(menu))
                        {
                            restaurant.AddItemOrder(new OrderItem(or.Id, menu.Id, qty));
                            break;
                        }
                        else
                        {
                            ErrorFormat($"Out Of Range Qty[1 - {restaurant.GetFoodQty(menu)}]");
                        }
                    }
                    else
                    {
                        ErrorFormat($"Out Of Range Number[1 - {restaurant.Menus.Count}]");
                    }
                }
                counter++;
                if (isFinish) break;
            } while (true);
            GetOrderDetail(restaurant, or);
            Console.Write("Confirm your order [y]Yes [n]No: ");
            if (Console.ReadLine() == "y")
            {
                restaurant.AddOrder(or);
                Console.WriteLine("Your order successfuly registered!");
            }
        }
        public static void GetOrders(Restaurant restaurant)
        {
            if (restaurant.Orders.FirstOrDefault(x => x.CustomerId == restaurant.user.Id) != null)
            {
                int counter = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{"#".PadRight(4)}{"ID".PadRight(4)}{"CUSTOMER".PadRight(24)}{"DATE/TIME".PadRight(30)}{"STATUS".PadRight(10)}{"SUM".PadLeft(9)}");
                Console.ResetColor();
                foreach (var item in restaurant.GetOrder(restaurant.user))
                {
                    Console.WriteLine($"{counter.ToString().PadRight(4)}{item}");
                    counter++;
                }
                counter = 1;
                Console.WriteLine();
                do
                {
                    Console.Write("Enter Number of order for detail ([c]Close): ");
                    string input = Console.ReadLine();
                    if (input == "c") break;
                    if (int.TryParse(input, out int index))
                    {
                        if (index > 0 && index <= restaurant.GetOrder(restaurant.user).ToList().Count)
                            GetOrderDetail(restaurant, restaurant.Orders.Where(x => x.CustomerId == restaurant.user.Id).ToList()[(int.Parse(input) - 1)]);
                        else
                            ErrorFormat($"Out Of Range Number[1 - {restaurant.GetOrder(restaurant.user).ToList().Count}]");
                    }
                    else
                        ErrorFormat($"Not a Number[1 - {restaurant.GetOrder(restaurant.user).ToList().Count}]");
                } while (true);
            }
            else
            {
                ErrorFormat("You do not have an order!");
            }
        }
        public static void GetProfile(Restaurant restaurant)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"FIRST NAME".PadRight(12)}{"LAST NAME".PadRight(12)}{"ID NUMBER".PadRight(15)}{"ADDRESS".PadRight(26)}{"ORDERS".PadRight(3)}{"BALANCE".PadLeft(10)}");
            Console.ResetColor();
            Console.WriteLine($"{restaurant.user.FirstName.PadRight(12)}{restaurant.user.LastName.PadRight(12)}{restaurant.user.IdNumber.PadRight(15)}{restaurant.user.Address.PadRight(26)}{restaurant.Orders.Count(x => x.CustomerId == restaurant.user.Id).ToString().PadRight(3)}{restaurant.GetBalance(restaurant.user).ToString().PadLeft(13)}");
            Console.WriteLine();
        }
    }
}
