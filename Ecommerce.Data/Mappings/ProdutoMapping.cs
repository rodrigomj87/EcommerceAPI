using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
           
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(1000)");

            builder.Property(p => p.Imagem)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Valor)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.DataCadastro)
                   .IsRequired();

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.HasMany(p => p.ProdutoVariacoes)
                   .WithOne(pv => pv.Produto)
                   .HasForeignKey(pv => pv.ProdutoId);

            builder.HasMany(p => p.CategoriaProduto)
                   .WithOne(cp => cp.Produto)
                   .HasForeignKey(cp => cp.ProdutoId);
        }
    }
}