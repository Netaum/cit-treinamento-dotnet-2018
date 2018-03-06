using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Treinamento.Presentation.MVC.Models
{
    public class PedidoModel
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória")]
        [StringLength(100, ErrorMessage = "Campo excedeu o número máximo de caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public string Numero { get; set; }

        public string TipoPedido { get; set; }

        public string Data { get; set; }

        protected bool Desligado { get; set; }
    }
}