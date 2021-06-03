using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void UpdateMatchEntity(T updateEntity, T setEntity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);

    }
}
