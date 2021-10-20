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

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
