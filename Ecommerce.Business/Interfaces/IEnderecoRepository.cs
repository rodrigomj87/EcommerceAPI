using Ecommerce.Business.Models;

namespace Ecommerce.Business.Interfaces
{

    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
