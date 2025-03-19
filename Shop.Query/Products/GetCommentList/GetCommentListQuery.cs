using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetCommentList
{
    public record GetCommentListQuery(long productId) : IRequest<List<GetCommentListDto>>;

}
