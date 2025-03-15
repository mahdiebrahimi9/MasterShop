using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application._Shared;
using Shop.Domain.ProductsAgg;

namespace Shop.Infra.Persestent.Ef.UsersAgg
{
    public class ProductRepository:IRepository<Product>
    {
        public Task<bool> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> RemoveUserById(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }
    }
}
