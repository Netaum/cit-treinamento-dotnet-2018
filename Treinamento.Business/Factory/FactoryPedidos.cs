using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.Business.Factory
{
    public class FactoryPedidos
    {
        public static Interfaces.IPedidos CriarClassePedidos()
        {
            DataAccess.Interfaces.IPedidosDAO pedidosDAO = DataAccess.Factory.FactoryPedidosDAO.CriarClassePedidosDAO();
            return new Pedidos(pedidosDAO);
        }
    }
}
