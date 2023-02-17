using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly TKDecorContext _db;

        public OrderRepository(TKDecorContext db) : base(db)
        {
            _db = db;
        }
    }
}
