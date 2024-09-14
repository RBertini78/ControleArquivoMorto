using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAM
{
    public partial class frmCAM : Form
    {
        public frmCAM()
        {
            InitializeComponent();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastro objFrmCadastro = new frmCadastro();
            objFrmCadastro.ShowDialog();
        }

        private void pesquisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta objFrmConsulta = new frmConsulta();
            objFrmConsulta.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja Sair do Sistema?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
