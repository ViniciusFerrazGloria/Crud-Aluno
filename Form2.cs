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

namespace Estudio
{
    public partial class Form2 : Form
    {
        //Thread t2;

        public Form2()
        {
            InitializeComponent();
            if (DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003"))
                MessageBox.Show("Conectado");
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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String cpf = textBox13.Text;
            if (Aluno.consultaAluno(cpf))
            {
                groupBox2.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Aluno aluno2 = new Aluno();
            aluno2.insereDadosUpdate(textBox13.Text, textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text, textBox20.Text, textBox21.Text, textBox22.Text);
            aluno2.alteraDados();
        }
    }
}
