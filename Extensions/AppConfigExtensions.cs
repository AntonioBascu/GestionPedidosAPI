using GestionPedidos.Data;
using GestionPedidosAPI.Utilities.Models;

namespace GestionPedidosAPI.Extensions
{
    public static class AppConfigExtensions
    {
        public static IApplicationBuilder UseProductionConfiguration(this IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Error");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            return app;
        }

        public static IApplicationBuilder ConfigureCORS(this IApplicationBuilder app)
        {
            app.UseCors(options => options
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            return app;
        }

        public static IServiceCollection AddAppConfig(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            return services;
        }
    }
}
