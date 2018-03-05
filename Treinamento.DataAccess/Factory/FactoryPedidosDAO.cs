using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.DataAccess.Interfaces;
using Treinamento.DataAccess.SQL;

namespace Treinamento.DataAccess.Factory
{
    public static class FactoryPedidosDAO
    {
        public static IPedidosDAO CriarClassePedidosDAO()
        {
            return new Treinamento.DataAccess.SQL.PedidosSqlDAO();
        }
    }
}
