using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SceptrumProject.Application.Interfaces;
using SceptrumProject.Application.Mapeamentos;
using SceptrumProject.Application.Services;
using SceptrumProject.Domain.Interfaces;
using SceptrumProject.Domain.SecurityAccount;
using SceptrumProject.Infra.Data.DBContext;
using SceptrumProject.Infra.Data.Identity;
using SceptrumProject.Infra.Data.Repositories;
using System;

namespace SceptrumProject.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(options =>
                    options
                        .UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            // Serviços do Identity
            services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("SceptrumProject.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
