using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioMDI
{
    public partial class ConsultaEnderecoGUI : Form
    {
        public ConsultaEnderecoGUI()
        {
            InitializeComponent();
        }

        public void searchCep()
        {
            if (!string.IsNullOrWhiteSpace(txtCep.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(txtCep.Text.Trim());
                        addToFields(endereco);
                    } 
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else
            {
                MessageBox.Show("Informe um CEP válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addToFields(WSCorreios.enderecoERP endereco)
        {
            txtEstado.Text = endereco.uf;
            txtCidade.Text = endereco.cidade;
            txtBairro.Text = endereco.bairro;
            txtRua.Text = endereco.end;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            searchCep();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCep.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtRua.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
