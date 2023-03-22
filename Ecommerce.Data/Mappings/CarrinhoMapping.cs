using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Business.Models;

namespace Ecommerce.Data.Mappings
{
    public class CarrinhoMapping : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ClienteId)
                .IsRequired()
                .HasColumnName("ClienteId");

            builder.Property(c => c.ProdutoVariacaoId)
                .IsRequired()
                .HasColumnName("ProdutoVariacaoId");

            builder.Property(c => c.Valor)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Quantidade)
                .IsRequired()
                .HasColumnName("Quantidade");

            builder.Property(c => c.Parcelas)
                .IsRequired()
                .HasColumnName("Parcelas");

            builder.Property(c => c.GerouPedido)
                .IsRequired()
                .HasColumnName("GerouPedido")
                .HasColumnType("bit")
                .HasDefaultValue(false);

            builder.HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId);

            builder.HasOne(c => c.ProdutoVariacao)
                .WithMany()
                .HasForeignKey(c => c.ProdutoVariacaoId);

            builder.ToTable("Carrinhos");
        }
    }

}
