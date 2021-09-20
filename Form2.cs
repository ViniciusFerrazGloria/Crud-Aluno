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
            Aluno Al = new Aluno(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, true);
            if (Al.validaCPF())
            {
                Al.cadastrarAluno();
            }
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
            bool status;
            if(radioButton1.Checked == true)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            aluno.setCPF(textBox12.Text);
            aluno.setAtivo(status);
            aluno.alteraStatus();
            groupBox1.Visible = false;
            textBox12.Clear();

        }
    }
}
