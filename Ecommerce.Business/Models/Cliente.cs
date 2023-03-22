using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<PedidoVenda> PedidoVenda { get; set; }
        public IEnumerable<ClienteEndereco> ClienteEnderecos { get; set; }
    }
}
