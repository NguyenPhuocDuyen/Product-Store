using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly TKDecorContext _db;

        public CategoryRepository(TKDecorContext db) : base(db)
        {
            _db = db;
        }
    }
}
