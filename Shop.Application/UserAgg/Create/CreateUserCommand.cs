using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.UserAgg.Create
{
    public class CreateUserCommand : IRequest
    {
        public string UserName { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        public string NationalCode { get;  set; }
        public IFormFile ProfileImage { get; set; }
        public string BankCardNumber { get;  set; }
    }
}
