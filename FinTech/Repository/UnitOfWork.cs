using FinTech.Data;
using FinTech.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Contribution> _contributions;
        private IGenericRepository<ContributionType> _contributionTypes;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Contribution> Contributions => _contributions ??= new GenericRepository<Contribution>(_context);

        public IGenericRepository<ContributionType> ContributionTypes => _contributionTypes ??= new GenericRepository<ContributionType>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
