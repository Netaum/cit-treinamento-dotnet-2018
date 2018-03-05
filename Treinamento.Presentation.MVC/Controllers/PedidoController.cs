using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Treinamento.Entities;
using Treinamento.Presentation.MVC.Models;

namespace Treinamento.Presentation.MVC.Controllers
{
    public class PedidoController : Controller
    {
        private Business.Interfaces.IPedidos _pedidosBO;

        public PedidoController()
        {
            _pedidosBO = Business.Factory.FactoryPedidos.CriarClassePedidos();
        }

        [HttpGet]
        // GET: Pedidos
        public ActionResult Index()
        {
            var pedidosModel = new List<PedidoModel>();
            var listaDePedidos = _pedidosBO.RetornarItens();

            foreach (var pedido in listaDePedidos)
            {
                var pedidoModel = new PedidoModel
                {
                    Codigo = pedido.Codigo,
                    Descricao = pedido.Descricao,
                    Numero = pedido.Numero,
                    Data = pedido.Data.ToString("dd/MM/yyyy"),
                    TipoPedido = Enum.GetName(pedido.TipoPedido.GetType(), pedido.TipoPedido)
                };

                pedidosModel.Add(pedidoModel);
            }

            return View(pedidosModel);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(PedidoModel pedido)
        {
            var novoPedido = new Pedido
            {
                Descricao = pedido.Descricao,
                TipoPedido = Entities.Enum.TipoPedido.Interno,
                Numero = pedido.Numero,
                Data = DateTime.Now
            };

            _pedidosBO.GravarPedido(novoPedido);

            return RedirectToAction("Index");
        }
    }
}