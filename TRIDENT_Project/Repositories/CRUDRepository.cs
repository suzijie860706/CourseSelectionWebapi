using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TRIDENT_Project.Data;
using System.Reflection;
using NuGet.Protocol;
using System.Runtime.InteropServices;

namespace TRIDENT_Project.Repositories
{
    public class CRUDRepository<TEntity, TContext> : ICRUDRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public CRUDRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity?> CreateAsync(TEntity entity)
        {
            var reslut = await _dbSet.AddAsync(entity);
            int count = await _context.SaveChangesAsync();
            if (count == 0) return null;

            return reslut.Entity;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
    }
}
