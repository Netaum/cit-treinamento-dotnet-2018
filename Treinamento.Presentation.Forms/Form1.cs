using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Treinamento.Presentation.Forms
{
    public partial class Form1 : Form
    {
        private Treinamento.Entities.Pedido _pedido;

        Treinamento.Business.Interfaces.IPedidos _pedidosBO;

        public Form1()
        {
            InitializeComponent();
            _pedidosBO = Treinamento.Business.Factory.FactoryPedidos.CriarClassePedidos();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            Entities.Pedido novoPedido = new Entities.Pedido
            {
                Data = DateTime.Now,
                Descricao =  $"Meu pedido numero {Guid.NewGuid()}",
                TipoPedido = Entities.Enum.TipoPedido.Interno,
                Numero = DateTime.Now.Second.ToString()
            };

           _pedidosBO.GravarPedido(novoPedido);

            AtualizarGrid();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            CarregarPedido();
        }

        private void CarregarPedido()
        {
            _pedido = (Treinamento.Entities.Pedido)gridView.Rows[gridView.CurrentCell.RowIndex].DataBoundItem;
            txt_description.Text = _pedido.Descricao;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SalvarPedido();
        }

        private void SalvarPedido()
        {
            _pedido.Descricao = txt_description.Text;
            
            _pedidosBO.AtualizarPedido(_pedido);

            AtualizarGrid();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            ExcluirPedido();
        }

        private void ExcluirPedido()
        {
            _pedido = (Treinamento.Entities.Pedido)gridView.Rows[gridView.CurrentCell.RowIndex].DataBoundItem;

            _pedidosBO.ExcluirPedido(_pedido.Codigo);

            AtualizarGrid();
           
        }

        private void AtualizarGrid()
        {
            var itens = _pedidosBO.RetornarItens();
            gridView.DataSource = itens;
        }
    }
}
