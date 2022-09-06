using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
	public class Repository<T> : Base.Repository<T> where T : CRUD.Domain.SeedWork.BaseEntity
	{
		internal Repository( CRUD.Persistance.Contexts.DataBaseContext databaseContext) : base(databaseContext)
		{
		}

		//public override void Insert(T entity)
		//{
		//	base.Insert(entity);
		//}

		public override void Insert(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			//entity.InsertDateTime = Models.Utility.Now;

			DbSet.Add(entity);
		}

		//public override void Delete(T entity)
		//{
		//	entity.IsDeleted = true;

		//	Update(entity);
		//}
	}
}
