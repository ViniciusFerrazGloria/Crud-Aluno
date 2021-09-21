using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Estudio
{
    public partial class Form2 : Form
    {
        //Thread t2;

        public Form2()
        {
            InitializeComponent();
            if (DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003"))
                Console.WriteLine("Conectado");
            else
                MessageBox.Show("Erro de conexão");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String cpf = textBox12.Text;
            if (Aluno.consultaAluno(cpf))
            {
                groupBox1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            String status;
            if(radioButton1.Checked == true)
            {
                status = "1";
            }
            else
            {
                status = "0";
            }
            aluno.setCPF(textBox12.Text);
            aluno.setAtivo(status);
            aluno.alteraStatus();
            groupBox1.Visible = false;
            textBox12.Clear();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Aluno Al = new Aluno(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, "1");
            if (Al.validaCPF())
            {
                Al.cadastrarAluno();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label37.Text = textBox13.Text;
            try
            {
                //DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Aluno WHERE CPFAluno ='" + textBox13.Text + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    
                    label31.Text = resultado["CEPAluno"].ToString();
                    label36.Text = resultado["NomeAluno"].ToString();
                    label34.Text = resultado["NumeroAluno"].ToString();
                    label33.Text = resultado["BairroAluno"].ToString();
                    label32.Text = resultado["ComplementoAluno"].ToString();
                    label35.Text = resultado["RuaAluno"].ToString();
                    label30.Text = resultado["CidadeAluno"].ToString();
                    label29.Text = resultado["EstadoAluno"].ToString();
                    label28.Text = resultado["TelefoneAluno"].ToString();
                    label27.Text = resultado["EmailAluno"].ToString();

                }
                MessageBox.Show("chegou até aqui");

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

        private void button5_Click(object sender, EventArgs e)
        {
            string cpf = textBox14.Text;
            if (Aluno.consultaAluno(cpf))
            {
                groupBox2.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Aluno aluno2 = new Aluno();
            aluno2.insereDadosUpdate(textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text, textBox20.Text, textBox21.Text, textBox22.Text, textBox23.Text);
            aluno2.alteraDados();
        }
    }
}
