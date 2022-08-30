using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SceptrumProject.Domain.Entities;

namespace SceptrumProject.Infra.Data.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(p => p.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Preco)
                .HasPrecision(10, 2);

            builder
                .HasOne(e => e.Categoria)
                .WithMany(e => e.Produtos)
                .HasForeignKey(e => e.CategoriaId);
        }
    }
}
