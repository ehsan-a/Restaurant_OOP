// See https://aka.ms/new-console-template for more information
using Restaurant_OOP;
using System;

Restaurant restaurant1 = new Restaurant("Chiken Family", "Fast Food", "Tehran, Janbazan Street");
Personnel pl1 = new Personnel("Ali", "Mashhadi", "0088645328", "Tehran, Madaen");
Personnel pl2 = new Personnel("Hossein", "Moradi", "8872649809", "Tehran, Resalat");
Personnel pl3 = new Personnel("Navid", "Mansori", "2247652908", "Tehran, Velenjak");
Menu mn1 = new Menu("Chiken Sokhari", "Chiken", 400000);
Menu mn2 = new Menu("Chiken Pizza", "Chiken", 500000);
Menu mn3 = new Menu("Chiken Sandwich", "Chiken", 300000);
Customer cu1 = new Customer("Ehsan", "Arefazdeh", "0094264784", "Tehran, Sabalan St.");
Customer cu2 = new Customer("Mehran", "Ghasemi", "003446784", "Tehran, Narmak St.");
Customer cu3 = new Customer("Salar", "Azimi", "0023454784", "Tehran, Heravi St.");
Order or1 = new Order(1, DateTime.Now);
restaurant1.AddMenu(mn1);
restaurant1.AddMenu(mn2);
restaurant1.AddMenu(mn3);
restaurant1.ChargeFoodQty(mn1, 30);
restaurant1.ChargeFoodQty(mn2, 30);
restaurant1.ChargeFoodQty(mn3, 30);
restaurant1.AddPersonnel(pl1);
restaurant1.AddPersonnel(pl2);
restaurant1.AddPersonnel(pl3);
restaurant1.AddCustomer(cu1);
restaurant1.AddCustomer(cu2);
restaurant1.AddCustomer(cu3);
restaurant1.ChargeBalance(cu1, 5000000);
restaurant1.AddItemOrder(or1, mn1, 2);
restaurant1.AddItemOrder(or1, mn2, 3);
restaurant1.AddOrder(cu1, or1);
restaurant1.ChangeStatus(or1, Order.OrderStatus.Sending);
//----------------------------------
Console.WriteLine("---------------------------- Restaurant Information -----------------------------");
Console.WriteLine(restaurant1);
Console.WriteLine();
Console.WriteLine("-------------------------------------- Menu -------------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"{"#".PadRight(4)}{"FOOD NAME".PadRight(27)}{"DESCRIPTION".PadRight(35)}{"PRICE".PadRight(10)}{"QTY".PadLeft(5)}");
Console.ResetColor();
int counter = 1;
foreach (var item in restaurant1.GetMenu())
{
    Console.WriteLine($"{counter.ToString().PadRight(4)}{item}");
    counter++;
}
counter = 1;
Console.WriteLine();
Console.WriteLine("----------------------------------- Personnel -----------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"{"#".PadRight(4)}{"FIRST NAME".PadRight(12)}{"LAST NAME".PadRight(15)}{"ID NUMBER".PadRight(11)}{"ADDRESS".PadLeft(39)}");
Console.ResetColor();
foreach (var item in restaurant1.GetPersonnel())
{
    Console.WriteLine($"{counter.ToString().PadRight(4)}{item}");
    counter++;
}
counter = 1;
Console.WriteLine();
Console.WriteLine("------------------------------------ Customer -----------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"{"#".PadRight(4)}{"FIRST NAME".PadRight(12)}{"LAST NAME".PadRight(12)}{"ID NUMBER".PadRight(11)}{"ADDRESS".PadRight(26)}{"ORDERS".PadRight(3)}{"BALANCE".PadLeft(10)}");
Console.ResetColor();
foreach (var item in restaurant1.GetCustomer())
{
    Console.WriteLine($"{counter.ToString().PadRight(4)}{item}");
    counter++;
}
counter = 1;
Console.WriteLine();
Console.WriteLine("------------------------------------- Order -------------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"{"#".PadRight(4)}{"ID".PadRight(4)}{"CUSTOMER".PadRight(24)}{"DATE/TIME".PadRight(30)}{"STATUS".PadRight(10)}{"SUM".PadLeft(9)}");
Console.ResetColor();
foreach (var item in restaurant1.GetOrder(cu1))
{
    Console.WriteLine($"{counter.ToString().PadRight(4)}{item}");
    counter++;
}
counter = 1;
Console.WriteLine();
Console.WriteLine("--------------------------------- Order Detail ----------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"{"#".PadRight(4)}{"FOOD NAME".PadRight(30)}{"PRICE".PadRight(17)}{"QTY".PadRight(15)}{"SUM".PadLeft(15)}");
Console.ResetColor();
foreach (var item in restaurant1.GetOrderDetail(or1))
{
    Console.WriteLine($"{counter.ToString().PadRight(4)}{item}");
    counter++;
}
