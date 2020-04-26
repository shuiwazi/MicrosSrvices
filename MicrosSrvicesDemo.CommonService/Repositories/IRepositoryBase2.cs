using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.MicroService.CommonService.Repositories
{
    /// <summary>
    /// 通用仓储接口，根据id泛型查找
    /// T 为实体
    /// TId 为实体Id
    /// </summary>
   public interface IRepositoryBase2<T,TId>
    {
        Task<T> GetByIdAsync(TId id);
        Task<bool> IsExistAsync(TId id); 
    }
}
