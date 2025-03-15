using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.ProductsAgg.ValueObjects;

namespace Shop.Application.ProductAgg.AddFaq
{
    public class AddFaqCommand : IRequest
    {
        public AddFaqCommand(long productId, string question, string userName)
        {
            ProductId = productId;
            Question = question;
            UserName = userName;
        }
        public long ProductId { get; set; }
        public string Question { get; private set; }
        public string UserName { get; private set; }
    }
}
