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

        public Modalidade(string idModalidade, string NomeModalidade, string MaxParticipantes)
        {
            DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003");
            setIdModalidade(idModalidade);
            setNomeModalidade(NomeModalidade);
            setMaxParticipantes(MaxParticipantes);
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
        
        public void CadastrarModalidade()
        {
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("INSERT INTO Estudio_Modalidade (IDModalidade, NomeModalidade, MaxParticipantes) VALUES ('" + idModalidade + "','" + NomeModalidade + "','" + MaxParticipantes + "')", DAO_Conexao.con);
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
            string id="";
            bool volta = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand pesquisa = new MySqlCommand("select * from Estudio_Modalidade where ('" + idModalidade + "')", DAO_Conexao.con);
                //insere.Parameters.AddWithValue("foto", this.Foto);
                MySqlDataReader resultado = pesquisa.ExecuteReader();
                if (resultado.Read() )
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
            if(id==idModalidade)
            {
                volta = true;
            }
            return volta;
        }
    }
}
