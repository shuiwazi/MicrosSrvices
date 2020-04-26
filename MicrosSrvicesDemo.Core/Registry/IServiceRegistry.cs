using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.MicroService.Core.Registry
{
    /// <summary>
    /// 服务注册
    /// </summary>
   public interface IServiceRegistry
   {
        /// <summary>
        /// 注册服务
        /// </summary>
        void Register(ServiceRegistryConfig serviceNode);

        /// <summary>
        /// 撤销服务
        /// </summary>
        void Deregister(ServiceRegistryConfig serviceNode);
    }
}
