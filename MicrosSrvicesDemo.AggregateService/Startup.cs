using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RuanMou.MicroService.AggregateService.Services;
using RuanMou.MicroService.Core.Cluster;
using RuanMou.MicroService.Core.Registry.Extentions;

namespace RuanMou.MicroService.AggregateService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            // 2、注册consul服务发现
            services.AddConsulDiscovery(Configuration);

            // 3、注册负载均衡
            services.AddSingleton<ILoadBalance, RandomLoadBalance>();

            // 4、注册team服务
            services.AddSingleton<ITeamServiceClient, HttpTeamServiceClient>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
