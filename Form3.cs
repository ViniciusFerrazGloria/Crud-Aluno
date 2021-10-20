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
    public partial class Form3 : Form
    {
        public static string mensagem;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
            {
                label4.Visible = true;
                label4.Text = "Algum campo esta em branco!!";
            }
            else
            {
                Modalidade M = new Modalidade(textBox1.Text, textBox2.Text, textBox3.Text);
                if (M.Validaid() == false)
                {
                    M.CadastrarModalidade();
                    label4.Visible = true;
                    label4.Text = mensagem;
                }
                else
                {
                    label4.Visible = true;
                    label4.Text = ("id indisponivel, Use outros numeros!!");
                }
            }
            
            
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            String modalidade = textBox4.Text;
            if (Modalidade.ConsultaIDModalidade(modalidade) == true)
            {
                groupBox1.Visible = true;
                label7.Visible = false;
            }
            else
            {
                label7.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string status;
            Modalidade M = new Modalidade();
            if(radioButton1.Checked == true)
            {
                status = "1";
            }
            else
            {
                status = "0";
            }
            M.setIdModalidade(textBox4.Text);
            M.setAtivo(status);
            M.alteraStatus();
            groupBox1.Visible = false;
            textBox4.Text = "";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string IDModalidade = textBox5.Text;
            if (Modalidade.ConsultaIDModalidade(IDModalidade) == true)
            {
                
                Modalidade M = new Modalidade();
                Modalidade.ConsultaModalidade(M, IDModalidade);
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                label21.Visible = false;
                label13.Text = M.getIdModalidade();
                label14.Text = M.getNomeModalidade();
                label15.Text = M.getMaxParticipantes();
                label16.Text = M.getAtivo();
            }
            else
            {
                label21.Visible = true;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String modalidade = textBox6.Text;
            if (Modalidade.ConsultaIDModalidade(modalidade) == true)
            {
                groupBox2.Visible = true;
                label20.Visible = false;
                textBox7.Text = "";
                textBox8.Text = "";
            }
            else
            {
                label20.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Modalidade M = new Modalidade();
            M.insereDadosUpdate(textBox6.Text,textBox7.Text,textBox8.Text);
            M.alteraDados();

            groupBox2.Visible = false;
            textBox6.Text = "";
        }
    }
}
