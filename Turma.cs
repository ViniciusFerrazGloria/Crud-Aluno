using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    class Turma
    {
        /*id turma
        id modalidade
        nomeprofessor
        horario
        diasemana
        XnaSemana
        NdeAlunos(add +1 a cada castro até atingir a QuantidadeMaxDeParticipantes da modalidade)*/

        private string idTurma;
        private string idModalidade;
        private string nomeProfessor;
        private string horarios;
        private string diaSemana;
        private string XnaSemana;
        private string NdeAlunos;
        private string ativo;

        public Turma(string idTurma, string idModalidade, string nomeProfessor, string diaSemana, string horarios,  string NdeAlunos, string XnaSemana)
        {
            DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003");
            setIdTurma(idTurma);
            setIdModalidade(idModalidade);
            setNomeProfessor(nomeProfessor);
            setDiaSemana(diaSemana);
            setHorarios(horarios);
            setXnaSemana(XnaSemana);
            setNdeAlunos(NdeAlunos);

        }

        public Turma()
        {

        }

        /////////////////////////////////
        public void setIdTurma(string idTurma)
        {
            this.idTurma = idTurma;
        }

        public string getIdTurma()
        {
            return this.idTurma;
        }

        /////////////////////////////////

        public void setIdModalidade(string idModalidade)
        {
            this.idModalidade = idModalidade;
        }

        public string getIdModalidade()
        {
            return this.idModalidade;
        }
        /////////////////////////////////

        public void setNomeProfessor(string nomeProfessor)
        {
            this.nomeProfessor = nomeProfessor;
        }

        public string getNomeProfessor()
        {
            return this.nomeProfessor;
        }

        /////////////////////////////////

        public void setHorarios(string horarios)
        {
            this.horarios = horarios;
        }

        public string gethorarios()
        {
            return this.horarios;
        }

        /////////////////////////////////

        public void setDiaSemana(string diaSemana)
        {
            this.diaSemana = diaSemana;
        }

        public string getDiaSemana()
        {
            return this.diaSemana;
        }

        /////////////////////////////////

        public void setXnaSemana(string XnaSemana)
        {
            this.XnaSemana = XnaSemana;
        }

        public string getXnaSemana()
        {
            return this.XnaSemana;
        }

        /////////////////////////////////

        public void setNdeAlunos(string NdeAlunos)
        {
            this.NdeAlunos = NdeAlunos;
        }

        public string getNdeAlunos()
        {
            return this.NdeAlunos;
        }

        /////////////////////////////////

        public void setAtivo(string ativo)
        {
            this.ativo = ativo;
        }

        public string getAtivo()
        {
            return this.ativo;
        }

        //////////////////////////////////////////////////
        public bool cadastraTurma()
        {
            bool inseriu = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("INSERT INTO Estudio_Turma (IDTurma, IDModalidade, NomeProfessor, DiasSemana, Horarios, NumeroDeAlunos, XNaSemana) VALUES ('"+ idTurma + "','" + idModalidade + "','" + nomeProfessor + "','" + diaSemana + "','" + horarios + "','" + NdeAlunos + "','" + XnaSemana + "')", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                inseriu = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return inseriu;
        }

        public bool Validaid(string idTurma)
        {
            bool volta = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand pesquisa = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE IDTurma='" + idTurma + "'", DAO_Conexao.con);
                //insere.Parameters.AddWithValue("foto", this.Foto);
                MySqlDataReader resultado = pesquisa.ExecuteReader();
                if (resultado.Read())
                {
                    volta = true;
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
            return volta;
        }

        public bool ValidaMaxP(string idModalidade,string NdePessoas )
        {
            bool volta = true;
            string maxparticipantes = "0";
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand pesquisa = new MySqlCommand("SELECT MaxParticipantes FROM Estudio_Modalidade WHERE IDModalidade='" + idModalidade + "'", DAO_Conexao.con);
                //insere.Parameters.AddWithValue("foto", this.Foto);
                MySqlDataReader resultado = pesquisa.ExecuteReader();
                if (resultado.Read())
                {
                    maxparticipantes = resultado["MaxParticipantes"].ToString();
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

            if(Convert.ToInt32(NdePessoas)<= Convert.ToInt32(maxparticipantes))
            {
                volta = false;
            }
            return volta;
        }

        public string PegaModalidade(string idTurma)
        {

            string idmodalidade = "";
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand pesquisa = new MySqlCommand("SELECT IDModalidade FROM Estudio_Turma WHERE IDTurma='" + idTurma + "'", DAO_Conexao.con);
                //insere.Parameters.AddWithValue("foto", this.Foto);
                MySqlDataReader resultado = pesquisa.ExecuteReader();
                if (resultado.Read())
                {
                    idmodalidade = resultado["IDMOdalidade"].ToString();
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

            return idmodalidade;
        }

        public static object ConsultaTurma(Turma T, string idTurma)
        {

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE IDTurma ='" + idTurma + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    T.setIdTurma(resultado["IDTurma"].ToString());
                    T.setIdModalidade(resultado["IDModalidade"].ToString());
                    T.setNomeProfessor(resultado["NomeProfessor"].ToString());
                    T.setDiaSemana(resultado["DiasSemana"].ToString());
                    T.setHorarios(resultado["Horarios"].ToString());
                    T.setNdeAlunos(resultado["NumeroDeAlunos"].ToString());
                    T.setXnaSemana(resultado["XnaSemana"].ToString());
                    T.setAtivo(resultado["Ativo"].ToString());

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
            return T;

        }

        public static bool ConsultaIDTurma(string idTurma)
        {
            Boolean existe = false;


            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE IDTurma ='" + idTurma + "'", DAO_Conexao.con);
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
                MySqlCommand altera = new MySqlCommand("UPDATE Estudio_Turma SET Ativo='" + getAtivo() + "' WHERE IDTurma='" + getIdTurma() + "';", DAO_Conexao.con);
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

        public void insereDadosUpdate(string idTurma, string nomeProfessor, string diaSemana, string horarios, string NdeAlunos, string XnaSemana)
        {
            this.idTurma = idTurma;
            this.nomeProfessor = nomeProfessor;
            this.diaSemana = diaSemana;
            this.horarios = horarios;
            this.NdeAlunos = NdeAlunos;
            this.XnaSemana = XnaSemana;


        }

        public void alteraDados()
        {

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand update = new MySqlCommand("UPDATE Estudio_Turma SET NomeProfessor='" + getNomeProfessor() + "', DiasSemana='" + getDiaSemana() + "', Horarios='" + gethorarios() + "', NumeroDeAlunos='" + getNdeAlunos() + "', XnaSemana='" + getXnaSemana() + "' where IDTurma = '" + getIdTurma() + "'", DAO_Conexao.con);
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
    }

}
