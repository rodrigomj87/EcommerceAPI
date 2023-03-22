using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class Cidade : Entity
    {
        public string Nome { get; set; }
        public Guid UnidadeFederacaoId { get; set; }

        public UnidadeFederacao UnidadeFederacao { get; set; }
    }
}
