using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class DAO_Conexao
    {
        public static MySqlConnection con;


        public static Boolean getConexao(String local, String banco, String user, String senha)
        {
            Boolean retorno = false;
            try
            {
                con = new MySqlConnection("server=" + local + ";User ID=" + user + ";database=" + banco + ";password = "+senha);
    
                con.Open();
                retorno = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return retorno;
        }


        public static int login(String usuario, String senha)
        {
            int tipo = 0; //0 quando não encontra
            try
            {
                con.Open();
                MySqlCommand login = new MySqlCommand("Select * from Estudio_Login where usuario ='" + usuario + "' and senha ='" + senha + "'", con);
                Console.WriteLine("Select * from Estudio_Login where usuario = '" + usuario + "' and senha = '" + senha + "'");
                MySqlDataReader resultado = login.ExecuteReader();
                if (resultado.Read())
                {
                    tipo = Convert.ToInt32(resultado["tipo"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return tipo;
        }

        public static string achaCPF(string cpf)
        {
            string volta="";
            con.Open();
            MySqlCommand acharcpf = new MySqlCommand("Select * from Estudio_Login where cpf ='" + cpf + "'", con);
            //Console.WriteLine("Select * from Estudio_Login where cpf ='" + cpf + "'");
            MySqlDataReader resultado = acharcpf.ExecuteReader();
            if (resultado.Read())
            {
                volta = Convert.ToString(resultado["cpf"].ToString());
            }
            return volta;
        }

        public static Boolean OpenConexao()
        {
            Boolean _return = true;
            try
            {
                con.Open();
            }
            catch (Exception erro)
            { 
                _return = false;
            }

            return _return;
        }

        public static Boolean CloseConexao()
        {
            Boolean _return = true;
            try
            {
                con.Close();
            }
            catch (Exception erro)
            {
                _return = false;
            }

            return _return;
        }
    }

   
}
