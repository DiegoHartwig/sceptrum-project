using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TemplateCleanArch.Application.Interfaces;
using TemplateCleanArch.Application.Mapeamentos;
using TemplateCleanArch.Application.Services;
using TemplateCleanArch.Domain.Interfaces;
using TemplateCleanArch.Infra.Data.DBContext;
using TemplateCleanArch.Infra.Data.Repositories;

namespace TemplateCleanArch.Infra.IoC
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

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("TemplateCleanArch.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
