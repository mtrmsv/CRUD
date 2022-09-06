using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
	public interface IUnitOfWork : Base.IUnitOfWork
	{
		// **********
		IUserRepository UserRepository { get; }
		// **********

		// **********
		IRoleRepository Repository { get; }
		// **********
	}
}
