namespace Ecommerce.Business.Models
{
    public class Categoria : Entity
    {

        public string Nome { get; set; }
        public bool? Ativo { get; set; }

        public IEnumerable<CategoriaProduto>? CategoriaProduto { get; set; }
    }
}