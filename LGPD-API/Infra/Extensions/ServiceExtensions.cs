﻿using AutoMapper;
using LGPD_API.AutoMapping;
using LGPD_API.Infra.Exceptions;
using LGPD_MDE.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LGPD_API.Infra.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterWebApiServices(this IServiceCollection services)
        {
            #region Units Of Work
            // TODO: Write some code
            #endregion

            #region AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMappingApi());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion
            return services;
        }

        public static IServiceCollection RegisterPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsExclusive", policy => policy.RequireClaim("Plan", "EXCLUSIVE"));
            });
            return services;
        }

        public static IServiceCollection AddJWTAuth(this IServiceCollection services, IConfiguration configuration, bool enableCors = true)
        {
            if (enableCors)
                services.AddCors();
            var key = new SymmetricSecurityKey(Convert.FromBase64String(configuration["Security:AudienceSecret"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ClockSkew = TimeSpan.Zero,
                            IssuerSigningKey = key,
                            RequireSignedTokens = true,
                            RequireExpirationTime = true,
                            ValidateLifetime = true,
                            ValidateAudience = true,
                            ValidAudience = configuration["Security:AudienceId"],
                            ValidateIssuer = true,
                            ValidIssuer = configuration["Security:Issuer"]
                        };
                    });
            services.AddHttpContextAccessor();
            return services;
        }

        public static IServiceCollection AddSQLDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LgpdDbContext>(options =>
            {
                var connetionString = configuration.GetConnectionString("LgpdContext");
                options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
            });
            return services;
        }

        public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandler>();
        }
    }
}
