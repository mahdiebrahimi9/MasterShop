using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products.DTOs
{
    public class GetCommentListDto
    {

        public long ProductId { get;  set; }
        public int Rate { get;  set; }
        public string UserName { get;  set; }
        public string UserComment { get;  set; }
        public DateTime CreateAt { get;  set; }
    }
}
