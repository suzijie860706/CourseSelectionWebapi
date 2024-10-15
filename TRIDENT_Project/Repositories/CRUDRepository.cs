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
        /// <exception cref="KeyNotFoundException">資料庫更新錯誤</exception>
        /// <exception cref="ValidationException">驗證錯誤</exception>
        /// <exception cref="OperationCanceledException">執行被中斷</exception>
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                throw new Exception();
                var reslut = await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return reslut.Entity;
            }
            //TODO:Logger
            catch (Exception ex)
            {
                throw new Exception($"資料庫操作異常 {nameof(CreateAsync)} Fail", ex);
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
            //TODO:Logger
            catch (Exception ex)
            {
                throw new Exception($"資料庫操作異常 {MethodBase.GetCurrentMethod()?.Name} Fail", ex);
            }

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
