using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;
namespace Treinamento.Entities
{
    public class Pedido
    {
        
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
        public TipoPedido TipoPedido { get; set; }
        public DateTime Data { get; set; }
        protected bool Desligado { get; set; }
    }
}
