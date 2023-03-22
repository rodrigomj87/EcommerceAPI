using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Data.Mappings
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasOne(c => c.UnidadeFederacao)
                .WithMany()
                .HasForeignKey(c => c.UnidadeFederacaoId);

            builder.ToTable("Cidades");
        }
    }
}
