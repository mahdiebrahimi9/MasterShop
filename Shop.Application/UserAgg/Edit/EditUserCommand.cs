using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.UserAgg.Edit
{
    public class EditUserCommand : IRequest
    {
        public EditUserCommand(long userId, string userName, string email, string phone, string nationalCode, IFormFile profileImage, string bankCardNumber)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Phone = phone;
            NationalCode = nationalCode;
            ProfileImage = profileImage;
            BankCardNumber = bankCardNumber;
        }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalCode { get; set; }
        public IFormFile ProfileImage { get; set; }
        public string BankCardNumber { get; set; }
    }
}
