using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Base
{
	public abstract class UnitOfWork : IUnitOfWork
	{
		//public UnitOfWork() : base()
		//{
		//}

		//public UnitOfWork(Tools.Options options) : base()
		//{
		//	Options = options;
		//}

		// **********
		//protected Tools.Options Options { get; set; }
		// **********

		// **********
		// **********
		// **********
		private CRUD.Persistance.Contexts.DataBaseContext _databaseContext;
		// **********
		public string ConnectionString { get; set; }
		// **********
		/// <summary>
		/// Lazy Loading = Lazy Initialization
		/// </summary>
		internal CRUD.Persistance.Contexts.DataBaseContext DatabaseContext
		{
			get
			{
				if (_databaseContext == null)
				{
					var optionsBuilder =
						new DbContextOptionsBuilder< CRUD.Persistance.Contexts.DataBaseContext>();

					//switch (Options.Provider)
					//{
					//	case Tools.Enums.Provider.SqlServer:
					//		{
								optionsBuilder.UseSqlServer
									(connectionString: ConnectionString);

						//		break;
						//	}

						//case Tools.Enums.Provider.MySql:
						//	{
						//		//optionsBuilder.UseMySql
						//		//	(connectionString: Options.ConnectionString);

						//		break;
						//	}

						//case Tools.Enums.Provider.Oracle:
						//	{
						//		//optionsBuilder.UseOracle
						//		//	(connectionString: Options.ConnectionString);

						//		break;
						//	}

						//case Tools.Enums.Provider.PostgreSQL:
						//	{
						//		//optionsBuilder.UsePostgreSQL
						//		//	(connectionString: Options.ConnectionString);

						//		break;
						//	}

						//case Tools.Enums.Provider.InMemory:
						//	{
						//		optionsBuilder.UseInMemoryDatabase(databaseName: "Temp");

						//		break;
						//	}

						//default:
						//	{
						//		break;
						//	}
					//}

					_databaseContext =
						new CRUD.Persistance.Contexts.DataBaseContext(options: optionsBuilder.Options);
				}

				return _databaseContext;
			}
		}
		// **********
		// **********
		// **********

		Repository<T> IUnitOfWork.GetRepository<T>()
		{
			return new Repository<T>(databaseContext: DatabaseContext);
		}

		public virtual void Save()
		{
			DatabaseContext.SaveChanges();
		}

		public virtual async System.Threading.Tasks.Task SaveAsync()
		{
			await DatabaseContext.SaveChangesAsync();
		}

		// **********
		/// <summary>
		/// To detect redundant calls
		/// </summary>
		public bool IsDisposed { get; protected set; }
		// **********

		/// <summary>
		/// Public implementation of Dispose pattern callable by consumers.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);

			System.GC.SuppressFinalize(this);
		}

		/// <summary>
		/// https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (IsDisposed)
			{
				return;
			}

			if (disposing)
			{
				// TODO: dispose managed state (managed objects).

				if (_databaseContext != null)
				{
					_databaseContext.Dispose();
					_databaseContext = null;
				}
			}

			// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
			// TODO: set large fields to null.

			IsDisposed = true;
		}

		~UnitOfWork()
		{
			Dispose(false);
		}
	}
}
