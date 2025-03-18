using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain.ProductsAgg
{
    public class Answer
    {

        public Answer(string answerFaq)
        {
            NullOrEmptyDomainDataException.CheckString(answerFaq, nameof(answerFaq));
            AnswerFaq = answerFaq;
        }
        public long AnswerId { get; internal set; }
        public string AnswerFaq { get; private set; }

        public long FaqId { get; set; }
        public Faq Faq { get; set; }
    }
}
