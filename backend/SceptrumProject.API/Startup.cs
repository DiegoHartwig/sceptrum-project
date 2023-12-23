// Projeto: Sceptrum Project
// Autor: Diego Hartwig
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SceptrumProject.Domain.SecurityAccount;
using SceptrumProject.Infra.IoC;
using System.Text.Json.Serialization;

namespace SceptrumProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddInfrastructureAPI(Configuration);

            // Ativar autenticação e validar o token
            services.AddInfrastructureJwt(Configuration);

            services.AddInfrastructureSwagger();

            services
                .AddControllers();
                //.AddJsonOptions(options =>
                //{
                //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                //});

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRole seedUserRole)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SceptrumProject.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseRouting();

            seedUserRole.SeedRoles();
            seedUserRole.SeedUsers();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
