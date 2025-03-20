using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.UserAgg;

namespace Shop.Infra.Persestent.Ef.UserAgg
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ShopContext context) : base(context)
        {
            
        }
    }
}
