using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            button3.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(maskedTextBox1.Text) || String.IsNullOrEmpty(maskedTextBox2.Text))
            {
                MessageBox.Show("Insira todos os dados");
            }
            else
            {
                string idAluno = textBox1.Text;
                int idTurma = int.Parse(textBox2.Text);
                string dataEntrada = maskedTextBox1.Text;
                string dataEncerramento = maskedTextBox2.Text;
                Matricula m = new Matricula(idAluno, idTurma, dataEntrada, dataEncerramento);

                if (m.verificaAlunoETurma())
                {
                    m.Matricular();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    maskedTextBox1.Text = "";
                    maskedTextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Os dados digitados não existem em nossos registros");
                }

                
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Insira todos os dados");
            }
            else
            {
                string idAluno = textBox3.Text;
                int idTurma = int.Parse(textBox4.Text);

                Matricula m = new Matricula(idAluno, idTurma);

                if (m.verificaMatricula())
                {
                    button3.Visible = true;

                }
                else
                {
                    MessageBox.Show("Matricula não encontrada");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idAluno = textBox3.Text;
            int idTurma = int.Parse(textBox4.Text);

            Matricula m = new Matricula(idAluno, idTurma);

            m.Sair();
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
