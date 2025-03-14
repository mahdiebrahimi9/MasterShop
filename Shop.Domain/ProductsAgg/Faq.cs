using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Shop.Domain.ProductsAgg.ValueObjects;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain.ProductsAgg
{
    public class Faq : BaseEntity
    {
        public Faq(string question, string userName)
        {
            Question = question;
            UserName = userName;
            Answer = new List<Answer>();
        }

        public long ProductId { get; internal set; }
        public string Question { get; private set; }
        public List<Answer> Answer { get; private set; }
        public string UserName { get; private set; }

        private void Guard(string question, string userName)
        {
            NullOrEmptyDomainDataException.CheckString(question, nameof(question));
            NullOrEmptyDomainDataException.CheckString(userName, nameof(userName));
        }
    }
}
