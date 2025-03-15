using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Application._Shared;
using Shop.Domain.ProductsAgg;

namespace Shop.Infra.Persestent.Ef.UsersAgg
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<bool> AddAsync(Product entity)
        {
            _shopContext.Products.Add(entity);
            var count = await _shopContext.SaveChangesAsync();
            return count > 0 ? true : false;
        }

        public async Task<Product?> GetByIdAsync(long id)
        {
            return await _shopContext.Products.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            _shopContext.Products.Update(entity);
            var count = await _shopContext.SaveChangesAsync();
            return count > 0 ? true : false;
        }

        public async Task<int> Save()
        {
            return await _shopContext.SaveChangesAsync();
        }

        public async Task<Product?> RemoveById(long Id)
        {
            var product = await _shopContext.Products.FirstOrDefaultAsync(f => f.Id == Id);
            _shopContext.Products.Remove(product);
            await _shopContext.SaveChangesAsync();
            return product;
        }
    }
}
