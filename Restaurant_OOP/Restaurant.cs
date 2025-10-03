using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OfficeOpenXml.ExcelErrorValue;

namespace Restaurant_OOP
{
    internal class Restaurant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<Menu> Menus { get; private set; }
        public List<FoodQty> FoodsQty { get; private set; }
        public List<Order> Orders { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public List<Customer> Customers { get; private set; }
        public List<Balance> Balances { get; private set; }
        public List<Personnel> Personnels { get; private set; }
        public Restaurant(string name, string description, string address)
        {
            Menus = new List<Menu>();
            Customers = new List<Customer>();
            Personnels = new List<Personnel>();
            FoodsQty = new List<FoodQty>();
            Balances = new List<Balance>();
            Orders = new List<Order>();
            Items = new List<OrderItem>();
            this.Name = name;
            this.Description = description;
            this.Address = address;
        }
        public void GetData()
        {
            ExcelPackage.License.SetNonCommercialPersonal("E A");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[0];
                int countRow = sheet.Dimension.Rows;
                for (int i = 2; i <= countRow; i++)
                {
                    Personnels.Add(new Personnel(
                       Convert.ToInt32(sheet.Cells[i, 1].Value),
                       sheet.Cells[i, 2].Value.ToString(),
                       sheet.Cells[i, 3].Value.ToString(),
                       sheet.Cells[i, 4].Value.ToString(),
                       sheet.Cells[i, 5].Value.ToString(),
                       sheet.Cells[i, 6].Value.ToString(),
                       sheet.Cells[i, 7].Value.ToString()));
                }
                sheet = package.Workbook.Worksheets[1];
                countRow = sheet.Dimension.Rows;
                for (int i = 2; i <= countRow; i++)
                {
                    Customers.Add(new Customer(
                     Convert.ToInt32(sheet.Cells[i, 1].Value),
                       sheet.Cells[i, 2].Value.ToString(),
                       sheet.Cells[i, 3].Value.ToString(),
                       sheet.Cells[i, 4].Value.ToString(),
                       sheet.Cells[i, 5].Value.ToString(),
                       sheet.Cells[i, 6].Value.ToString(),
                       sheet.Cells[i, 7].Value.ToString()));
                }
                sheet = package.Workbook.Worksheets[2];
                countRow = sheet.Dimension.Rows;
                for (int i = 2; i <= countRow; i++)
                {
                    Menus.Add(new Menu(
                       int.Parse(sheet.Cells[i, 1].Value.ToString()),
                       sheet.Cells[i, 2].Value.ToString(),
                       sheet.Cells[i, 3].Value.ToString(),
                       decimal.Parse(sheet.Cells[i, 4].Value.ToString())));
                }
                sheet = package.Workbook.Worksheets[3];
                countRow = sheet.Dimension.Rows;
                for (int i = 2; i <= countRow; i++)
                {
                    FoodsQty.Add(new FoodQty(
                       int.Parse(sheet.Cells[i, 1].Value.ToString()),
                       int.Parse(sheet.Cells[i, 2].Value.ToString()),
                    Convert.ToDateTime(sheet.Cells[i, 3].Value)));
                }
                sheet = package.Workbook.Worksheets[4];
                countRow = sheet.Dimension.Rows;
                for (int i = 2; i <= countRow; i++)
                {
                    Orders.Add(new Order(
                    Convert.ToInt32(sheet.Cells[i, 1].Value),
                    Convert.ToInt32(sheet.Cells[i, 2].Value),
                    Convert.ToDateTime(sheet.Cells[i, 3].Value)));
                }
                sheet = package.Workbook.Worksheets[5];
                countRow = sheet.Dimension.Rows;
                for (int i = 2; i <= countRow; i++)
                {
                    Balances.Add(new Balance(
                       int.Parse(sheet.Cells[i, 1].Value.ToString()),
                       decimal.Parse(sheet.Cells[i, 2].Value.ToString()),
                    Convert.ToDateTime(sheet.Cells[i, 3].Value)));
                }
                sheet = package.Workbook.Worksheets[6];
                countRow = sheet.Dimension.Rows;
                for (int i = 2; i <= countRow; i++)
                {
                    Items.Add(new OrderItem(
                      Convert.ToInt32(sheet.Cells[i, 1].Value),
                      Convert.ToInt32(sheet.Cells[i, 2].Value),
                      Convert.ToInt32(sheet.Cells[i, 3].Value)));
                }
            }
        }
        public void AddMenu(Menu menu)
        {
            Menus.Add(menu);
            ExcelPackage.License.SetNonCommercialPersonal("E A");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[2];
                int lastRow = sheet.Dimension.End.Row + 1;
                sheet.Cells[lastRow, 1].Value = menu.Id;
                sheet.Cells[lastRow, 2].Value = menu.Name;
                sheet.Cells[lastRow, 3].Value = menu.Description;
                sheet.Cells[lastRow, 4].Value = menu.Price;
                package.Save();
            }
        }
        public void AddFoodQty(FoodQty foodQty)
        {
            FoodsQty.Add(foodQty);
            ExcelPackage.License.SetNonCommercialPersonal("E A");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[3];
                int lastRow = sheet.Dimension.End.Row + 1;
                sheet.Cells[lastRow, 1].Value = foodQty.FoodId;
                sheet.Cells[lastRow, 2].Value = foodQty.Qty;
                sheet.Cells[lastRow, 3].Value = DateTime.Now.ToString();
                package.Save();
            }
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            ExcelPackage.License.SetNonCommercialPersonal("E A");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[1];
                int lastRow = sheet.Dimension.End.Row + 1;
                sheet.Cells[lastRow, 1].Value = customer.Id;
                sheet.Cells[lastRow, 2].Value = customer.FirstName;
                sheet.Cells[lastRow, 3].Value = customer.LastName;
                sheet.Cells[lastRow, 4].Value = customer.IdNumber;
                sheet.Cells[lastRow, 5].Value = customer.Address;
                sheet.Cells[lastRow, 6].Value = customer.Username;
                sheet.Cells[lastRow, 7].Value = customer.Password;
                package.Save();
            }
        }
        public void AddBalance(Balance balance)
        {
            Balances.Add(balance);
            ExcelPackage.License.SetNonCommercialPersonal("E A");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[5];
                int lastRow = sheet.Dimension.End.Row + 1;
                sheet.Cells[lastRow, 1].Value = balance.CustomerId;
                sheet.Cells[lastRow, 2].Value = balance.Amount;
                sheet.Cells[lastRow, 3].Value = DateTime.Now.ToString();
                package.Save();
            }
        }
        public void AddPersonnel(Personnel personnel)
        {
            Personnels.Add(personnel);
            ExcelPackage.License.SetNonCommercialPersonal("E A");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[0];
                int lastRow = sheet.Dimension.End.Row + 1;
                sheet.Cells[lastRow, 1].Value = personnel.Id;
                sheet.Cells[lastRow, 2].Value = personnel.FirstName;
                sheet.Cells[lastRow, 3].Value = personnel.LastName;
                sheet.Cells[lastRow, 4].Value = personnel.IdNumber;
                sheet.Cells[lastRow, 5].Value = personnel.Address;
                sheet.Cells[lastRow, 6].Value = personnel.Username;
                sheet.Cells[lastRow, 7].Value = personnel.Password;
                sheet.Cells[lastRow, 8].Value = personnel.IsAdmin;
                package.Save();
            }
        }
        public void AddItemOrder(OrderItem orderItem)
        {
            Items.Add(orderItem);
            ExcelPackage.License.SetNonCommercialPersonal("E A");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[6];
                int lastRow = sheet.Dimension.End.Row + 1;
                sheet.Cells[lastRow, 1].Value = orderItem.OrderId;
                sheet.Cells[lastRow, 2].Value = orderItem.FoodId;
                sheet.Cells[lastRow, 3].Value = orderItem.Qty;
                package.Save();
            }
        }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
            ExcelPackage.License.SetNonCommercialPersonal("E A");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[4];
                int lastRow = sheet.Dimension.End.Row + 1;
                sheet.Cells[lastRow, 1].Value = order.Id;
                sheet.Cells[lastRow, 2].Value = order.CustomerId;
                sheet.Cells[lastRow, 3].Value = DateTime.Now.ToString();
                sheet.Cells[lastRow, 4].Value = order.Status;
                package.Save();
            }
        }
        public override string ToString()
        {
            return $"Restaurant: [{Name}] - Description: [{Description}] - Address: [{Address}]";
        }
        public IEnumerable<string> GetMenu()
        {
            return Menus.Select(menu => $"{menu.Name.PadRight(27)}{menu.Description.PadRight(35)}{menu.Price.ToString().PadRight(10)}{GetFoodQty(menu).ToString().PadLeft(5)}");
        }
        public IEnumerable<string> GetPersonnel()
        {
            return Personnels.Select(personnel => $"{personnel.FirstName.PadRight(12)}{personnel.LastName.PadRight(15)}{personnel.IdNumber.PadRight(11)}{personnel.Address.PadLeft(39)}");
        }
        public IEnumerable<string> GetCustomer()
        {
            return Customers.Select(customer => $"{customer.FirstName.PadRight(12)}{customer.LastName.PadRight(12)}{customer.IdNumber.PadRight(11)}{customer.Address.PadRight(26)}{Orders.Count.ToString().PadRight(3)}{GetBalance(user).ToString().PadLeft(13)}");
        }
        public IEnumerable<string> GetOrderDetail(Order order)
        {
            return Items.Where(detail => detail.OrderId == order.Id).Select(detail => $"{Menus.First(x => x.Id == detail.FoodId).Name.PadRight(30)}{Menus.First(x => x.Id == detail.FoodId).Price.ToString().PadRight(17)}{detail.Qty.ToString().PadRight(15)}{(Menus.First(x => x.Id == detail.FoodId).Price * detail.Qty).ToString().PadLeft(15)}");

        }
        public IEnumerable<string> GetOrder(Customer customer)
        {

            return Orders.Where(x => x.CustomerId == customer.Id).Select(order => $"{order.Id.ToString().PadRight(4)}{(customer.FirstName + " " + customer.LastName).PadRight(24)}{order.Date.ToString().PadRight(30)}{order.Status.ToString().PadRight(10)}{GetSum(order).ToString().PadLeft(9)}");
        }
        public int GetFoodQty(Menu menu)
        {
            return FoodsQty.Where(x => x.FoodId == menu.Id).Sum(x => x.Qty) - Items.Where(x => x.FoodId == menu.Id).Sum(x => x.Qty);
        }
        public Customer user;
        public bool Login(string username, string password)
        {
            var query = Customers.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (query != null)
            {
                user = query;
                return true;
            }
            else
            {
                return false;
            }
        }
        public decimal GetBalance(Customer customer)
        {
            return Balances.Where(c => c.CustomerId == customer.Id).Sum(c => c.Amount) - Orders.Where(o => o.CustomerId == customer.Id).Sum(x => GetSum(x));
        }
        public decimal GetSum(Order order)
        {
            return Items.Where(i => i.OrderId == order.Id).Sum(q => q.Qty * Menus.First(x => x.Id == q.FoodId).Price);
        }
    }
}

