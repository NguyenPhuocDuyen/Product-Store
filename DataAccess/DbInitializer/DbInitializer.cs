using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly TKDecorContext _db;

        public DbInitializer(TKDecorContext db)
        {
            _db = db;
        }

        public void Initialize()
        {
            if (_db.Categories.Any())
            {
                return;
            }

            List<Category> categories = new()
            {
                new Category() {Description = "Bàn"},
                new Category() {Description = "Ghế"},
                new Category() {Description = "Giường"},
                new Category() {Description = "Tủ"},
                new Category() {Description = "Kệ"}
            };
            _db.Categories.AddRange(categories);
            _db.SaveChanges();

            _db.Roles.Add(new Role { Description = "Admin" });
            _db.SaveChanges();
            _db.Roles.Add(new Role { Description = "Customer" });
            _db.SaveChanges();

            _db.Users.Add(new User { RoleId = 1, Email = "Admin@gmail.com", Password = "Admin@gmail.com" });
            _db.SaveChanges();

            List<User> users = new()
            {
                new User{RoleId = 2, Email = "Customer1@gmail.com", Password = "Customer1@gmail.com", Address = "Ha Noi"},
                new User{RoleId = 2, Email = "Customer2@gmail.com", Password = "Customer2@gmail.com", Address = "Ho Chi Minh"},
                new User{RoleId = 2, Email = "Customer3@gmail.com", Password = "Customer3@gmail.com", Address = "Da Nang"},
                new User{RoleId = 2, Email = "Customer4@gmail.com", Password = "Customer4@gmail.com", Address = "Hue"},
                new User{RoleId = 2, Email = "Customer5@gmail.com", Password = "Customer5@gmail.com", Address = "Can Tho"},
                new User{RoleId = 2, Email = "Customer6@gmail.com", Password = "Customer6@gmail.com", Address = "Vinh Long"},
                new User{RoleId = 2, Email = "Customer7@gmail.com", Password = "Customer7@gmail.com", Address = "Phu Yen"},
                new User{RoleId = 2, Email = "Customer8@gmail.com", Password = "Customer8@gmail.com", Address = "Dong Thap"},
                new User{RoleId = 2, Email = "Customer9@gmail.com", Password = "Customer9@gmail.com", Address = "Ca Mau"},
            };
            _db.Users.AddRange(users);
            _db.SaveChanges();

            Random random = new Random();
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;

            List<Product> products = new()
            {
                new Product { CategoryId = 1, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn tròn", },
                new Product { CategoryId = 1, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn chữ Z", },
                new Product { CategoryId = 1, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn Nhựa", },
                new Product { CategoryId = 2, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế tròn", },
                new Product { CategoryId = 2, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế 3 chân", },
                new Product { CategoryId = 2, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế sofa", },
                new Product { CategoryId = 3, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giường tròn", },
                new Product { CategoryId = 3, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giường Đôi", },
                new Product { CategoryId = 3, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giường Gỗ", },
                new Product { CategoryId = 4, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ tròn", },
                new Product { CategoryId = 4, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ 3 Ngăn", },
                new Product { CategoryId = 4, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ Tài Liệu", },
                new Product { CategoryId = 5, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ Kho Hàng", },
                new Product { CategoryId = 5, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ Gỗ", },
                new Product { CategoryId = 5, UserId = 1, RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ tròn", },
            };
            _db.Products.AddRange(products);
            _db.SaveChanges();

            List<Status> statuses = new()
            {
                new Status { Title = "Khách đặt đơn hàng"},
                new Status { Title = "Khách hàng đã huỷ đơn hàng"},
                new Status { Title = "Đã chấp nhận đơn hàng và giao hàng"},
                new Status { Title = "Khách đã nhận hàng"},
            };
            _db.Statuses.AddRange(statuses);
            _db.SaveChanges();

            var userList = _db.Users.ToList();
            var statusList = _db.Statuses.ToList();
            List<Order> orders = new();
            foreach (User user in userList)
            {
                if (user.RoleId != 1)
                {
                    orders.Add(new Order
                    {
                        UserId = user.Id,
                        OrderAddress = user.Address,
                        StatusId = new Random().Next(0, statusList.Count) + 1,
                        CreateAt = start.AddDays(random.Next(range))
                    });
                }
            }
            _db.Orders.AddRange(orders);
            _db.SaveChanges();

            var listOrder = _db.Orders.ToList();
            var listProduct = _db.Products.ToList();
            List<OrderDetail> ordersDetail = new();
            foreach (Order order in listOrder)
            {
                foreach (Product product in listProduct)
                {
                    ordersDetail.Add(new OrderDetail
                    {
                        ProductId = product.Id,
                        OrderId = order.Id,
                        Amount = new Random().Next(0, 20) + 1,
                        PaymentPrice = product.RecentPrice
                    });
                }
            }
            _db.OrderDetails.AddRange(ordersDetail);
            _db.SaveChanges();
        }
    }
}
