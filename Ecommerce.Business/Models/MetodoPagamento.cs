namespace Ecommerce.Business.Models
{
    public class MetodoPagamento : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }
    }
}