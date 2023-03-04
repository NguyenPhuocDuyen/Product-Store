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
                new Category() {Description = "Kệ"},
                 new Category() {Description = "Đèn"},
                new Category() {Description = "Rèm"},
                new Category() {Description = "Thảm"}

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

                new User{RoleId = 2, Email = "Customer10@gmail.com", Password = "Customer10@gmail.com", Address = "Ha Noi"},
                new User{RoleId = 2, Email = "Customer11@gmail.com", Password = "Customer11@gmail.com", Address = "Ba Ria Vung Tau"},
                new User{RoleId = 2, Email = "Customer12@gmail.com", Password = "Customer12@gmail.com", Address = "Bac Lieu"},
                new User{RoleId = 2, Email = "Customer13@gmail.com", Password = "Customer13@gmail.com", Address = "Ben Tre"},
                new User{RoleId = 2, Email = "Customer14@gmail.com", Password = "Customer14@gmail.com", Address = "Binh Duong"},
                new User{RoleId = 2, Email = "Customer15@gmail.com", Password = "Customer15@gmail.com", Address = "Binh Thuan"},
                new User{RoleId = 2, Email = "Customer16@gmail.com", Password = "Customer16@gmail.com", Address = "Gia Lai"},
                new User{RoleId = 2, Email = "Customer17@gmail.com", Password = "Customer17@gmail.com", Address = "Ha Giang"},
                new User{RoleId = 2, Email = "Customer18@gmail.com", Password = "Customer18@gmail.com", Address = "Hau Giang"},
                new User{RoleId = 2, Email = "Customer19@gmail.com", Password = "Customer19@gmail.com", Address = "Thanh Hoa"},

                new User{RoleId = 2, Email = "Customer20@gmail.com", Password = "Customer20@gmail.com", Address = "Ho Chi Minh"},
                new User{RoleId = 2, Email = "Customer21@gmail.com", Password = "Customer21@gmail.com", Address = "Ba Ria Vung Tau"},
                new User{RoleId = 2, Email = "Customer22@gmail.com", Password = "Customer22@gmail.com", Address = "Bac Lieu"},
                new User{RoleId = 2, Email = "Customer23@gmail.com", Password = "Customer23@gmail.com", Address = "Ben Tre"},
                new User{RoleId = 2, Email = "Customer24@gmail.com", Password = "Customer24@gmail.com", Address = "Binh Duong"},
                new User{RoleId = 2, Email = "Customer25@gmail.com", Password = "Customer25@gmail.com", Address = "Binh Thuan"},
                new User{RoleId = 2, Email = "Customer26@gmail.com", Password = "Customer26@gmail.com", Address = "Gia Lai"},
                new User{RoleId = 2, Email = "Customer27@gmail.com", Password = "Customer27@gmail.com", Address = "Ha Giang"},
                new User{RoleId = 2, Email = "Customer28@gmail.com", Password = "Customer28@gmail.com", Address = "Hau Giang"},
                new User{RoleId = 2, Email = "Customer29@gmail.com", Password = "Customer29@gmail.com", Address = "Thanh Hoa"},

                new User{RoleId = 2, Email = "Customer30@gmail.com", Password = "Customer30@gmail.com", Address = "Da Nang"},
                new User{RoleId = 2, Email = "Customer31@gmail.com", Password = "Customer31@gmail.com", Address = "Ba Ria Vung Tau"},
                new User{RoleId = 2, Email = "Customer32@gmail.com", Password = "Customer32@gmail.com", Address = "Bac Lieu"},
                new User{RoleId = 2, Email = "Customer33@gmail.com", Password = "Customer33@gmail.com", Address = "Ben Tre"},
                new User{RoleId = 2, Email = "Customer34@gmail.com", Password = "Customer34@gmail.com", Address = "Binh Duong"},
                new User{RoleId = 2, Email = "Customer35@gmail.com", Password = "Customer35@gmail.com", Address = "Binh Thuan"},
                new User{RoleId = 2, Email = "Customer36@gmail.com", Password = "Customer36@gmail.com", Address = "Gia Lai"},
                new User{RoleId = 2, Email = "Customer37@gmail.com", Password = "Customer37@gmail.com", Address = "Ha Giang"},
                new User{RoleId = 2, Email = "Customer38@gmail.com", Password = "Customer38@gmail.com", Address = "Hau Giang"},
                new User{RoleId = 2, Email = "Customer39@gmail.com", Password = "Customer39@gmail.com", Address = "Thanh Hoa"},

                new User{RoleId = 2, Email = "Customer40@gmail.com", Password = "Customer40@gmail.com", Address = "Hue"},
                new User{RoleId = 2, Email = "Customer41@gmail.com", Password = "Customer41@gmail.com", Address = "Ba Ria Vung Tau"},
                new User{RoleId = 2, Email = "Customer42@gmail.com", Password = "Customer42@gmail.com", Address = "Bac Lieu"},
                new User{RoleId = 2, Email = "Customer43@gmail.com", Password = "Customer43@gmail.com", Address = "Ben Tre"},
                new User{RoleId = 2, Email = "Customer44@gmail.com", Password = "Customer44@gmail.com", Address = "Binh Duong"},
                new User{RoleId = 2, Email = "Customer45@gmail.com", Password = "Customer45@gmail.com", Address = "Binh Thuan"},
                new User{RoleId = 2, Email = "Customer46@gmail.com", Password = "Customer46@gmail.com", Address = "Gia Lai"},
                new User{RoleId = 2, Email = "Customer47@gmail.com", Password = "Customer47@gmail.com", Address = "Ha Giang"},
                new User{RoleId = 2, Email = "Customer48@gmail.com", Password = "Customer48@gmail.com", Address = "Hau Giang"},
                new User{RoleId = 2, Email = "Customer49@gmail.com", Password = "Customer49@gmail.com", Address = "Thanh Hoa"},
            };
            _db.Users.AddRange(users);
            _db.SaveChanges();

            Random random = new Random();
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;

            List<Product> products = new()
            {
                new Product { CategoryId = 1, UserId = 1, Description="Bàn",Thumbnail="~/Data/Image/Bàn Tròn.jpg", RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn tròn", },
                new Product { CategoryId = 1, UserId = 1, Description="Bàn",Thumbnail="~/Data/Image/Ban chu z.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn chữ Z", },
                new Product { CategoryId = 1, UserId = 1, Description="Bàn",Thumbnail="~/Data/Image/ban nhua.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn Nhựa", },
                new Product { CategoryId = 2, UserId = 1, Description="Ghế",Thumbnail="~/Data/Image/Ghế tròn.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế tròn", },
                new Product { CategoryId = 2, UserId = 1, Description="Ghế",Thumbnail="~/Data/Image/ghế 3 chân.jpg", RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế 3 chân", },
                new Product { CategoryId = 2, UserId = 1, Description="Ghế",Thumbnail="~/Data/Image/ghế sofa.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế sofa", },
                new Product { CategoryId = 3, UserId = 1, Description="Giường",Thumbnail="~/Data/Image/giường tròn.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giường tròn", },
                new Product { CategoryId = 3, UserId = 1, Description="Giường",Thumbnail="~/Data/Image/giường đôi.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giường Đôi", },
                new Product { CategoryId = 3, UserId = 1, Description="Giường",Thumbnail="~/Data/Image/giường gỗ.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giường Gỗ", },
                new Product { CategoryId = 4, UserId = 1, Description="Tủ",Thumbnail="~/Data/Image/tủ tròn.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ tròn", },
                new Product { CategoryId = 4, UserId = 1, Description="Tủ",Thumbnail="~/Data/Image/tủ 3 ngăn.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ 3 Ngăn", },
                new Product { CategoryId = 4, UserId = 1, Description="Tủ",Thumbnail="~/Data/Image/tủ tài liệu.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ Tài Liệu", },
                new Product { CategoryId = 5, UserId = 1, Description="Kệ",Thumbnail="~/Data/Image/Kệ kho hàng.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ Kho Hàng", },
                new Product { CategoryId = 5, UserId = 1, Description="Kệ",Thumbnail="~/Data/Image/Kệ gỗ.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ Gỗ", },
                new Product { CategoryId = 5, UserId = 1, Description="Kệ",Thumbnail="~/Data/Image/kệ tròn.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ tròn", },

                new Product { CategoryId = 5, UserId = 1, Description="Bàn",Thumbnail="~/Data/Image/bàn trà.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn trà", },
                new Product { CategoryId = 5, UserId = 1, Description="Bàn",Thumbnail="~/Data/Image/ban an.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn ăn", },
                new Product { CategoryId = 5, UserId = 1, Description="Ghế",Thumbnail="~/Data/Image/ghế ăn.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế ăn", },
                new Product { CategoryId = 5, UserId = 1, Description="Tủ",Thumbnail="~/Data/Image/tủ quần áo.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ quần áo", },
                new Product { CategoryId = 5, UserId = 1, Description="Bàn",Thumbnail="~/Data/Image/ban lam viec.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn làm việc", },
                new Product { CategoryId = 5, UserId = 1, Description="Ghế",Thumbnail="~/Data/Image/ghế văn phòng.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế văn phòng", },
                new Product { CategoryId = 5, UserId = 1, Description="Kệ",Thumbnail="~/Data/Image/Kệ sách.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ sách", },
                new Product { CategoryId = 5, UserId = 1, Description="Kệ",Thumbnail="~/Data/Image/Kệ trang trí.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ trang trí", },
                new Product { CategoryId = 5, UserId = 1, Description="Bàn",Thumbnail="~/Data/Image/Bàn phấn.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn phấn", },
                new Product { CategoryId = 5, UserId = 1, Description="Ghế",Thumbnail="~/Data/Image/Ghế đẩu.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế đẩu", },
                new Product { CategoryId = 5, UserId = 1, Description="Bàn",Thumbnail="~/Data/Image/ban cafe.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn cafe", },
                new Product { CategoryId = 5, UserId = 1, Description="Đèn",Thumbnail="~/Data/Image/Đèn bàn.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Đèn bàn", },
                new Product { CategoryId = 5, UserId = 1, Description="Đèn",Thumbnail="~/Data/Image/Đèn trần.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "đèn trần", },
                new Product { CategoryId = 5, UserId = 1, Description="Rèm",Thumbnail="~/Data/Image/Rèm cửa.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "rèm cửa", },
                new Product { CategoryId = 5, UserId = 1, Description="Thảm",Thumbnail="~/Data/Image/Thảm trải sàn.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "thảm trải sàn", },
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
