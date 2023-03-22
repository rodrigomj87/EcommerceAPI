using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Mappings
{
    public class ProdutoVariacaoMapping : IEntityTypeConfiguration<ProdutoVariacao>
    {
        public void Configure(EntityTypeBuilder<ProdutoVariacao> builder)
        {
            builder.HasKey(pv => pv.Id);

            builder.Property(pv => pv.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(pv => pv.valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(pv => pv.Produto)
                .WithMany(p => p.ProdutoVariacoes)
                .HasForeignKey(pv => pv.ProdutoId);

            builder.HasMany(pv => pv.ProdutoVariacaoDetalhe)
                .WithOne(pvd => pvd.ProdutoVariacao)
                .HasForeignKey(pvd => pvd.ProdutoVariacaoId);

            builder.ToTable("ProdutoVariacoes");
        }
    }

}
