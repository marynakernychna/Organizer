using AutoMapper;
using Core.Helpers;
using Core.Helpers.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddAutoMapper(
            this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthenticationMapper());
            });

            var mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigJwtOptions(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.Configure<JwtOptions>(config.GetSection("JwtOptions"));
        }

        public static void Configures(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.Configure<AppSettings>(config);
        }
    }
}
