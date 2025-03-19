using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetProductList
{
    public record GetProductListQuery : IRequest<List<GetProductListDto>>;
}
