using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class PedidoVendaProduto : Entity
    {
        public Guid PedidoVendaId { get; set; }
        public Guid ProdutoVariacaoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public PedidoVenda PedidoVenda { get; set; }
        public ProdutoVariacao ProdutoVariacao { get; set; }
    }
}
