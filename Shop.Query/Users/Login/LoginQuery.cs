using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Login
{
    public class LoginQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
