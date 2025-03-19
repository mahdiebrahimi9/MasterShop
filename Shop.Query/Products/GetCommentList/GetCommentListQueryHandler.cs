using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Shop.Infra.Persestent.Dapper;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetCommentList
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, List<GetCommentListDto>>
    {
        private readonly DapperContext _dapperContext;

        public GetCommentListQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<GetCommentListDto>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT 
                          ProductId,
                          Rate,
                          UserName,
                          UserComment,
                          CreateAt 
                          FROM [Product].[Comments] WHERE ProductId=@ProductId
                         ";

            var connection = _dapperContext.CreateConnection();
            var comment = await connection.QueryAsync<GetCommentListDto>(query, new { ProductId = request.productId });
            return comment.ToList();
        }
    }
}
