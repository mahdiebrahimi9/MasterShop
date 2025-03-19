using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Shop.Infra.Persestent.Dapper;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<GetProductListDto>>
    {
        private readonly DapperContext _dapperContext;

        public GetProductListQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<GetProductListDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT 
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
              FROM [Product].[Products]";

            using var connection = _dapperContext.CreateConnection();
            var products = await connection.QueryAsync<GetProductListDto>(query);

            return products.ToList();
        }
    }
}
