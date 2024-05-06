using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Repositories
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves the transaction.
        /// </summary>
        Task<int> Save(CancellationToken cancellationToken);
    }
}
