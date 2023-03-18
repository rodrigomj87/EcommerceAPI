using Ecommerce.Business.Models;

namespace Ecommerce.Business.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<bool> Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}