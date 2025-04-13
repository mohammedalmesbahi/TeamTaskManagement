using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTaskManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task CompleteAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task RollbackAsync(CancellationToken cancellationToken = default(CancellationToken));

    }
}
