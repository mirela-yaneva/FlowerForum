
using System;
using System.Collections.Generic;
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
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                            Scopes = new Dictionary<string, string> { { "email", "email" }, { "profile", "profile" } }
                        }
                    }
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                            Scheme = "oauth2",
                            Name = "oauth2",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
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
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                })
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
