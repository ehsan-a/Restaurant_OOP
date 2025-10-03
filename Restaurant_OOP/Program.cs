// See https://aka.ms/new-console-template for more information
using Restaurant_OOP;
using System;

Restaurant restaurant1 = new Restaurant("Chiken Family", "Fast Food", "Tehran, Janbazan Street");
bool isRun = true;
Console.WriteLine(restaurant1);
restaurant1.GetData();
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