using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Shop.Infra.Persestent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetAddressList
{
    public class GetAddressListQueryHandler : IRequestHandler<GetAddressListQuery, List<GetAddressListDto>>
    {
        private readonly DapperContext _dapperContext;

        public GetAddressListQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<GetAddressListDto>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT 
                             UserId, 
                             ReceiverName,
                             ReceiverPhone,
                             ReceiverProvince,
                             ReceiverCity,
                             ReceiverPostalAddress,
                             ReceiverPostalCode
                             FROM [User].[Addresses] WHERE UserId=@UserId
                               ";

            var connection = _dapperContext.CreateConnection();
            var address = await connection.QueryAsync<GetAddressListDto>(query, new { UserId = request.userId });
            return address.ToList();
        }
    }
}
