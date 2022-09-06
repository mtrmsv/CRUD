using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public interface IUserRepository : Base.IRepository<CRUD.Domain.Entities.Users.User>
    {
    }
}
