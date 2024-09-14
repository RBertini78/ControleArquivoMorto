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
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Gravar(string nome_aluno, int num_pasta, int num_prontuario)
        {
            try
            {
                Dados objDados = new Dados();
                objDados.Gravar(nome_aluno, num_pasta, num_prontuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro!" + ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNome.Text) &&
                !String.IsNullOrEmpty(txtCaixa.Text) &&
                !String.IsNullOrEmpty(txtProntuario.Text))
            {
                int pasta = int.Parse(txtCaixa.Text);
                int prontuario = Convert.ToInt32(txtProntuario.Text);
                Gravar(txtNome.Text, pasta, prontuario);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Dados objDados = new Dados();
            objDados.Excluir(Convert.ToInt32(txtCodigo.Text));
        }
    }
}
