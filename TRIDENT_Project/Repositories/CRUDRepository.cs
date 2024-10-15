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
                var reslut = await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return reslut.Entity;
            }
            //TODO:Logger
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("資料庫更新錯誤", ex);
            }
            catch (ValidationException ex)
            {
                throw new DbUpdateException("驗證錯誤", ex);
            }
            catch (OperationCanceledException ex)
            {
                throw new DbUpdateException("執行被中斷", ex);
            }
        }

        /// <summary>
        /// 更新傳入資料到資料庫
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException">儲存到資料庫時資料已被修改</exception>
        /// <exception cref="DbUpdateException">資料庫更新錯誤</exception>
        /// <exception cref="OperationCanceledException">執行被中斷</exception>
        public async Task UpdateAsync(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            //TODO:Logger
            catch (DbUpdateConcurrencyException)
            {
                throw; //儲存到資料庫時資料已被修改
            }
            catch (DbUpdateException)
            {
                throw; // 資料庫更新錯誤
            }
            catch (OperationCanceledException)
            {
                throw; //執行被中斷
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
