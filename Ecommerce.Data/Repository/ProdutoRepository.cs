using Ecommerce.Business.ENUMs;
using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Models;
using Ecommerce.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            var produto = await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            if (produto == null)
            {
                throw new InvalidOperationException("Produto não encontrado.");
            }

            return produto;

        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores(int pageNumber, int pageSize, EProdutoOrder orderQuery, string searchTerm)
        {
            var skip = (pageNumber - 1) * pageSize;
            IQueryable<Produto> query = Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                        .Where(p => p.Ativo == true);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.Nome.ToLower().Contains(searchTerm.ToLower()));
            }

            switch (orderQuery)
            {
                case EProdutoOrder.NomeAsc:
                    query = query.OrderBy(p => p.Nome);
                    break;
                case EProdutoOrder.NomeDesc:
                    query = query.OrderByDescending(p => p.Nome);
                    break;
                case EProdutoOrder.PrecoAsc:
                    query = query.OrderBy(p => p.Valor);
                    break;
                case EProdutoOrder.PrecoDesc:
                    query = query.OrderByDescending(p => p.Valor);
                    break;
                default:
                    query = query.OrderBy(p => p.Nome);
                    break;
            }

            return await query.Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task<int> ObterTotalItens(string searchTerm)
        {
            return await Db.Produtos.CountAsync(p => p.Ativo && (searchTerm == null || p.Nome.Contains(searchTerm)));
        }
    }
}