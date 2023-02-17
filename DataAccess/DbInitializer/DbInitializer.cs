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

            List<Role> roles = new()
            {
                new Role {Description = "Admin"},
                new Role {Description = "Customer"}
            };
            _db.Roles.AddRange(roles);
            _db.SaveChanges();

            List<User> users = new()
            {
                new User{RoleId = 1, Email = "Admin@gmail.com", Password = "Admin@gmail.com"},
                new User{RoleId = 2, Email = "Customer@gmail.com", Password = "Customer@gmail.com"},
            };
            _db.Users.AddRange(users);
            _db.SaveChanges();

            List<Product> products = new()
            {
                new Product { CategoryId = 1, UserId = 1, Title = "Bàn tròn"},
                new Product { CategoryId = 2, UserId = 1, Title = "Ghế tròn"},
                new Product { CategoryId = 3, UserId = 1, Title = "Giường tròn"},
                new Product { CategoryId = 4, UserId = 1, Title = "Tủ tròn"},
                new Product { CategoryId = 5, UserId = 1, Title = "Kệ tròn"},
            };
            _db.Products.AddRange(products);
            _db.SaveChanges();
        }
    }
}
