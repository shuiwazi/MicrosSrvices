using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.MicroService.CommonService.Repositories
{
    
    /// <summary>
    /// 通用的仓储接口
    /// </summary>
   public interface IRepositoryBase<T>
   {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T,bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SavaAsync();
    }
}
