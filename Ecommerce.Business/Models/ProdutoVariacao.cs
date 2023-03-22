using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class ProdutoVariacao : Entity
    {
        public Guid ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal valor { get; set; }

        public Produto Produto { get; set; }

        public IEnumerable<ProdutoVariacaoDetalhe>? ProdutoVariacaoDetalhe { get; set; }
    }
}
