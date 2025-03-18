using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.ProductAgg.AddAnswer
{
    public class AddAnswerCommand : IRequest
    {
        public AddAnswerCommand(long faqId, string answerFaq, long productId)
        {
            FaqId = faqId;
            AnswerFaq = answerFaq;
            ProductId = productId;
        }
        public long ProductId { get; set; }
        public long FaqId { get; set; }
        public string AnswerFaq { get; set; }
    }
}
