using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class PedidoVenda : Entity
    {
        public string NumeroPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataPrevistaEntrega { get; set; }
        public Guid ClienteId { get; set; }
        public Guid EnderecoEntregaId { get; set; }
        public Guid MetodoPagamentoId { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal ValorFrete { get; set; }
        public Guid VendaStatusId { get; set; }

        public Cliente Cliente { get; set; }
        public ClienteEndereco EnderecoEntrega { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
        public VendaStatus VendaStatus { get; set; }

        public IEnumerable<PedidoVendaProduto> PedidoVendaProdutos { get; set; }

    }
}
