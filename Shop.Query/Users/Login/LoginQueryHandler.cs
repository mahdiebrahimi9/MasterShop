using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Dapper;
using MediatR;
using Shop.Domain.UserAgg;
using Shop.Infra.Persestent.Dapper;
using Shop.Query._Shared;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResponse>
    {
        private readonly DapperContext _context;
        private readonly GenerateJwtTokenHandle _generateJwtTokenHandle;
        private readonly GenerateRefreshTokenHandle _generateRefreshTokenHandle;
        public LoginQueryHandler(DapperContext context, GenerateJwtTokenHandle generateJwtTokenHandle, GenerateRefreshTokenHandle generateRefreshTokenHandle)
        {
            _context = context;
            _generateJwtTokenHandle = generateJwtTokenHandle;
            _generateRefreshTokenHandle = generateRefreshTokenHandle;
        }

        public async Task<AuthResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
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

            var accessToken = _generateJwtTokenHandle.GenerateJwtToken(user);

            var refreshToken = _generateRefreshTokenHandle.GenerateRefreshToken();
            var refreshTokenInsertQuery = @"
            INSERT INTO [User].[RefreshTokens] (UserId, Token, ExpiryDate, CreatedAt)
            VALUES (@UserId, @Token, @ExpiryDate, @CreatedAt)";

            await connection.ExecuteAsync(refreshTokenInsertQuery, new
            {
                UserId = user.Id,
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                CreatedAt = DateTime.UtcNow
                
            });
            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
