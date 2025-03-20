using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Shop.Infra.Persestent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressListDto>
    {
        private readonly DapperContext _dapperContext;

        public GetAddressByIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<GetAddressListDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT
                             Id, 
                             ReceiverName,
                             ReceiverPhone,
                             ReceiverProvince,
                             ReceiverCity,
                             ReceiverPostalAddress,
                             ReceiverPostalCode
                             FROM [User].[Addresses] WHERE Id=@Id
";
            var connection = _dapperContext.CreateConnection();
            var address = await connection.QueryFirstOrDefaultAsync<GetAddressListDto>(query, new { Id = request.addressId });
            return address;
        }
    }
}
