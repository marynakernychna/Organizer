using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(
            this IServiceCollection service,
            string connectionString)
        {
            service.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    connectionString, x => x.UseNetTopologySuite()));
        }

        public static void AddIdentityDbContext(
            this IServiceCollection service)
        {
            service.AddIdentity<User, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultTokenProviders().AddRoles<IdentityRole>();
        }
    }
}
