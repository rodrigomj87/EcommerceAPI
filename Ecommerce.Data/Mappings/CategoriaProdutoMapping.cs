using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Mappings
{
    public class CategoriaProdutoMapping : IEntityTypeConfiguration<CategoriaProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            builder.HasKey(cp => new { cp.ProdutoId, cp.CategoriaId });

            builder.HasOne(cp => cp.Produto)
                .WithMany(p => p.CategoriaProduto)
                .HasForeignKey(cp => cp.ProdutoId);

            builder.HasOne(cp => cp.Categoria)
                .WithMany(c => c.CategoriaProduto)
                .HasForeignKey(cp => cp.CategoriaId);

            builder.ToTable("CategoriasProdutos");
        }
    }
}
