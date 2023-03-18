using Ecommerce.Business.ENUMs;
using Ecommerce.Business.Models;

namespace Ecommerce.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores(int pageNumber, int pageSize, EProdutoOrder orderQuery, string searchTerm);
        Task<int> ObterTotalItens(string searchTerm);
    }
}