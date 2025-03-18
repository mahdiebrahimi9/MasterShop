using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Application._Shared;

namespace Shop.Infra.Persestent.Ef
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ShopContext Context;

        public BaseRepository(ShopContext context)
        {
            Context = context;
        }

        public async Task<bool> AddAsync(T entity)
        {
            Context.Set<T>().Add(entity);
            var count = await Context.SaveChangesAsync();
            return count > 0 ? true : false;
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<T?> RemoveById(long Id)
        {
            var entity = await Context.Set<T>().FindAsync(Id);
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Save()
        {
            return await Context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            Context.Set<T>().Add(entity);
            var count = await Context.SaveChangesAsync();
            return count > 0 ? true : false;
        }
    }
}
