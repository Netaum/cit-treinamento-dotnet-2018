using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.Business.Interfaces
{
    public interface IPedidos
    {
        List<Entities.Pedido> RetornarItens();

        Entities.Pedido GravarPedido(Entities.Pedido pedido);

        void AtualizarPedido(Entities.Pedido pedido);

        void ExcluirPedido(int codigo);
    }
}
