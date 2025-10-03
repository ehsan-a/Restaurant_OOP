// See https://aka.ms/new-console-template for more information
using Restaurant_OOP;
using System;

Restaurant restaurant1 = new Restaurant("Chiken Family", "Fast Food", "Tehran, Janbazan Street");
Personnel pl1 = new Personnel("Ali", "Mashhadi", "0088645328", "Tehran, Madaen", "ali_m", "1234", true);
Personnel pl2 = new Personnel("Hossein", "Moradi", "8872649809", "Tehran, Resalat", "hossein_m", "1234", false);
Personnel pl3 = new Personnel("Navid", "Mansori", "2247652908", "Tehran, Velenjak", "navid_m", "1234", false);
Menu mn1 = new Menu(1, "Chiken Sokhari", "Chiken", 400000);
Menu mn2 = new Menu(2, "Chiken Pizza", "Chiken", 500000);
Menu mn3 = new Menu(3, "Chiken Sandwich", "Chiken", 300000);
Customer cu1 = new Customer(1, "Ehsan", "Arefazdeh", "0094264784", "Tehran, Sabalan St.", "ehsan", "1234");
Customer cu2 = new Customer(2, "Mehran", "Ghasemi", "003446784", "Tehran, Narmak St.", "mehran", "1234");
Customer cu3 = new Customer(3, "Salar", "Azimi", "0023454784", "Tehran, Heravi St.", "salar", "1234");
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
bool isRun = true;
Console.WriteLine(restaurant1);
Responsive.Login(restaurant1);
do
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("[1]Menu / [2]Add Order / [3]Orders / [4]Profile / [5]+Balance / [6]Exit -- Choose: ");
    Console.ResetColor();
    switch (Console.ReadLine())
    {
        case "1":
            Responsive.GetMenu(restaurant1);
            break;
        case "2":
            Responsive.AddOrder(restaurant1);
            break;
        case "3":
            Responsive.GetOrders(restaurant1);
            break;
        case "4":
            Responsive.GetProfile(restaurant1);
            break;
        case "5":
            Responsive.ChargeBalance(restaurant1);
            break;
        case "6":
            isRun = false;
            break;
    }
}
while (isRun);
