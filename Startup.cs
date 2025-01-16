using GestionPedidos.Data;
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

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme =
                x.DefaultChallengeScheme =
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(y =>
            {
                y.SaveToken = false;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT"]!))
                };
            });

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

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGroup("/api").MapIdentityApi<Usuario>();

                endpoints.MapPost("/api/signup", async (
                    UserManager<Usuario> userManager,
                    [FromBody] RegistroUsuarioModel registroUsuarioModel) =>
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

                endpoints.MapPost("/api/signin", async (
                   UserManager<Usuario> userManager,
                   [FromBody] LoginModel loginModel) =>
                {
                    var user = await userManager.FindByEmailAsync(loginModel.Email);

                    if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
                    {
                        var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT"]!));

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim("UserId", user.Id.ToString())
                            }),
                            Expires = DateTime.UtcNow.AddMinutes(10),
                            SigningCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256Signature)
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                        var token = tokenHandler.WriteToken(securityToken);

                        return Results.Ok(token);
                    }
                    else
                    {
                        return Results.BadRequest(new { message = "Email o contraseña incorrectos." });
                    }
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
