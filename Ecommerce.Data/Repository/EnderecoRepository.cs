using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Models;
using Ecommerce.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            var endereco = await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);

            if (endereco == null)
            {
                throw new InvalidOperationException("Endereço não encontrado para o fornecedor informado.");
            }

            return endereco;
        }
    }
}