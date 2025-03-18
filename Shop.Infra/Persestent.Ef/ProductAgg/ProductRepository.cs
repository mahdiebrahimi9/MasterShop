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
    public class ProductRepository : BaseRepository<Product>
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
        
    }
}
