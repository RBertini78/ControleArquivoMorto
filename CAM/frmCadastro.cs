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
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        #region Variáveis Públicas

        public int cod_aluno = 0;
        public string nome;
        public int pasta;
        public int prontuario;

        #endregion

        #region Métodos

        private void Atualizar(int codigo_aluno, string nome_aluno, int num_pasta, int num_prontuario)
        {
            try
            {
                Dados objDados = new Dados();
                objDados.Atualizar(codigo_aluno, nome_aluno, num_pasta, num_prontuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message);
            }
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
        #endregion

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNome.Text) &&
                !String.IsNullOrEmpty(txtCaixa.Text) &&
                !String.IsNullOrEmpty(txtProntuario.Text))
            {
                int pasta = int.Parse(txtCaixa.Text);
                int prontuario = Convert.ToInt32(txtProntuario.Text);
                if (cod_aluno == 0)
                {
                    Gravar(txtNome.Text, pasta, prontuario);
                    txtCaixa.Clear();
                    txtNome.Clear();
                    txtProntuario.Clear();
                }
                else
                    Atualizar(cod_aluno, txtNome.Text,Convert.ToInt32(txtCaixa.Text), Convert.ToInt32(txtProntuario.Text));

            }

            else
            {
                if (String.IsNullOrEmpty(txtNome.Text))
                {
                    epErro.SetError(txtNome, "Informe o nome do aluno!");
                }
                if (String.IsNullOrEmpty(txtCaixa.Text))
                {
                    epErro.SetError(txtCaixa, "Informe a Caixa!");
                }
                if (String.IsNullOrEmpty(txtProntuario.Text))
                {
                    epErro.SetError(txtProntuario, "Informe o Prontuário!");
                }
            }
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            if (cod_aluno > 0)
            {
                btnGravar.Text = "Atualizar";
                txtNome.Text = nome;
                txtCaixa.Text = pasta.ToString();
                txtProntuario.Text = prontuario.ToString();
            }
            else
                btnGravar.Text = "Gravar";
        }
      }
}
