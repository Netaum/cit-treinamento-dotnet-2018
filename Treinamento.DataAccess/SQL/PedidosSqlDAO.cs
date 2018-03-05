using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.DataAccess.Interfaces;
using Treinamento.Entities;

namespace Treinamento.DataAccess.SQL
{
    public class PedidosSqlDAO : IPedidosDAO
    {
        private readonly SqlConnection _conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MEU_DB"].ToString());

        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MEU_DB"].ToString();

        void IPedidosDAO.AtualizarPedido(Pedido pedido)
        {
            var sqlQuery = $@"UPDATE dbo.tb_pedido SET ds_pedido = @ds_pedido WHERE cd_pedido = @cd_pedido";

            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                sql.Execute(sql: sqlQuery,
                            param: new
                            {
                                ds_pedido = pedido.Descricao,
                                cd_pedido = pedido.Codigo
                            },
                            commandType: CommandType.Text
                            );
            }
        }

        void IPedidosDAO.ExcluirPedido(int codigoPedido)
        {
            string sqlQuery = $@"DELETE FROM dbo.tb_pedido WHERE cd_pedido = @cd_pedido";

            SqlCommand deleteCommand = new SqlCommand(sqlQuery, _conexao);

            deleteCommand.Parameters.Add("@cd_pedido", SqlDbType.Int);
            deleteCommand.Parameters["@cd_pedido"].Value = codigoPedido;

            _conexao.Open();
            deleteCommand.ExecuteNonQuery();
            _conexao.Close();
        }

        Pedido IPedidosDAO.GravarNovoPedido(Pedido pedido)
        {
            string sqlQuery = $@"INSERT INTO dbo.tb_pedido(nr_numero_pedido, ds_pedido, cd_tipo_pedido, dt_pedido)  
                                VALUES(@nr_pedido, @ds_pedido, @cd_tipo_pedido, @dt_pedido);
                                SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, _conexao);

            sqlCommand.Parameters.Add("@nr_pedido", SqlDbType.VarChar);
            sqlCommand.Parameters["@nr_pedido"].Value = pedido.Numero;

            sqlCommand.Parameters.Add("@ds_pedido", SqlDbType.VarChar);
            sqlCommand.Parameters["@ds_pedido"].Value = pedido.Descricao;

            sqlCommand.Parameters.Add("@cd_tipo_pedido", SqlDbType.Int);
            sqlCommand.Parameters["@cd_tipo_pedido"].Value = pedido.TipoPedido;

            sqlCommand.Parameters.Add("@dt_pedido", SqlDbType.DateTime);
            sqlCommand.Parameters["@dt_pedido"].Value = pedido.Data;


            _conexao.Open();
            pedido.Codigo = Convert.ToInt32(sqlCommand.ExecuteScalar());
            _conexao.Close();

            return pedido;
        }

        List<Pedido> IPedidosDAO.RetornarPedidos()
        {
            string sqlQuery = "SELECT cd_pedido as Codigo, nr_numero_pedido as Numero, ds_pedido as Descricao, cd_tipo_pedido as TipoPedido, dt_pedido as Data, in_desligado as Desligado FROM tb_pedido";

            using (SqlConnection sql = new SqlConnection(connectionString))
            {

                return sql.Query<Pedido>(sql: sqlQuery, commandType: CommandType.Text).ToList();

            }


        }
    }
}
