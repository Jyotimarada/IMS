using IMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> Get(int id, CancellationToken cancellationToken);
        IQueryable<T> GetAll(CancellationToken cancellationToken);

    }
}
