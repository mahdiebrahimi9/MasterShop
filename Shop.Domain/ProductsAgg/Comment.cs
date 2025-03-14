using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Shop.Domain._Shared.Exceptions;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain.ProductsAgg
{
    public class Comment : BaseEntity
    {
        public Comment(int rate, string userName, string userComment)
        {
            Guard(rate, userName, userComment);
            Rate = rate;
            UserName = userName;
            UserComment = userComment;
            CreateAt = DateTime.Now;
        }
        public long ProductId { get; internal set; }
        public int Rate { get; private set; }
        public string UserName { get; private set; }
        public string UserComment { get; private set; }
        public DateTime CreateAt { get; private set; }

        private void Guard(int rate, string userName, string userComment)
        {
            NullOrEmptyDomainDataException.CheckString(userName, nameof(userName));
            NullOrEmptyDomainDataException.CheckString(userComment, nameof(userComment));

            if (rate < 1 && rate > 5)
                throw new InvalidDomainDataExcepion("بازه وارد شده باید بین 5 و 1 باشد");
        }
    }
}
