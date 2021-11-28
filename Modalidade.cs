using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    class Modalidade
    {

        public static MySqlConnection con;
        private string idModalidade;
        private string NomeModalidade;
        private string MaxParticipantes;
        private string ativo;
        private int valor;

        public Modalidade(string idModalidade, string NomeModalidade, string MaxParticipantes, int valor)
        {
            DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003");
            setIdModalidade(idModalidade);
            setNomeModalidade(NomeModalidade);
            setMaxParticipantes(MaxParticipantes);
            this.valor = valor;
        }

        public Modalidade()
        {

        }

        //////////////////////////////////////////////////
        public void setIdModalidade(string idModalidade)
        {
            this.idModalidade = idModalidade;
        }

        public string getIdModalidade()
        {
            return this.idModalidade;
        }

        //////////////////////////////////////////////////

        public void setNomeModalidade(string NomeModalidade)
        {
            this.NomeModalidade = NomeModalidade;
        }

        public string getNomeModalidade()
        {
            return this.NomeModalidade;
        }

        //////////////////////////////////////////////////

        public void setMaxParticipantes(string MaxParticipantes)
        {
            this.MaxParticipantes = MaxParticipantes;
        }

        public string getMaxParticipantes()
        {
            return this.MaxParticipantes;
        }

        //////////////////////////////////////////////////

        public void setAtivo(string ativo)
        {
            this.ativo = ativo;
        }

        public string getAtivo()
        {
            return this.ativo;
        }

        public void setValor(int valor)
        {
            this.valor = valor;
        }

        public int getValor()
        {
            return this.valor;
        }

        //////////////////////////////////////////////////

        public void CadastrarModalidade()
        {
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("INSERT INTO Estudio_Modalidade (IDModalidade, NomeModalidade, MaxParticipantes, Valor) VALUES ('" + idModalidade + "','" + NomeModalidade + "','" + MaxParticipantes + "','" + valor + "')", DAO_Conexao.con);
                //insere.Parameters.AddWithValue("foto", this.Foto);
                insere.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            Form3.mensagem = "Cadastrado com Sucesso!";
        }

        public bool Validaid()
        {
            string id = "";
            bool volta = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand pesquisa = new MySqlCommand("select * from Estudio_Modalidade where ('" + idModalidade + "')", DAO_Conexao.con);
                //insere.Parameters.AddWithValue("foto", this.Foto);
                MySqlDataReader resultado = pesquisa.ExecuteReader();
                if (resultado.Read())
                {
                    id = resultado["IDModalidade"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            if (id == idModalidade)
            {
                volta = true;
            }
            return volta;
        }

        public static bool ConsultaIDModalidade(string idModalidade)
        {
            Boolean existe = false;


            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade WHERE IDModalidade ='" + idModalidade + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return existe;

        }

        public void alteraStatus()
        {

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand altera = new MySqlCommand("UPDATE Estudio_Modalidade SET Ativo='" + getAtivo() + "' WHERE IDModalidade='" + getIdModalidade() + "';", DAO_Conexao.con);
                altera.ExecuteNonQuery();
                MessageBox.Show("Status alterado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }

        }

        public static object ConsultaModalidade(Modalidade M,string idModalidade)
        {

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade WHERE IDModalidade ='" + idModalidade + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    M.setIdModalidade(resultado["IDModalidade"].ToString());
                    M.setNomeModalidade(resultado["NomeModalidade"].ToString());
                    M.setMaxParticipantes(resultado["MaxParticipantes"].ToString());
                    M.setAtivo(resultado["Ativo"].ToString());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return M;

        }

        public void alteraDados()
        {

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand update = new MySqlCommand("UPDATE Estudio_Modalidade SET NomeModalidade='" + getNomeModalidade() + "', MaxParticipantes='" + getMaxParticipantes() + "' where IDModalidade = '"+ getIdModalidade() +"'", DAO_Conexao.con);
                update.ExecuteNonQuery();
                MessageBox.Show("Dados alterados com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
        }

        public void insereDadosUpdate(string idModalidade, string NomeModalidade, string MaxParticipantes)
        {
            this.idModalidade = idModalidade;
            this.NomeModalidade = NomeModalidade;
            this.MaxParticipantes = MaxParticipantes;


        }
    }
}
