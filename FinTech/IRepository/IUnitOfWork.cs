using FinTech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Contribution> Contributions { get; }
        IGenericRepository<ContributionType> ContributionTypes { get; }
        Task Save();
    }
}
