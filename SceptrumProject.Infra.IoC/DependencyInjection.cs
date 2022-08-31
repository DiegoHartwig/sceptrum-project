using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using SceptrumProject.Application.Interfaces;
using SceptrumProject.Application.Mapeamentos;
using SceptrumProject.Application.Services;
using SceptrumProject.Domain.Interfaces;
using SceptrumProject.Infra.Data.DBContext;
using SceptrumProject.Infra.Data.Repositories;
using SceptrumProject.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using SceptrumProject.Domain.SecurityAccount;

namespace SceptrumProject.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
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

            // Cookie
            services.ConfigureApplicationCookie(options =>
                options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRole, SeedUserRole>();

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
