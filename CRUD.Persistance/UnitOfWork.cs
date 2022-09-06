using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class UnitOfWork : Base.UnitOfWork, IUnitOfWork
	{
		//public UnitOfWork() : base()
		//{
		//}

		public UnitOfWork() 
		{
		}

		// **************************************************
		//private IXXXXXRepository _xXXXXRepository;

		//public IXXXXXRepository XXXXXRepository
		//{
		//	get
		//	{
		//		if (_xXXXXRepository == null)
		//		{
		//			_xXXXXRepository =
		//				new XXXXXRepository(DatabaseContext);
		//		}

		//		return _xXXXXRepository;
		//	}
		//}
		// **************************************************

		// **************************************************
		private IUserRepository _userRepository;

		public IUserRepository UserRepository
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository =
						new UserRepository(DatabaseContext);
				}

				return _userRepository;
			}
		}
		// **************************************************
		// **************************************************
		private IRoleRepository _roleRepository;

		public IRoleRepository RoleRepository
		{
			get
			{
				if (_roleRepository == null)
				{
					_roleRepository =
						new RoleRepository (DatabaseContext);
				}

				return _roleRepository;
			}
		}

        public IRoleRepository Repository => throw new NotImplementedException();
        // **************************************************

        // **************************************************
    }
}
