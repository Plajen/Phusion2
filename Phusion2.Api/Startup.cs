using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Phusion2.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Phusion2.Api.Configuration;
using MediatR;
using Phusion2.Application.Interfaces;
using Phusion2.Application.Services;
using Phusion2.Domain.Interfaces;
using Phusion2.Infra.Repository;
using Phusion2.Infra.UnitOfWork;
using Phusion2.Domain.Core.Bus;
using Phusion2.Domain.Core.Notifications;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Phusion2.Api
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
            services.AddControllers();

            services.AddSwaggerGen(c => { //<-- NOTE 'Add' instead of 'Configure'
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Phusion2.API",
                    Version = "v1"
                });
            });
            services.AddDbContext<Phusion2Context>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("Data Source=localhost;Initial Catalog=fagron;User ID=sa;Password=123abc"));
                cfg.EnableSensitiveDataLogging(true);
                cfg.LogTo(Console.WriteLine);
            });

            services.AddAutoMapperSetup();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddMediatR(assemblies);

            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IProfessionAppService, ProfessionAppService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Phusion2.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
