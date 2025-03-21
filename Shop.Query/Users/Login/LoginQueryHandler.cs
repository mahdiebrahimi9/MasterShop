using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Shop.Domain.UserAgg;
using Shop.Infra.Persestent.Dapper;
using Shop.Query._Shared;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly DapperContext _context;
        private readonly GenerateJwtTokenHandle _generateJwtTokenHandle;
        public LoginQueryHandler(DapperContext context, GenerateJwtTokenHandle generateJwtTokenHandle)
        {
            _context = context;
            _generateJwtTokenHandle = generateJwtTokenHandle;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var query = @" 
                         SELECT * FROM [User].[Users] WHERE UserName = @UserName 
                          ";
            var connection = _context.CreateConnection();

            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            {
                throw new ArgumentException("UserName and Password cannot be null or empty.");
            }

            var user = await connection.QueryFirstOrDefaultAsync<User>(query, new { UserName = request.UserName });

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new Exception("Invalid credentials.");
            }

            var token = _generateJwtTokenHandle.GenerateJwtToken(user);
            return token;
        }
    }
}
