using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RuanMou.MicroService.Core.Registry;
using RuanMou.MicroService.Core.Registry.Extentions;
using RuanMou.MicroService.TeamService.Context;
using RuanMou.MicroService.TeamService.Repositories;
using RuanMou.MicroService.TeamService.Services;

namespace RuanMou.MicroService.TeamService
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
            // 1��ע�������ĵ�IOC����
            services.AddDbContext<TeamContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            // 2��ע���Ŷ�service
            services.AddScoped<ITeamService, TeamServiceImpl>();

            // 3��ע���ŶӲִ�
            services.AddScoped<ITeamRepository, TeamRepository>();

            // 5����ӷ���ע������
            services.AddConsulRegistry(Configuration);

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

            // 1��consul����ע��
            app.UseConsulRegistry();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
