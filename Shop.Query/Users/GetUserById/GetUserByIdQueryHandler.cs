using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Shop.Infra.Persestent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserListDto>
    {
        private readonly DapperContext _dapperContext;

        public GetUserByIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<GetUserListDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT
                          Id,
                          UserName ,
                          Email,
                          Phone,
                          NationalCode,
                          ProfileImage,
                          BankCardNumber 
                          FROM [User].[Users] WHERE Id =@Id
                          ";
            var connection = _dapperContext.CreateConnection();
            var user = await connection.QueryFirstOrDefaultAsync<GetUserListDto>(query, new { Id = request.userId });
            return user;
        }
    }
}
