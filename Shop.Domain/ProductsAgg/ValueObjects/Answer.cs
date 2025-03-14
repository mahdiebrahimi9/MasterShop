using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain.ProductsAgg.ValueObjects
{
    public class Answer : ValueObject
    {
        public Answer(string answerFaq)
        {
            NullOrEmptyDomainDataException.CheckString(answerFaq, nameof(answerFaq));
            AnswerFaq = answerFaq;
        }

        public string AnswerFaq { get; private set; }
    }
}
