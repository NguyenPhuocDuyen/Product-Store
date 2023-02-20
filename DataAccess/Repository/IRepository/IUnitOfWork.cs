using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICartRepository Cart { get; }
        ICategoryRepository Category { get; }
        IOrderRepository Order  { get; }
        IOrderDetailRepository OrderDetail { get; }
        IProductRepository Product { get; }
        IReviewRepository Review { get; }
        IRoleRepository Role { get; }
        IStatusRepository Status { get; }
        IUserRepository User { get; }
        
        Task SaveAsync();
    }
}
