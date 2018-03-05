using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.Entities;

namespace Treinamento.DataAccess.Interfaces
{
    public interface IPedidosDAO
    {
        Pedido GravarNovoPedido(Pedido pedido);

        void AtualizarPedido(Pedido pedido);

        void ExcluirPedido(int codigoPedido);

        List<Pedido> RetornarPedidos();
    }
}
