using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ZooMeet.Infrastructure.Context;
using ZooMeet.Domain.Repositories;
using ZooMeet.Infrastructure.Repositories;
using ZooMeet.Application.Services;

namespace ZooMeet.ApiBff
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configurar o DbContext com o Entity Framework Core
            services.AddDbContext<ZooMeetDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Injeção de dependência dos repositórios e serviços
            services.AddScoped<IClinicaVeterinariaRepository, ClinicaVeterinariaRepository>();
            services.AddScoped<ClinicaVeterinariaService>();

            // Configurar autenticação JWT
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.Authority = "https://seu-provedor-de-autenticacao.com"; // Troque para o provedor de autenticação
            //        options.Audience = "zoomeetapi";  // Configurar o Audience
            //    });

            // Configuração de controle e endpoints
            services.AddControllers();

            // Configurar o Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZooMeet API", Version = "v1" });

                // Configurar autenticação JWT no Swagger
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securityScheme, new[] { "Bearer" } }
                };

                c.AddSecurityRequirement(securityRequirement);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Configuração de autenticação e autorização
            app.UseAuthentication();
            app.UseAuthorization();

            // Configuração do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZooMeet API V1");
                c.RoutePrefix = string.Empty;  // Deixa o Swagger disponível na raiz da aplicação (opcional)
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}