using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.ProductAgg.AddComment
{
    public class AddCommentCommand : IRequest
    {
        public AddCommentCommand(int rate, string userName, string userComment)
        {
            Rate = rate;
            UserName = userName;
            UserComment = userComment;
        }
        public int Rate { get; set; }
        public string UserName { get; set; }
        public string UserComment { get; set; }
    }

}
