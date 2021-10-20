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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Insira todos os dados");
            }
            else
            {
                string idModalidade = textBox1.Text;
                string idTurma = textBox2.Text;
                string nomeProfessor = textBox3.Text;
                string horarios = textBox4.Text;
                string diaSemana = textBox5.Text;
                string xNaSemana = textBox6.Text;
                string nDeAlunos = textBox7.Text;
                bool cadastrou = false;
                Turma t = new Turma(idTurma, idModalidade, nomeProfessor, horarios, diaSemana, xNaSemana, nDeAlunos);

                if (t.Validaid())
                {
                    cadastrou = t.cadastraTurma();
                }
                else
                {
                    MessageBox.Show("Id não encontrado");
                }

                if (cadastrou)
                {
                    MessageBox.Show("Cadastro efetuado com sucesso");
                }
                else
                {
                    MessageBox.Show("Falha no Cadastro");
                }
            }
        }
    }
}
