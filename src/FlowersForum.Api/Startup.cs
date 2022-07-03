using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using FlowersForum.Data;
using FlowersForum.Api.Extensions;
using FlowersForum.Api.Middleware;
using FlowersForum.Data.Repositories;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using FlowersForum.Services;
using FlowersForum.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;

namespace FlowersForum.Api
{
    public class Startup
    {
        readonly string CorsWithOriginsPolicyName = "_corsWithOriginsPolicyName";
        private readonly AppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SettingParser.Parse<AppSettings>(configuration, out _appSettings);
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
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwagger(_appSettings.Authentication);
            services.AddFlowerForumAuth(Configuration);
            services.AddAutoMapper();
            services.AddFlowerForumRepositories(Configuration);
            services.AddFlowerForumServices();
            services.AddAuthentication(options =>

             {

                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

             })

            .AddJwtBearer(async x =>

            {

                var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(

                    $"https://accounts.google.com/.well-known/openid-configuration",

                    new OpenIdConnectConfigurationRetriever(),

                    new HttpDocumentRetriever());




                var discoveryDocument = await configurationManager.GetConfigurationAsync();



                x.RequireHttpsMetadata = true;

                x.SaveToken = true;

                x.TokenValidationParameters = new TokenValidationParameters

                {

                    //ValidateIssuer = true,

                    //ValidIssuer = discoveryDocument.Issuer,

                    //ValidateIssuerSigningKey = true,

                    //IssuerSigningKeys = discoveryDocument.SigningKeys,

                    ////ValidAudience = _appSettings.Authentication.Audience,

                    ////ValidateAudience = true,

                    //ValidateLifetime = true,

                    //ClockSkew = TimeSpan.FromMinutes(1)
                };

            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BaseRepository<BaseModel, BaseEntity>)))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(SectionService)))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();


            builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>().InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FlowersForumDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseCors(CorsWithOriginsPolicyName);

            dbContext.Database.Migrate();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flowers Forum");
                c.OAuthClientId(_appSettings.Authentication.ClientId);
                c.OAuthClientSecret(_appSettings.Authentication.ClientSecret);
                c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
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
