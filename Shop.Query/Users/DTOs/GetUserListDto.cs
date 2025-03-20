using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.DTOs
{
    public class GetUserListDto
    {
        public string UserName { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        public string NationalCode { get;  set; }
        public string ProfileImage { get;  set; }
        public string BankCardNumber { get;  set; }
    }
}
