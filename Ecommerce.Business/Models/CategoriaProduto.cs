using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class CategoriaProduto : Entity
    {
        public Guid ProdutoId { get; set; }
        public Guid CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
        public Produto Produto { get; set; }
    }
}
