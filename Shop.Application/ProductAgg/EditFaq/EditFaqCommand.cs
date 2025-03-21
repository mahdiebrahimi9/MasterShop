﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.ProductAgg.EditFaq
{
    public class EditFaqCommand : IRequest
    {
        public EditFaqCommand(long productId, string question, string userName, long faqId)
        {
            ProductId = productId;
            Question = question;
            UserName = userName;
            FaqId = faqId;
        }
        public long ProductId { get; set; }
        public long FaqId { get; set; }
        public string Question { get; private set; }
        public string UserName { get; private set; }
    }
}
