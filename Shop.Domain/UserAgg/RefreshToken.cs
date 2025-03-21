using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.UserAgg
{
    public class RefreshToken
    {
        public RefreshToken( string token, DateTime expiryDate, DateTime createdAt)
        {
            Token = token;
            ExpiryDate = expiryDate;
            CreatedAt = createdAt;
        }
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
