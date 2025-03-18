using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain.ProductsAgg
{
    public class Faq : BaseEntity
    {
        public Faq(string question, string userName)
        {
            Guard(question, userName);
            Question = question;
            UserName = userName;
            Answer = new List<Answer>();
        }

        public long ProductId { get; internal set; }
        public string Question { get; private set; }
        public List<Answer> Answer { get; private set; }
        public string UserName { get; private set; }

        public void AddAnswer(Answer answer)
        {
            answer.AnswerId = Id;
            Answer.Add(answer);
        }

        private void Guard(string question, string userName)
        {
            NullOrEmptyDomainDataException.CheckString(question, nameof(question));
            NullOrEmptyDomainDataException.CheckString(userName, nameof(userName));
        }
    }
}
