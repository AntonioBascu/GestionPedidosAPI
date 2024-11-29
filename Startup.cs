using GestionPedidos.Data;
using GestionPedidosAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
            
            //Identity Core
            services
                .AddIdentityApiEndpoints<Usuario>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            { 
                options.User.RequireUniqueEmail = true;
            });

            //DbContext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestion Pedidos API", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(options => options
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGroup("/api").MapIdentityApi<Usuario>();

                endpoints.MapPost("/api/signup", async (UserManager<Usuario> userManager, [FromBody]RegistroUsuarioModel registroUsuarioModel) =>
                {
                    Usuario usuario = new Usuario()
                    {
                        UserName = registroUsuarioModel.UserName,
                        Email = registroUsuarioModel.Email
                    };

                    var resultado = await userManager.CreateAsync(usuario, registroUsuarioModel.Password);

                    if (resultado.Succeeded) return Results.Ok(resultado);
                    else return Results.BadRequest(resultado);
                });

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
