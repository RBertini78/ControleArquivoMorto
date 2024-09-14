using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAM
{
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            CarregarListView();
        }


        #region Métodos
        private void CarregarListView()
        {
            Dados objDados = new Dados();
            List<CAM.Dados.Alunos> listaAlunos = new List<Dados.Alunos>();
            listaAlunos = objDados.Pesquisar();
            

            foreach (var itemLista in listaAlunos)
            {
                ListViewItem objListViewItem = new ListViewItem();
                objListViewItem.Text = itemLista.codigo_aluno.ToString();
                objListViewItem.SubItems.Add(itemLista.nome_aluno);
                objListViewItem.SubItems.Add(itemLista.num_pasta.ToString());
                objListViewItem.SubItems.Add(itemLista.num_prontuario.ToString());
                lstAlunos.Items.Add(objListViewItem);
            }
        }

        private void ExcluirRegistro()
        {
            int ctrl = 0;

            try
            {
                if (lstAlunos.SelectedItems.Count > 0)
                {
                    ctrl = Convert.ToInt32(lstAlunos.SelectedItems[0].Text);

                    Dados objDados = new Dados();

                    if (ctrl > 0)
                    {
                        objDados.Excluir(ctrl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        private void EditarRegistro()
        {
          int cod_aluno;
          string nome;
          int pasta;
          int prontuario;

          try
          {
              if (lstAlunos.SelectedItems.Count > 0)
              {
                  cod_aluno = Convert.ToInt32(lstAlunos.SelectedItems[0].Text);
                  nome = lstAlunos.SelectedItems[0].SubItems[1].Text;
                  pasta = Convert.ToInt32(lstAlunos.SelectedItems[0].SubItems[2].Text);
                  prontuario = Convert.ToInt32(lstAlunos.SelectedItems[0].SubItems[3].Text);

                  frmCadastro objFrmCadastro = new frmCadastro();
                  objFrmCadastro.cod_aluno = cod_aluno;
                  objFrmCadastro.nome = nome;
                  objFrmCadastro.pasta = pasta;
                  objFrmCadastro.prontuario = prontuario;
                  objFrmCadastro.ShowDialog();
              }
          }
          catch (Exception ex)
          {

              MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message);
          }

        }

        #endregion

        #region Botões
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirRegistro();                  
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }
        #endregion

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            lstAlunos.FindItemWithText(txtNome.Text);
        }

    }
}
