using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sysplan.Agrimaldo.API.Middlewares;
using Sysplan.Agrimaldo.Domain.Interfaces.Repositories;
using Sysplan.Agrimaldo.Domain.Interfaces.Services;
using Sysplan.Agrimaldo.Domain.Services;
using Sysplan.Agrimaldo.Infra.Context;
using Sysplan.Agrimaldo.Infra.Repositories;

namespace Sysplan.Agrimaldo.API
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
            services.AddDbContext<SysplanAgrimaldoDatabase>(e =>
            {
                e.EnableSensitiveDataLogging();
                e.UseSqlServer(Configuration.GetConnectionString("SysplanAgrimaldoConnection"), a => a.MigrationsAssembly("Sysplan.Agrimaldo.API"));
            });

            services.AddSingleton<IRepository, SysplanAgrimaldoRepository>(serviceProvider =>
            {
                var dataBase = serviceProvider.GetService<SysplanAgrimaldoDatabase>();
                dataBase.Database.SetCommandTimeout(480);
                return new SysplanAgrimaldoRepository(dataBase);
            });
            services.AddTransient<IRepository, SysplanAgrimaldoRepository>();

            services.AddTransient<IClientService, ClientService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware(typeof(ErrorHandling));
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
