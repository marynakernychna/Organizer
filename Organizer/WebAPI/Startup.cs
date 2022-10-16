using WebAPI.Middlewares;
using WebAPI.ServiceExtension;
using Core;
using Core.Helpers;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(
            IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(
            IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowAnyOrigin()
            );

            app.UseAuthentication();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddControllers();

            services.AddIdentityDbContext();

            services.AddDbContext(
                Configuration
                    .GetConnectionString("DefaultConnection"));

            services.AddAuthentication();

            services.Configures(
                Configuration.GetSection(nameof(AppSettings)));

            services.AddAutoMapper();

            services.AddResponseCaching();

            services.ConfigJwtOptions(Configuration);

            services.AddJwtAuthentication(Configuration);

            services.AddMvcCore()
                    .AddRazorViewEngine();

            services.AddSwagger();
        }
    }
}
