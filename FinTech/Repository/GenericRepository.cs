using FinTech.Data;
using FinTech.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinTech.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.AddRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includedQuery in includes)
                {
                    query = query.Include(includedQuery);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var includedQuery in includes)
                {
                    query = query.Include(includedQuery);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
