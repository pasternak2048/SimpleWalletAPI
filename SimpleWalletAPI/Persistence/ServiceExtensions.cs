using Application.Common.Interfaces;
using Application.Repositories;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.Authentication;
using Persistence.Context;
using Persistence.Interceptors;
using Persistence.Repositories;
using Persistence.Services;
using System.Text;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));

            services.AddIdentityCore<AppUser>(opt => {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequiredUniqueChars = 0;
            })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddScoped<AuditableEntityInterceptor>();
            services.AddScoped<IBonusService, BonusService>();
        }
    }
}