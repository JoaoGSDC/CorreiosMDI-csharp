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
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaEnderecoGUI frm = new ConsultaEnderecoGUI();
            frm.Show();
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ConsultaEnderecoGUI();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control oControl in this.Controls)
            {
                if (oControl is MdiClient) 
                {
                    oControl.BackColor = Color.FromArgb(237, 237, 237);
                    break;
                }
            }
        }
    }
}
