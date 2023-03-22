using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class Carrinho : Entity
    {
        public Guid ClienteId { get; set; }
        public Guid ProdutoVariacaoId { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public int Parcelas { get; set; }
        public bool GerouPedido { get; set; }

        public Cliente Cliente { get; set; }
        public ProdutoVariacao ProdutoVariacao { get; set; }
    }
}
