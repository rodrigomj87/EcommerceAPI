using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Mappings
{
    public class ClienteEnderecoMapping : IEntityTypeConfiguration<ClienteEndereco>
    {
        public void Configure(EntityTypeBuilder<ClienteEndereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(e => e.Complemento)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(e => e.NomeRecebedor)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(e => e.Cliente)
                .WithMany(c => c.ClienteEnderecos)
                .HasForeignKey(e => e.ClienteId);

            builder.HasOne(e => e.Cidade)
                .WithMany()
                .HasForeignKey(e => e.CidadeId);

            builder.ToTable("ClientesEnderecos");
        }
    }

}
