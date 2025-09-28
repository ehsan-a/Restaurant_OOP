// See https://aka.ms/new-console-template for more information
using Restaurant_OOP;

Restaurant restaurant1 = new Restaurant("Chiken Family", "Fast Food", "Tehran, Janbazan Street");
Personnel pl1 = new Personnel("Ali", "Mashhadi", "0088645328", "Tehran, Madaen");
Personnel pl2 = new Personnel("Hossein", "Moradi", "8872649809", "Tehran, Resalat");
Personnel pl3 = new Personnel("Navid", "Mansori", "2247652908", "Tehran, Velenjak");
Menu mn1 = new Menu("Chiken Sokhari", "Chiken", 400000, 40);
Menu mn2 = new Menu("Chiken Pizza", "Chiken", 500000, 30);
Menu mn3 = new Menu("Chiken Sandwich", "Chiken", 300000, 40);
Customer cu1 = new Customer("Ehsan", "Arefazdeh", "0094264784", "Tehran, Sabalan St.");
Customer cu2 = new Customer("Mehran", "Ghasemi", "003446784", "Tehran, Narmak St.");
Customer cu3 = new Customer("Salar", "Azimi", "0023454784", "Tehran, Heravi St.");
Order or1 = new Order(1, DateTime.Now, Order.OrderStatus.Preparation);
restaurant1.AddMenu(mn1);
restaurant1.AddMenu(mn2);
restaurant1.AddMenu(mn3);
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
//----------------------------------
Console.WriteLine("---------------- Restaurant Information ----------------");
Console.WriteLine(restaurant1);
Console.WriteLine("------------------------- Menu -------------------------");
foreach (var item in restaurant1.GetMenu())
{
    Console.WriteLine(item);
}
Console.WriteLine("----------------------- Personnel ----------------------");
foreach (var item in restaurant1.GetPersonnel())
{
    Console.WriteLine(item);
}
Console.WriteLine("----------------------- Customer -----------------------");
foreach (var item in restaurant1.GetCustomer())
{
    Console.WriteLine(item);
}
Console.WriteLine("------------------------- Order ------------------------");
foreach (var item in restaurant1.GetOrder(cu1))
{
    Console.WriteLine(item);
}
Console.WriteLine("--------------------- Order Detail ---------------------");
foreach (var item in restaurant1.GetOrderDetail(or1))
{
    Console.WriteLine(item);
}