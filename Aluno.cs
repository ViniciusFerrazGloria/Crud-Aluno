using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    class Aluno
    {
        private string CPF;
        private string Nome;
        private string Rua;
        private string Numero;
        private string Bairro;
        private string Complemento;
        private string CEP;
        private string Cidade;
        private string Estado;
        private string Telefone;
        private string Email;
        private byte[] Foto;
        private string Ativo;
        
        public static MySqlConnection con;



        public Aluno(string cpf, string nome, string rua, string numero, string bairro, string complemento, string cep, string cidade, string estado, string telefone, string email, /*byte[] foto,*/ string ativo)
        {
            DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003");
            setCPF(cpf);
            setNome(nome);
            setRua(rua);
            setNumero(numero);
            setBairro(bairro);
            setComplemento(complemento);
            setCEP(cep);
            setCidade(cidade);
            setEstado(estado);
            setTelefone(telefone);
            setEmail(email);
            //setFoto(foto);
            setAtivo(ativo);
        }

        public Aluno()
        {

        }
        /////////////////////////////////
        public void setCPF(string cpf)
        {
            //if(verificaCPF(CPF)==true) { this.CPF = cpf; }
            //else { throw new Exception("CPF invalido!"); }
            this.CPF = cpf;
        }

        public string getCPF()
        {
            return this.CPF;
        }
        /////////////////////////////////
        public void setNome(string nome)
        {
            this.Nome = nome;
        }

        public string getNome()
        {
            return this.Nome;
        }
        /////////////////////////////////
        private void setRua(string rua)
        {
            this.Rua = rua;
        }

        private string getRua()
        {
            return this.Rua;
        }
        /////////////////////////////////
        private void setNumero(string numero)
        {
            this.Numero = numero;
        }

        private string getNumero()
        {
            return this.Numero;
        }
        /////////////////////////////////
        private void setBairro(string bairro)
        {
            this.Bairro = bairro;
        }

        private string getBairro()
        {
            return this.Bairro;
        }
        /////////////////////////////////
        private void setComplemento(string complemento)
        {
            this.Complemento = complemento;
        }

        private string getComplemento()
        {
            return this.Complemento;
        }
        /////////////////////////////////
        private void setCidade(string cidade)
        {
            this.Cidade = cidade;
        }

        private string getCidade()
        {
            return this.Cidade;
        }
        /////////////////////////////////
        private void setCEP(string cep)
        {
            this.CEP = cep;
        }

        private string getCEP()
        {
            return this.CEP;
        }
        /////////////////////////////////
        private void setEstado(string estado)
        {
            this.Estado = estado;
        }

        private string getEstado()
        {
            return this.Estado;
        }
        /////////////////////////////////
        private void setTelefone(string telefone)
        {
            this.Telefone = telefone;
        }

        private string getTelefone()
        {
            return this.Telefone;
        }
        /////////////////////////////////
        private void setEmail(string email)
        {
            this.Email = email;
        }

        private string getEmail()
        {
            return this.Email;
        }
        /////////////////////////////////
        private void setFoto(byte[] foto)
        {
            this.Foto = foto;
        }

        private byte[] getFoto()
        {
            return this.Foto;
        }
        /////////////////////////////////
        public void setAtivo(string ativo)
        {
            this.Ativo = ativo;
        }

        public string getAtivo()
        {
            return this.Ativo;
        }

        public bool validaCPF() //string CPF - sem parâmetro
        {
            int soma, resto, cont = 0;
            soma = 0;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "");
            CPF = CPF.Replace("-", "");

            for (int i = 0; i < CPF.Length; i++)
            {
                int a = CPF[0] - '0';
                int b = CPF[i] - '0';

                if (a == b) cont++;
            }

            if (cont == 11) return false;

            for (int i = 1; i <= 9; i++) soma += int.Parse(CPF.Substring(i - 1, 1)) * (11 - i);

            resto = (soma * 10) % 11;

            if ((resto == 10) || (resto == 11)) resto = 0;

            if (resto != int.Parse(CPF.Substring(9, 1))) return false;

            soma = 0;

            for (int i = 1; i <= 10; i++) soma += int.Parse(CPF.Substring(i - 1, 1)) * (12 - i);

            resto = (soma * 10) % 11;

            if ((resto == 10) || (resto == 11)) resto = 0;

            if (resto != int.Parse(CPF.Substring(10, 1))) return false;

            return true;
        }

        public void alteraStatus()
        {
            DAO_Conexao.con.Open();
            try
            {
                MySqlCommand altera = new MySqlCommand("UPDATE Estudio_Aluno SET Ativo='" + getAtivo() + "' WHERE CPFAluno='" + getCPF() + "';", DAO_Conexao.con);
                altera.ExecuteNonQuery();
                MessageBox.Show("Status alterado com sucesso");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static bool consultaAluno(string cpf)
        {
            Boolean existe = false;

            try
            {
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Aluno WHERE CPFAluno='" + cpf + "'", DAO_Conexao.con);
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

        public void cadastrarAluno()
        {
            
            try
            {
                MySqlCommand insere = new MySqlCommand("INSERT INTO Estudio_Aluno (CPFAluno, NomeAluno, RuaAluno, NumeroAluno, BairroAluno, ComplementoAluno, CEPAluno, CidadeAluno, EstadoAluno, TelefoneAluno, EmailAluno) VALUES ('" + CPF + "','" + Nome + "','" + Rua + "','" + Numero + "','" + Bairro + "','" + Complemento + "','" + CEP + "','" + Cidade + "','" + Estado + "','" + Telefone + "','" + Email + "')", DAO_Conexao.con);
                //insere.Parameters.AddWithValue("foto", this.Foto);
                insere.ExecuteNonQuery();
                MessageBox.Show("Cadastrado");
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


        public void alteraDados()
        {
            DAO_Conexao.con.Open();
            try
            {
                MySqlCommand update = new MySqlCommand("UPDATE Estudio_Aluno SET RuaAluno='" + getRua() + "', NumeroAluno='" + getNumero() + "', BairroAluno='" + getBairro() + "', ComplementoAluno='" + getComplemento() + "', CEPAluno='" + getCEP() + "', CidadeAluno='" + getCidade() + "', EstadoAluno='" + getEstado() + "', TelefoneAluno='" + getTelefone() + "', EmailAluno='" + getEmail() + "' WHERE CPFAluno='" + getCPF() + "'", DAO_Conexao.con);
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

        public void insereDadosUpdate(string cpf, string Rua, string Numero, string Bairro, string Complemento, string cep, string Cidade, string Estado, string Telefone, string Email)
        {
            this.CPF = cpf;
            this.Rua = Rua;
            this.Numero = Numero;
            this.Bairro = Bairro;
            this.Complemento = Complemento;
            this.CEP = cep;
            this.Cidade = Cidade;
            this.Estado = Estado;
            this.Telefone = Telefone;
            this.Email = Email;

        }


    }
}
