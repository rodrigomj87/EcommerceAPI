using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class ClienteEndereco : Entity
    {
        public Guid ClienteId { get; set; }
        public string Logradouro { get; set;}
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public Guid CidadeId { get; set; }
        public string NomeRecebedor { get; set; }
        public bool EhEnderecoPadrao { get; set; }
        public Cliente Cliente { get; set; }
        public Cidade Cidade { get; set; }

    }
}
