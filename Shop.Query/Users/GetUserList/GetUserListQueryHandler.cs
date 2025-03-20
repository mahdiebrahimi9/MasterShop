using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Shop.Infra.Persestent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserLIstQuery, List<GetUserListDto>>
    {
        private readonly DapperContext _dapperContext;

        public GetUserListQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        async Task<List<GetUserListDto>> IRequestHandler<GetUserLIstQuery, List<GetUserListDto>>.Handle(GetUserLIstQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT 
                          UserName ,
                          Email,
                          Phone,
                          NationalCode,
                          ProfileImage,
                          BankCardNumber 
                          FROM
                          [User].[Users]
                                          ";

            var connection = _dapperContext.CreateConnection();
            var user = await connection.QueryAsync<GetUserListDto>(query);
            return user.ToList();
        }
    }
}
