using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class RoleRepository : Repository<CRUD.Domain.Entities.Roles.Role> , IRoleRepository
    {
        internal RoleRepository(CRUD.Persistance.Contexts.DataBaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
