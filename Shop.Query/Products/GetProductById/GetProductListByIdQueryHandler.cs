using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Shop.Infra.Persestent.Dapper;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetProductById
{
    public class GetProductListByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductListDto>
    {
        private readonly DapperContext _dapperContext;

        public GetProductListByIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<GetProductListDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT 
                Id,
                ProductName, 
                ProductCode, 
                ProductPrice_Value, 
                ProductDiscount_Amount, 
                Count, 
                TotalRate, 
                Title, 
                Description, 
                Color, 
                Category, 
                BestSelling, 
                Design, 
                PurchaseValue, 
                BuildQuality, 
                Featured 
              FROM [Product].[Products] WHERE Id = @Id";
            var connection = _dapperContext.CreateConnection();
            var product =
                await connection.QuerySingleOrDefaultAsync<GetProductListDto>(query, new { Id = request.productId });
            return product;
        }
    }
}
