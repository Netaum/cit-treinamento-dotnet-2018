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
    [Authorize]
    public class PedidoController : Controller
    {
        private Business.Interfaces.IPedidos _pedidosBO;
        
        public PedidoController()
        {
            _pedidosBO = Business.Factory.FactoryPedidos.CriarClassePedidos();
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
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
            if (ModelState.IsValid)
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

            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var pedido = _pedidosBO.RetornarPedido(id);
            var pedidoModel = new PedidoModel
            {
                Codigo = pedido.Codigo,
                Descricao = pedido.Descricao,
                Numero = pedido.Numero,
                Data = pedido.Data.ToString("dd/MM/yyyy"),
                TipoPedido = Enum.GetName(pedido.TipoPedido.GetType(), pedido.TipoPedido)
            };

            return View(pedidoModel);
        }

        [HttpPut]
        public ActionResult Editar(PedidoModel pedidoModel)
        {
            var pedido = new Pedido
            {
                Codigo = pedidoModel.Codigo,
                Descricao = pedidoModel.Descricao
            };

            _pedidosBO.AtualizarPedido(pedido);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var pedido = _pedidosBO.RetornarPedido(id);
            var pedidoModel = new PedidoModel
            {
                Codigo = pedido.Codigo,
                Descricao = pedido.Descricao,
                Numero = pedido.Numero,
                Data = pedido.Data.ToString("dd/MM/yyyy"),
                TipoPedido = Enum.GetName(pedido.TipoPedido.GetType(), pedido.TipoPedido)
            };

            return View(pedidoModel);
        }

        [HttpDelete]
        public ActionResult ConfirmarExclusao(int codigo)
        {
            _pedidosBO.ExcluirPedido(codigo);
            return RedirectToAction("Index");
        }
    }
}