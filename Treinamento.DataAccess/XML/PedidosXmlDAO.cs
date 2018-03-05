using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Treinamento.DataAccess.Interfaces;
using Treinamento.Entities;

namespace Treinamento.DataAccess.XML
{
    public class PedidosXmlDAO : IPedidosDAO
    {
        private XmlSerializer _xs = new XmlSerializer(typeof(List<Pedido>));
        private string _caminhoArquivo = @"D:\Treinamento\itens.xml";

        public Pedido GravarNovoPedido(Pedido pedido)
        {
            //Recupera lista para adicionar novo pedido
            List<Pedido> pedidos = RecuperarListaXml();

            pedido.Codigo = GerarCodigoItem();

            pedidos.Add(pedido);

            GravarPedidosEmArquivo(pedidos);

            return pedido;
        }

        public List<Pedido> RetornarPedidos()
        {
            return RecuperarListaXml();
        }

        public void AtualizarPedido(Pedido pedido)
        {
            List<Pedido> pedidos = RemoverPedidoExistente(pedido.Codigo);
            pedidos.Add(pedido);

            GravarPedidosEmArquivo(pedidos);
        }

        public void ExcluirPedido(int codigoPedido)
        {
            List<Pedido> pedidos = RemoverPedidoExistente(codigoPedido);
            GravarPedidosEmArquivo(pedidos);
        }

        private void GravarPedidosEmArquivo(List<Pedido> pedidos)
        {
            using (System.IO.TextWriter textWriter = new System.IO.StreamWriter(_caminhoArquivo))
            {
                _xs.Serialize(textWriter, pedidos);
            }
            
        }

        private List<Pedido> RemoverPedidoExistente(int codigoPedido)
        {
            var pedidos = RecuperarListaXml();

            foreach (var pedidoExistente in pedidos)
            {
                if (pedidoExistente.Codigo == codigoPedido)
                {
                    pedidos.Remove(pedidoExistente);
                    break;
                }
            }

            return pedidos;
        }

        private List<Pedido> RecuperarListaXml()
        {
            List<Pedido> itens = new List<Pedido>();

            if (File.Exists(_caminhoArquivo))
            {
                using (var sr = new StreamReader(_caminhoArquivo))
                {
                    itens = (_xs.Deserialize(sr) as List<Pedido>);
                }
            }

            return itens;
        }

        private int GerarCodigoItem()
        {
            int codigo = 1;
            List<Pedido> listaItens = RetornarPedidos();

            if (listaItens.Any())
            {
                codigo += listaItens.Last().Codigo;
            }

            return codigo;
        }

    }
}
