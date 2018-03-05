using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Treinamento.Presentation.MVC.Models
{
    public class PedidoModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
        public string TipoPedido { get; set; }
        public string Data { get; set; }
        protected bool Desligado { get; set; }
    }
}