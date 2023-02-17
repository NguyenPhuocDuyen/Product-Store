using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //GET ALL, GET By ID FIRST OR DEFAULT, ADD, REMOVE, REMOVERANGE

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            string? includeProperties = null);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    }
}
