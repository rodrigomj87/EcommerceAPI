using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Mappings
{
    public class MetodoPagamentoMapping : IEntityTypeConfiguration<MetodoPagamento>
    {
        public void Configure(EntityTypeBuilder<MetodoPagamento> builder)
        {

            builder.HasKey(mp => mp.Id);

            builder.Property(mp => mp.Nome)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(mp => mp.Descricao)
                   .HasColumnType("varchar(100)");

            builder.Property(mp => mp.Ativo)
                   .HasColumnType("bit")
                   .HasDefaultValue(true)
                   .IsRequired();

            builder.ToTable("MetodosPagamento");

        }
    }
}
