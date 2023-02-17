using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly TKDecorContext _db;

        public ProductRepository(TKDecorContext db) : base(db)
        {
            _db = db;
        }
    }
}
