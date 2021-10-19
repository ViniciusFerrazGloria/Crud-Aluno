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
    public partial class Form1 : Form
    {
        Thread t1;
        public Form1()
        {
            InitializeComponent();

            if (DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003"))
                Console.WriteLine("Conectado");
            else
                Console.WriteLine("Erro de conexão");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = DAO_Conexao.login(textBox1.Text, textBox2.Text);

            if (tipo == 0)
            {
                MessageBox.Show("Usuário/Login inválido");
            }

            if (tipo == 1)
            {
                MessageBox.Show("Usuário ADM");
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
                this.Close();
                t1 = new Thread(abrirForm2);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }

        }

        private void abrirForm2(object obj)
        {
            Application.Run(new Form2());
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(abrirForm2);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void abrirForm3(object obj)
        {
            Application.Run(new Form3());
        }

        private void consusltarDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(abrirForm3);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void abrirForm4(object obj)
        {
            Application.Run(new Form4());
        }

        private void cadastroTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(abrirForm4);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
    }
}


