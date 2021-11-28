using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    class Mensalidade
    {
        private string id_Aluno;
        private int Valor;
        private string Mes;
        private string Pago;


        public Mensalidade(string id_Aluno, int Valor, string Mes, string Pago)
        {
            DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003");
            setId_Aluno(id_Aluno);
            setValor(Valor);
            setMes(Mes);
            setPago(Pago);

        }

        public Mensalidade(string id_Aluno)
        {
            this.id_Aluno = id_Aluno;
        }

        public Mensalidade(string id_Aluno, string mes)
        {
            this.id_Aluno = id_Aluno;
            this.Mes = mes;
        }
        public Mensalidade()
        {

        }

        /////////////////////////////////
        public void setId_Aluno(string id_Aluno)
        {
            this.id_Aluno = id_Aluno;
        }

        public string getId_Aluno()
        {
            return this.id_Aluno;
        }

        /////////////////////////////////
        public void setValor(int Valor)
        {
            this.Valor = Valor;
        }

        public int getValor()
        {
            return this.Valor;
        }

        /////////////////////////////////
        public void setMes(string Mes)
        {
            this.Mes = Mes;
        }

        public string getMes()
        {
            return this.Mes;
        }

        /////////////////////////////////
        public void setPago(string Pago)
        {
            this.Pago = Pago;
        }

        public string getPago()
        {
            return this.Pago;
        }

        public bool verificaMatriculaAtiva()
        {
            bool ativo = false;
            string idAluno = getId_Aluno();
            int status = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand verifica = new MySqlCommand("SELECT Status FROM Estudio_Matricula WHERE cpf_Aluno='" + idAluno + "'", DAO_Conexao.con);
                MySqlDataReader resultado = verifica.ExecuteReader();

                while (resultado.Read())
                {
                    status = resultado.GetInt32(0);
                }

                if(status == 1)
                {
                    ativo = true;
                }


            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }


            return ativo;
        }

        public int calculaMensalidade()
        {
            int mensalidade = 0;
            ArrayList idTurma = new ArrayList();
            ArrayList idModalidade = new ArrayList();
            string idAluno = getId_Aluno();

            //RECEBO OS IDS DAS TURMAS
            try
            {
                DAO_Conexao.con.Open();

                MySqlCommand busca = new MySqlCommand("SELECT id_Turma from Estudio_Matricula WHERE cpf_Aluno = '" + idAluno + "'", DAO_Conexao.con);
                MySqlDataReader resultado = busca.ExecuteReader();

                while (resultado.Read())
                {
                    idTurma.Add(resultado.GetInt32(0));
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                DAO_Conexao.con.Close();
            }

            //RECEBO OS IDS DAS MODALIDADES
            for(int i = 0; i<idTurma.Count; i++)
            {
                try
                {
                    DAO_Conexao.con.Open();
                    MySqlCommand busca = new MySqlCommand("SELECT  IDModalidade FROM Estudio_Turma WHERE IDTurma = '" + idTurma[i] + "'", DAO_Conexao.con);
                    MySqlDataReader resultado = busca.ExecuteReader();

                    while (resultado.Read())
                    {
                        idModalidade.Add(resultado.GetInt32(0));
                        Console.WriteLine(resultado.GetInt32(0));
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
            }

            for(int j = 0; j<idModalidade.Count; j++)
            {
                try
                {
                    DAO_Conexao.con.Open();
                    MySqlCommand busca = new MySqlCommand("SELECT valor FROM Estudio_Modalidade WHERE IDModalidade ='" + idModalidade[j] + "'", DAO_Conexao.con);
                    MySqlDataReader resultado = busca.ExecuteReader();

                    while (resultado.Read())
                    {
                        mensalidade += resultado.GetInt32(0);
                        Console.WriteLine(mensalidade);
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
            }

            return mensalidade;
        }


        public void pagarMensalidade()
        {
            string idAluno = getId_Aluno();
            int valor = getValor();
            string mes = getMes();
            string pago = getPago();
            

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand paga = new MySqlCommand("INSERT INTO Estudio_Mensalidade(cpf_Aluno, valor, mes, pago) VALUES('" + idAluno + "','" + valor + "','" + mes + "','" + pago + "')", DAO_Conexao.con );
                paga.ExecuteNonQuery();
                MessageBox.Show("Pagamento efetuado com sucesso!");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
        }

        public bool verificaSeEstaPago()
        {
            bool estaPago = false;

            string mes = getMes();
            string idAluno = getId_Aluno();

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand busca = new MySqlCommand("SELECT * FROM Estudio_Mensalidade WHERE mes = '" + mes + "'AND cpf_Aluno= '" + idAluno+ "'", DAO_Conexao.con);
                MySqlDataReader resultado = busca.ExecuteReader();

                if (resultado.Read())
                {
                    estaPago = true;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }

            return estaPago;
        }
        
    }




}
