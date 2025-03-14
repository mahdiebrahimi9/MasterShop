using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application._Shared
{
    public interface IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<T?> GetByIdAsync(long id);
        Task<T?> RemoveById(long Id);
        Task<bool> UpdateAsync(T entity);
        Task<int> Save();
    }
}
