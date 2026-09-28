using GestionPedidosAPI.Data;
using GestionPedidosAPI.Controllers;
using GestionPedidosAPI.Extensions;
using GestionPedidosAPI.Utilities.Models;
using Humanizer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestionPedidosAPI.Utilities.Mappings;

namespace GestionPedidos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services
                .AddSwaggerExplorer()
                .InjectDbContext(Configuration)
                .AddIdentityEndPointsAndStores()
                .ConfigureIdentityOptions()
                .AddIdentityAuth(Configuration)
                .AddAppConfig(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ////Configure the HTTP request pipeline.
            //if (env.IsDevelopment())
            //{
            app.UseDevelopmentConfiguration();
            //}
            //else
            //{
            //    app.UseProductionConfiguration();
            //}


            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //    dbContext.Database.Migrate();
            //}

            app.ConfigureCORS()
               .UseHttpsRedirection()
               .UseRouting()
               .UseIdentityAuthMiddlewares()
               .UseEndpoints(endpoints =>
                {

                    endpoints.MapGroup("/api")
                        .MapUsuarioIdentityEndpoints()
                        .MapUsuarioEndPoints();
                    endpoints.MapControllers();
                });

            app.Run(context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
        }
    }
}
