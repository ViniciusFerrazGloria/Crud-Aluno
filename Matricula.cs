using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    class Matricula
    {
        public static MySqlConnection con;
        private string id_Aluno;
        private int id_Turma;
        private string data_entrada;
        private int status;
        private string data_encerramento;

        public Matricula(string id_Aluno, int id_Turma, string data_entrada, int status, string data_encerramento)
        {
            DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003");
            this.id_Aluno = id_Aluno;
            this.id_Turma = id_Turma;
            this.data_entrada = data_entrada;
            this.status = status;
            this.data_encerramento = data_encerramento;
        }

        public Matricula()
        {

        }

        public Matricula(string idAluno, int idTurma, string dataEntrada, string dataEncerramento)
        {
            this.id_Aluno = idAluno;
            this.id_Turma = idTurma;
            this.data_entrada = dataEntrada;
            this.data_encerramento = dataEncerramento;
        }

        public Matricula(string idAluno, int idTurma)
        {
            this.id_Aluno = idAluno;
            this.id_Turma = idTurma;
        }

        ///////////////////////////////////////////////////


        public void setId_Aluno(string id_Aluno)
        {
            this.id_Aluno = id_Aluno;
        }

        public string getId_Aluno()
        {
            return this.id_Aluno;
        }

        public void setId_Turma(int id_Turma)
        {
            this.id_Turma = id_Turma;
        }

        public int getId_Turma()
        {
            return this.id_Turma;
        }

        public void setData_entrada(string data)
        {
            this.data_entrada = data;
        }

        public string getData_entrada()
        {
            return this.data_entrada;
        }

        public void setStatus(int status)
        {
            this.status = status;
        }

        public int getStatus()
        {
            return this.status;
        }

        public void setData_encerramento(string data)
        {
            this.data_encerramento = data;
        }

        public string getData_encerramento()
        {
            return this.data_encerramento;
        }

        public void Matricular()
        {
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("INSERT INTO Estudio_Matricula(cpf_Aluno, id_Turma, Status, Data_entrada, Data_encerramento)VALUES('" + this.id_Aluno + "','" + this.id_Turma + "','" + 1 + "','" + this.data_entrada + "','" + this.data_encerramento + "')", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!!");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }

        }

        public bool verificaAlunoETurma()
        {
            bool existe = false;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand busca = new MySqlCommand("SELECT * FROM Estudio_Aluno JOIN Estudio_Turma WHERE Estudio_Aluno.CPFAluno = '"+ this.id_Aluno+"'AND Estudio_Turma.IDTurma ='"+this.id_Turma+"';",DAO_Conexao.con );
                MySqlDataReader resultado = busca.ExecuteReader();

                if (resultado.Read())
                {
                    existe = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }

            return existe;
        }

        public bool verificaMatricula()
        {
            bool existe = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand busca = new MySqlCommand("SELECT * FROM Estudio_Matricula WHERE cpf_Aluno ='" + this.id_Aluno + "'AND id_Turma ='" + this.id_Turma + "'", DAO_Conexao.con);
                MySqlDataReader resultado = busca.ExecuteReader();

                if (resultado.Read())
                {
                    existe = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }


            return existe;
        }

        public void Sair()
        {
            
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand altera = new MySqlCommand("UPDATE Estudio_Matricula SET Status=0 WHERE cpf_Aluno ='" + this.id_Aluno + "'AND id_Turma ='" + this.id_Turma + "'", DAO_Conexao.con);
                altera.ExecuteNonQuery();
                MessageBox.Show("Saida feita com sucesso!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
        }







    }
}
