
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
            services.AddAuthentication(cfg => cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });
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
