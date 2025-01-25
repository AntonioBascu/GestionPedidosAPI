using GestionPedidos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GestionPedidosAPI.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerExplorer(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestion Pedidos API", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseDevelopmentConfiguration(this IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }

    }
}
