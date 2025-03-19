using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetProductById
{
    public record GetProductByIdQuery(long productId) : IRequest<GetProductListDto>;
}
