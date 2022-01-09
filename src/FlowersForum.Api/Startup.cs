using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;
using FlowersForum.Domain;
using FlowersForum.Data;
using FlowersForum.Api.Extensions;
using FlowersForum.Api.Middleware;
using FlowersForum.Data.Repositories;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Models;
using FlowersForum.Services;

namespace FlowersForum.Api
{
    public class Startup
    {
        readonly string CorsWithOriginsPolicyName = "_corsWithOriginsPolicyName";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var corsSettings = Configuration.GetSection(typeof(CorsSettings).Name).Get<CorsSettings>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsWithOriginsPolicyName,
                                  builder =>
                                  {
                                      builder.WithOrigins(corsSettings.Origins)
                                      .AllowAnyHeader();
                                  });
            });

            services.AddAutofac();
            services.AddControllers();

            services.AddDbContext<FlowersForumDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Sql")));

            services.AddSwagger();
            services.AddFlowerForumAuth(Configuration);
            services.AddAutoMapper();
            services.AddFlowerForumRepositories(Configuration);
            services.AddFlowerForumServices();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BaseRepository<BaseModel ,BaseEntity>)))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(SectionService)))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseCors(CorsWithOriginsPolicyName);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flowers Forum");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }

}
