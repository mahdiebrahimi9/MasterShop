using Shop.Domain.ProductsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products.DTOs
{
    public class GetFaqListDto
    {
        public long ProductId { get;  set; }
        public string Question { get;  set; }
        public string UserName { get;  set; }
    }
}
