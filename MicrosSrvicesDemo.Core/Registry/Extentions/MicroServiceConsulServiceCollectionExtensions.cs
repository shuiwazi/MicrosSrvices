using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuanMou.MicroService.Core.Registry.Extentions
{
    /// <summary>
    /// Console 注册中心扩展(加载配置)
    /// </summary>
    public static class MicroServiceConsulServiceCollectionExtensions
    {
        // consul服务注册
        public static IServiceCollection AddConsulRegistry(this IServiceCollection services, IConfiguration configuration)
        {
            // 1、加载Consul服务注册配置
            services.Configure<ServiceRegistryConfig>(configuration.GetSection("ConsulRegistry"));

            // 2、注册consul注册
            services.AddSingleton<IServiceRegistry, ConsulServiceRegistry>();
            return services;
        }

        // consul服务发现
        public static IServiceCollection AddConsulDiscovery(this IServiceCollection services,IConfiguration configuration)
        {
            // 1、加载Consul服务发现配置
           // services.Configure<ServiceDiscoveryConfig>(configuration.GetSection("ConsulDiscovery"));

            // 2、注册consul服务发现
            services.AddSingleton<IServiceDiscovery, ConsulServiceDiscovery>();
            return services;
        }

    }
}
