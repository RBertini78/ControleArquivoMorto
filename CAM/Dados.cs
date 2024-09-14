using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAM
{
    public class Dados
    {
        //Variável que receberá a string de conexão
        public string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //Variáveis constantes que conterão as instruções SQL para o CRUD
        public const string strDelete = "DELETE FROM tab_principal WHERE codigo_aluno = @codigo_aluno";
        public const string strInsert = "INSERT INTO tab_principal VALUES " + 
            "(@nome_aluno, @num_pasta, @num_prontuario)";
        public const string strSelect = "SELECT codigo_aluno, nome_aluno, num_pasta, num_prontuario FROM tab_principal";
        public const string strUpdate = "UPDATE tab_principal " +
            "SET nome_aluno = @nome_aluno, num_pasta = @num_pasta, num_prontuario = @num_prontuario WHERE codigo_aluno = @codigo_aluno";

        public class Alunos
        {
            public int codigo_aluno { get; set; }
            public string nome_aluno { get; set; }
            public int num_pasta { get; set; }
            public int num_prontuario { get; set; }
        }
        

        public void Atualizar(int codigo_aluno, string nome_aluno, int num_pasta, int num_prontuario)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strUpdate, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@codigo_aluno", codigo_aluno);
                    objCommand.Parameters.AddWithValue("@nome_aluno", nome_aluno);
                    objCommand.Parameters.AddWithValue("@num_pasta", num_pasta);
                    objCommand.Parameters.AddWithValue("@num_prontuario", num_prontuario);

                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
        }
        public List<Alunos> Pesquisar()
        {
            List<Alunos> lstAlunos = new List<Alunos>();
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strSelect, objConexao))
                {
                   
                    objConexao.Open();

                    SqlDataReader objDataReader = objCommand.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        
                        while (objDataReader.Read())
                        {
                            Alunos objAlunos = new Alunos();
                            objAlunos.codigo_aluno = Convert.ToInt32(objDataReader["codigo_aluno"].ToString());
                            objAlunos.nome_aluno = objDataReader["nome_aluno"].ToString();
                            objAlunos.num_pasta = Convert.ToInt32(objDataReader["num_pasta"].ToString());
                            objAlunos.num_prontuario = Convert.ToInt32(objDataReader["num_prontuario"].ToString());
                            lstAlunos.Add(objAlunos);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstAlunos;
        }
        public void Excluir(int codigo_aluno)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strDelete, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@codigo_aluno", codigo_aluno);
                    
                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
        }
        public void Gravar(string nome_aluno, int num_pasta, int num_prontuario)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strInsert, objConexao))
                {
                    objCommand.Parameters.AddWithValue("@nome_aluno", nome_aluno);
                    objCommand.Parameters.AddWithValue("@num_pasta", num_pasta);
                    objCommand.Parameters.AddWithValue("@num_prontuario", num_prontuario);

                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();
                }

            }
        }
    }
}
