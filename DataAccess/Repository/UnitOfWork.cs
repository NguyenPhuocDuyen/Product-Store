using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TKDecorContext _db;
        public UnitOfWork(TKDecorContext db)
        {
            _db = db;
            Cart = new CartRepository(_db);
            Category = new CategoryRepository(_db);
            Order = new OrderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
            Product = new ProductRepository(_db);
            Review = new ReviewRepository(_db);
            Role = new RoleRepository(_db);
            Status = new StatusRepository(_db);
            User = new UserRepository(_db);
        }

        public ICartRepository Cart { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IProductRepository Product { get; private set; }
        public IReviewRepository Review { get; private set; }
        public IRoleRepository Role { get; private set; }
        public IStatusRepository Status { get; private set; }
        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
