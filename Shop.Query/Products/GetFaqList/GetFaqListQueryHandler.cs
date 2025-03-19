using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Shop.Infra.Persestent.Dapper;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetFaqList
{
    public class GetFaqListQueryHandler : IRequestHandler<GetFaqListQuery, List<GetFaqListDto>>
    {
        private readonly DapperContext _context;

        public GetFaqListQueryHandler(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<GetFaqListDto>> Handle(GetFaqListQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT 
                          ProductId,
                          Question,
                          UserName 
                          From [Product].[Faqs] WHERE ProductId=@ProductId
";
            var connection = _context.CreateConnection();
            var faq = await connection.QueryAsync<GetFaqListDto>(query, new { ProductId = request.productId });
            return faq.ToList();
        }
    }
}
