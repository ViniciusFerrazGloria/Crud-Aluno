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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            button3.Enabled = false;
        }

        private void cadastrarMensalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mensalidade = 0;

            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                string idAluno = textBox1.Text;
                string mes = comboBox1.Text;
                Mensalidade m = new Mensalidade(idAluno, mes);

                if (m.verificaMatriculaAtiva())
                {
                    if (!m.verificaSeEstaPago())
                    {
                        mensalidade = m.calculaMensalidade();

                        textBox2.Text = mensalidade.ToString();
                        button3.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("A mensalidade deste mês está paga!");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Esta matricula está desativada");
                }
                
            }


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                int valor = int.Parse(textBox2.Text);
                string idAluno = textBox1.Text;
                string mes = comboBox1.Text;
                string pago = "pago";
                Mensalidade m = new Mensalidade(idAluno, valor, mes, pago);

                m.pagarMensalidade();
            }
        }
    }
}
