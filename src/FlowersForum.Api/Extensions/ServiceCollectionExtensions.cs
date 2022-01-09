
using AutoMapper.Extensions.ExpressionMapping;
using FlowersForum.Api.Middleware;
using FlowersForum.Api.Requirements;
using FlowersForum.Data;
using FlowersForum.Domain;
using FlowersForum.Domain.Constants;
using FlowersForum.Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace FlowersForum.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flower Forum", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                    });
            });
        }

        public static void AddFlowerForumRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FlowersForumDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddFlowerForumServices(this IServiceCollection services)
        {
            services.AddAutoMapper(mc =>
            {
                mc.AddExpressionMapping();
                mc.AddProfile(new Data.MapperProfile());
                mc.AddProfile(new Api.MapperProfile());
            });
        }

        public static void AddFlowerForumAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettingsSection = configuration.GetSection(typeof(JwtSettings).Name);
            JwtSettings settings = jwtSettingsSection.Get<JwtSettings>();
            services.Configure<JwtSettings>(jwtSettingsSection);

            services.AddAuthentication(cfg => cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = settings.SaveToken;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = settings.ValidateIssuer,
                        ValidateAudience = settings.ValidateAudience,
                        ValidateLifetime = settings.ValidateLifetime,
                        ValidateIssuerSigningKey = settings.ValidateIssuerSigningKey,
                        ValidIssuer = settings.Issuer,
                        ValidAudience = settings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(StringConstants.AdminPolicy, policy =>
                {
                    policy.Requirements.Add(new RoleRequirement(Role.Admin));
                    policy.RequireClaim(ClaimTypes.Role);
                });

                options.AddPolicy(StringConstants.UserPolicy, policy =>
                {
                    policy.Requirements.Add(new RoleRequirement(Role.User));
                    policy.RequireClaim(ClaimTypes.Role);
                });
            });

            services.AddSingleton<IAuthorizationHandler, RoleHandler>();

        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(mc =>
            {
                mc.AddExpressionMapping();
                mc.AddProfile(new MapperProfile());
                mc.AddProfile(new MapperProfile());
            });
        }
    }
}
