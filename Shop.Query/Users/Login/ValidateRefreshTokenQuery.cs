using MediatR;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.Login
{
    public class ValidateRefreshTokenQuery : IRequest<AuthResponse>
    {
        public string RefreshToken { get; set; }
    }
}
