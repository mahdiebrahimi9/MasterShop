using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Application._Shared;
using Shop.Domain.ProductsAgg;

namespace Shop.Infra.Persestent.Ef.ProductAgg.Faqs
{
    public class FaqRepository : IRepository<Faq>
    {
        private readonly ShopContext _shopContext;

        public FaqRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public Task<bool> AddAsync(Faq entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Faq?> GetByIdAsync(long id)
        {
            return await _shopContext.Faqs.FirstOrDefaultAsync(f => f.Id == id);
        }

        public Task<Faq?> RemoveById(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Faq entity)
        {
            throw new NotImplementedException();
        }
    }
}
