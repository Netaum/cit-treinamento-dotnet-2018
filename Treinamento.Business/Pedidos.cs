using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.Business.Interfaces;
using Treinamento.Entities;

namespace Treinamento.Business
{
    public class Pedidos : Treinamento.Business.Interfaces.IPedidos
    {
        private DataAccess.Interfaces.IPedidosDAO _pedidosDAO;

        public Pedidos(DataAccess.Interfaces.IPedidosDAO pedidosDAO)
        {
            _pedidosDAO = pedidosDAO;
        }

        public DataAccess.Interfaces.IPedidosDAO pedidasDAO = Treinamento.DataAccess.Factory.FactoryPedidosDAO.CriarClassePedidosDAO();
        public List<Pedido> RetornarItens()
        {
            return _pedidosDAO.RetornarPedidos();
        }

        public Pedido GravarPedido(Pedido pedido)
        {
            pedido = _pedidosDAO.GravarNovoPedido(pedido);

            return pedido;
        }
        public void AtualizarPedido(Entities.Pedido pedido)
        {
            _pedidosDAO.AtualizarPedido(pedido);
        }

        public void ExcluirPedido(int codigo)
        {
            _pedidosDAO.ExcluirPedido(codigo);
        }
    }
}
