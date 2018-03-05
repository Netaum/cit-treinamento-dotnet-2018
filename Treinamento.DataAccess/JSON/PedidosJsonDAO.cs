using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.DataAccess.Interfaces;
using Treinamento.Entities;

namespace Treinamento.DataAccess.JSON
{


    public class PedidosJsonDAO : IPedidosDAO
    {
        private string _caminhoArquivoJSON = System.Configuration.ConfigurationManager.AppSettings["caminhoJSON"];
        public void AtualizarPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void ExcluirPedido(int codigoPedido)
        {
            throw new NotImplementedException();
        }

        public Pedido GravarNovoPedido(Pedido pedido)
        {
            var pedidos = RetornarPedidos();
            pedido.Codigo = GerarCodigoItem(pedidos);
            
            pedidos.Add(pedido);
            
            string jsonPedidos = Newtonsoft.Json.JsonConvert.SerializeObject(pedidos);

            using(StreamWriter writer = new StreamWriter(_caminhoArquivoJSON))
            {
                writer.Write(jsonPedidos);
            }

            return pedido;

           
        }

        private int GerarCodigoItem(List<Pedido> listaItens)
        {
            int codigo = 1;

            if (listaItens.Any())
            {
                codigo += listaItens.Last().Codigo;
            }

            return codigo;
        }

        public List<Pedido> RetornarPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();

            if (File.Exists(_caminhoArquivoJSON))
            {
                using (StreamReader reader = new StreamReader(_caminhoArquivoJSON))
                {
                    pedidos = JsonConvert.DeserializeObject<List<Pedido>>(reader.ReadToEnd());
                }
            }

            return pedidos;
        }
    }
}
