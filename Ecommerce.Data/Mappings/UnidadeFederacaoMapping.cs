using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Mappings
{
    public class UnidadeFederacaoMapping : IEntityTypeConfiguration<UnidadeFederacao>
    {
        public void Configure(EntityTypeBuilder<UnidadeFederacao> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Sigla)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("UnidadesFederacao");
        }
    }
}
