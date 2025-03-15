using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.ProductAgg.EditComment
{
    public class EditCommentCommand : IRequest
    {
        public EditCommentCommand(long productId, int rate, string userName, string userComment)
        {
            ProductId = productId;
            Rate = rate;
            UserName = userName;
            UserComment = userComment;
        }
        public long ProductId { get; set; }
        public int Rate { get; set; }
        public string UserName { get; set; }
        public string UserComment { get; set; }
    }
}
