using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class ProdutoVariacaoDetalhe : Entity
    {
        public Guid ProdutoVariacaoId { get; set; }
        public string Item { get; set; }
        public string Descricao { get; set; }

        public ProdutoVariacao ProdutoVariacao { get; set; }
    }
}
