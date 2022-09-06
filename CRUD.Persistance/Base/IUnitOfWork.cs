using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Base
{
    public interface IUnitOfWork: System.IDisposable
    {
        bool IsDisposed { get; }

        void Save();

        System.Threading.Tasks.Task SaveAsync();

        Repository<T> GetRepository<T>() where T : CRUD.Domain.SeedWork.BaseEntity;
    }
}
