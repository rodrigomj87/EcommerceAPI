using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(c => c.Ativo)
                .IsRequired()
                .HasColumnName("Ativo")
                .HasColumnType("bit")
                .HasDefaultValue(true);

            builder.HasMany(c => c.CategoriaProduto)
            .WithOne(cp => cp.Categoria)
            .HasForeignKey(cp => cp.CategoriaId);

            builder.ToTable("Categorias");
        }
    }
}
