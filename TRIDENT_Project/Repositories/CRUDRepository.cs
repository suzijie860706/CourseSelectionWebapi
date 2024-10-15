using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TRIDENT_Project.Data;
using System.Reflection;
using NuGet.Protocol;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;

namespace TRIDENT_Project.Repositories
{
    public class CRUDRepository<TEntity, TContext> : ICRUDRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;
        //TODO Logger

        public CRUDRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// 新增傳入的實體資料至資料庫
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateException"></exception>
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                var reslut = await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return reslut.Entity;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("新增資料重複", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"資料庫新增異常", ex);
            }
        }

        /// <summary>
        /// 更新傳入資料到資料庫
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"資料庫更新異常", ex);
            }

        }

        public async Task DeleteAsync(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"資料庫刪除異常", ex);
            }

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
