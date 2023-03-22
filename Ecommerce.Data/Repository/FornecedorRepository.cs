using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Models;
using Ecommerce.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DataDbContext context) : base(context)
        {
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            var fornecedor = await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (fornecedor == null)
            {
                throw new InvalidOperationException("Fornecedor não encontrado.");
            }

            return fornecedor;
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            var fornecedor = await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (fornecedor == null)
            {
                throw new InvalidOperationException("Fornecedor não encontrado.");
            }

            return fornecedor;
        }
    }
}