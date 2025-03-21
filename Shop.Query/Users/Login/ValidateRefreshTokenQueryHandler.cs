using MediatR;
using Shop.Domain.UserAgg;
using Shop.Infra.Persestent.Dapper;
using Shop.Query._Shared;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Shop.Query.Users.Login
{
    public class ValidateRefreshTokenQueryHandler : IRequestHandler<ValidateRefreshTokenQuery, AuthResponse>
    {
        private readonly DapperContext _context;
        private readonly GenerateJwtTokenHandle _generateJwtTokenHandle;

        public ValidateRefreshTokenQueryHandler(DapperContext context, GenerateJwtTokenHandle generateJwtTokenHandle)
        {
            _context = context;
            _generateJwtTokenHandle = generateJwtTokenHandle;
        }

        public async Task<AuthResponse> Handle(ValidateRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT * FROM [User].[RefreshTokens] WHERE Token = @Token AND ExpiryDate > @CurrentDate";
            using var connection = _context.CreateConnection();

            var refreshToken = await connection.QueryFirstOrDefaultAsync<RefreshToken>(query, new
            {
                Token = request.RefreshToken,
                CurrentDate = DateTime.UtcNow
            });

            if (refreshToken == null)
            {
                throw new Exception("Invalid or expired refresh token.");
            }

           
            var userQuery = @"SELECT * FROM [User].[Users] WHERE Id = @UserId";
            var user = await connection.QueryFirstOrDefaultAsync<User>(userQuery, new { UserId = refreshToken.UserId });

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var newAccessToken = _generateJwtTokenHandle.GenerateJwtToken(user);

            return new AuthResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = request.RefreshToken 
            };
        }
    }

}
