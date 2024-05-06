using IMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Repositories
{
    /// <summary>
    /// Interface for BaseRepository.
    /// </summary>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Create entity.
        /// </summary>
        Task Create(T entity);

        /// <summary>
        /// Updates entity.
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Deletes entity.
        /// </summary>
        void Delete(T entity);

        /// <summary>
        /// Get entity with id
        /// </summary>
        Task<T?> Get(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Get all entities
        /// </summary>
        IQueryable<T> GetAll(CancellationToken cancellationToken);

    }
}
