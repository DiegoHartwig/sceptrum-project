using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateCleanArch.Domain.Entities;

namespace TemplateCleanArch.Infra.Data.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(p => p.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasData(
                    new Categoria(1, "Informática"),
                    new Categoria(2, "Livros"),
                    new Categoria(3, "Acessórios")
                );
        }
    }
}
