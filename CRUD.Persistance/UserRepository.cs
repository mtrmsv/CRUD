using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class UserRepository : Repository<CRUD.Domain.Entities.Users.User>, IUserRepository
    {
        internal UserRepository( CRUD.Persistance.Contexts.DataBaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
