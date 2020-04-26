using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.MicroService.CommonService.Repositories
{
    /// <summary>
    /// 通用仓储实现
    /// </summary>
    public class RepositoryBase<T, TId> : IRepositoryBase<T>, IRepositoryBase2<T, TId> where T : class
    {
        public DbContext dbContext;

        public void Create(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
           return Task.FromResult(dbContext.Set<T>().AsEnumerable());
        }

        public Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return Task.FromResult(dbContext.Set<T>().Where(expression).AsEnumerable());
        }

        public async Task<T> GetByIdAsync(TId id)
        {
          return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExistAsync(TId id)
        {
            return await dbContext.Set<T>().FindAsync(id) != null;
        }

        public async Task<bool> SavaAsync()
        {
          return await dbContext.SaveChangesAsync() > 0 ;
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}
