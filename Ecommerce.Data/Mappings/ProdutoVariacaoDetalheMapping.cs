using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Mappings
{
    public class ProdutoVariacaoDetalheMapping : IEntityTypeConfiguration<ProdutoVariacaoDetalhe>
    {
        public void Configure(EntityTypeBuilder<ProdutoVariacaoDetalhe> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Item)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.HasOne(pvd => pvd.ProdutoVariacao)
                .WithMany(pv => pv.ProdutoVariacaoDetalhe)
                .HasForeignKey(pvd => pvd.ProdutoVariacaoId);

            builder.ToTable("ProdutoVariacaoDetalhes");
        }
    }

}
